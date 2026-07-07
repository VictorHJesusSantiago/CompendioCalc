namespace CompendioCalc.Services;

public sealed record LuDecomposition(double[,] Lower, double[,] Upper, int[] Permutation, int Sign);
public sealed record QrDecomposition(double[,] Q, double[,] R);

public sealed class LinearAlgebraService
{
    private const double Epsilon = 1e-14;

    public double Dot(IReadOnlyList<double> a, IReadOnlyList<double> b)
    {
        EnsureSameLength(a, b);
        return a.Select((value, index) => value * b[index]).Sum();
    }

    public double[] Cross(IReadOnlyList<double> a, IReadOnlyList<double> b)
    {
        if (a.Count != 3 || b.Count != 3) throw new ArgumentException("Produto vetorial requer vetores 3D.");
        return [a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]];
    }

    public double Norm(IReadOnlyList<double> vector) => Math.Sqrt(Dot(vector, vector));

    public double Distance(IReadOnlyList<double> a, IReadOnlyList<double> b)
    {
        EnsureSameLength(a, b);
        return Norm(a.Select((value, index) => value - b[index]).ToArray());
    }

    public double[,] Multiply(double[,] a, double[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0)) throw new ArgumentException("Dimensões incompatíveis.");
        var result = new double[a.GetLength(0), b.GetLength(1)];
        for (var i = 0; i < result.GetLength(0); i++)
        for (var j = 0; j < result.GetLength(1); j++)
        for (var k = 0; k < a.GetLength(1); k++)
            result[i, j] += a[i, k] * b[k, j];
        return result;
    }

    public double[] Multiply(double[,] matrix, IReadOnlyList<double> vector)
    {
        if (matrix.GetLength(1) != vector.Count) throw new ArgumentException("Dimensões incompatíveis.");
        var result = new double[matrix.GetLength(0)];
        for (var row = 0; row < matrix.GetLength(0); row++)
        for (var column = 0; column < matrix.GetLength(1); column++)
            result[row] += matrix[row, column] * vector[column];
        return result;
    }

    public LuDecomposition Lu(double[,] matrix)
    {
        EnsureSquare(matrix);
        var n = matrix.GetLength(0);
        var combined = (double[,])matrix.Clone();
        var permutation = Enumerable.Range(0, n).ToArray();
        var sign = 1;
        for (var column = 0; column < n; column++)
        {
            var pivot = column;
            for (var row = column + 1; row < n; row++)
                if (Math.Abs(combined[row, column]) > Math.Abs(combined[pivot, column])) pivot = row;
            if (Math.Abs(combined[pivot, column]) < Epsilon) throw new ArithmeticException("Matriz singular.");
            if (pivot != column)
            {
                SwapRows(combined, pivot, column);
                (permutation[pivot], permutation[column]) = (permutation[column], permutation[pivot]);
                sign = -sign;
            }
            for (var row = column + 1; row < n; row++)
            {
                combined[row, column] /= combined[column, column];
                for (var j = column + 1; j < n; j++)
                    combined[row, j] -= combined[row, column] * combined[column, j];
            }
        }
        var lower = new double[n, n];
        var upper = new double[n, n];
        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
        {
            if (i > j) lower[i, j] = combined[i, j];
            else upper[i, j] = combined[i, j];
            if (i == j) lower[i, j] = 1;
        }
        return new(lower, upper, permutation, sign);
    }

    public double Determinant(double[,] matrix)
    {
        var decomposition = Lu(matrix);
        double determinant = decomposition.Sign;
        for (var i = 0; i < matrix.GetLength(0); i++) determinant *= decomposition.Upper[i, i];
        return determinant;
    }

    public double[] Solve(double[,] matrix, IReadOnlyList<double> right)
    {
        EnsureSquare(matrix);
        var n = matrix.GetLength(0);
        if (right.Count != n) throw new ArgumentException("Vetor independente incompatível.");
        var lu = Lu(matrix);
        var y = new double[n];
        for (var i = 0; i < n; i++)
        {
            var value = right[lu.Permutation[i]];
            for (var j = 0; j < i; j++) value -= lu.Lower[i, j] * y[j];
            y[i] = value;
        }
        var x = new double[n];
        for (var i = n - 1; i >= 0; i--)
        {
            var value = y[i];
            for (var j = i + 1; j < n; j++) value -= lu.Upper[i, j] * x[j];
            x[i] = value / lu.Upper[i, i];
        }
        return x;
    }

    public double[,] Inverse(double[,] matrix)
    {
        EnsureSquare(matrix);
        var n = matrix.GetLength(0);
        var result = new double[n, n];
        for (var column = 0; column < n; column++)
        {
            var basis = new double[n];
            basis[column] = 1;
            var solution = Solve(matrix, basis);
            for (var row = 0; row < n; row++) result[row, column] = solution[row];
        }
        return result;
    }

    public double[,] Cholesky(double[,] matrix)
    {
        EnsureSquare(matrix);
        var n = matrix.GetLength(0);
        var lower = new double[n, n];
        for (var i = 0; i < n; i++)
        for (var j = 0; j <= i; j++)
        {
            var sum = 0d;
            for (var k = 0; k < j; k++) sum += lower[i, k] * lower[j, k];
            if (i == j)
            {
                var diagonal = matrix[i, i] - sum;
                if (diagonal <= 0) throw new ArithmeticException("Matriz não é definida positiva.");
                lower[i, j] = Math.Sqrt(diagonal);
            }
            else lower[i, j] = (matrix[i, j] - sum) / lower[j, j];
        }
        return lower;
    }

    public QrDecomposition Qr(double[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var columns = matrix.GetLength(1);
        if (rows < columns) throw new ArgumentException("QR requer número de linhas maior ou igual ao de colunas.");
        var q = new double[rows, columns];
        var r = new double[columns, columns];
        for (var column = 0; column < columns; column++)
        {
            var vector = Enumerable.Range(0, rows).Select(row => matrix[row, column]).ToArray();
            for (var previous = 0; previous < column; previous++)
            {
                var qColumn = Enumerable.Range(0, rows).Select(row => q[row, previous]).ToArray();
                r[previous, column] = Dot(qColumn, vector);
                for (var row = 0; row < rows; row++) vector[row] -= r[previous, column] * q[row, previous];
            }
            r[column, column] = Norm(vector);
            if (r[column, column] < Epsilon) throw new ArithmeticException("Colunas linearmente dependentes.");
            for (var row = 0; row < rows; row++) q[row, column] = vector[row] / r[column, column];
        }
        return new(q, r);
    }

    private static void EnsureSquare(double[,] matrix)
    {
        if (matrix.GetLength(0) == 0 || matrix.GetLength(0) != matrix.GetLength(1))
            throw new ArgumentException("A matriz deve ser quadrada e não vazia.");
    }

    private static void EnsureSameLength(IReadOnlyList<double> a, IReadOnlyList<double> b)
    {
        if (a.Count == 0 || a.Count != b.Count) throw new ArgumentException("Vetores incompatíveis.");
    }

    private static void SwapRows(double[,] matrix, int first, int second)
    {
        for (var column = 0; column < matrix.GetLength(1); column++)
            (matrix[first, column], matrix[second, column]) = (matrix[second, column], matrix[first, column]);
    }
}
