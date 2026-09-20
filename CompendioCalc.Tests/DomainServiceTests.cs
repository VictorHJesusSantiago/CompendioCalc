using CompendioCalc.Models;
using CompendioCalc.Services;
using Xunit;

namespace CompendioCalc.Tests;

public sealed class DomainServiceTests
{
    [Fact]
    public void ExactRational_NormalizesAndOperatesExactly()
    {
        var oneHalf = ExactRational.Parse("2/4");
        var oneThird = ExactRational.Parse("0.333");

        Assert.Equal("1/2", oneHalf.ToString());
        Assert.Equal("333/1000", oneThird.ToString());
        Assert.Equal("5/6", (oneHalf + new ExactRational(1, 3)).ToString());
        Assert.Equal("-1/2", (-oneHalf).ToString());
    }

    [Fact]
    public void AdvancedNumerics_ComputesCombinatoricsAndDistributions()
    {
        var service = new AdvancedNumericsService();

        Assert.Equal(120, service.Factorial(5));
        Assert.Equal(10, service.Combination(5, 2));
        Assert.Equal(0.5, service.BinomialPmf(successes: 1, trials: 2, probability: 0.5), 12);
        Assert.Equal(Math.Exp(-2) * 2, service.PoissonPmf(events: 1, lambda: 2), 12);
    }

    [Fact]
    public void LinearAlgebra_SolvesSmallSystemAndComputesDeterminant()
    {
        var service = new LinearAlgebraService();
        double[,] matrix =
        {
            { 2, 1 },
            { 1, 3 }
        };

        var solution = service.Solve(matrix, [1, 2]);

        Assert.Equal(5, service.Determinant(matrix), 12);
        Assert.Equal(0.2, solution[0], 12);
        Assert.Equal(0.6, solution[1], 12);
    }

    [Fact]
    public void BibliographyService_ValidatesIdentifiersAndFindsDuplicates()
    {
        var service = new BibliographyService();
        var reference = new ReferenciaBibliografica
        {
            Titulo = "Numerical Recipes",
            Autores = ["Press", "Teukolsky"],
            Editora = "Cambridge",
            Ano = "2007",
            Doi = "10.1000/182",
            Isbn = "978-0-306-40615-7"
        };

        Assert.True(service.ValidateDoi("https://doi.org/10.1000/182"));
        Assert.True(service.ValidateIsbn(reference.Isbn));
        Assert.Contains("Numerical Recipes", service.Format(reference, CitationStyle.Apa));

        var duplicate = new ReferenciaBibliografica { Titulo = "Other", Doi = "10.1000/182" };
        Assert.Single(service.FindDuplicates([reference, duplicate]));
    }
}
