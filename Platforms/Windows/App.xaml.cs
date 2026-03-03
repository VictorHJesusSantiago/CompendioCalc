namespace CompendioCalc.WinUI;

public partial class App : MauiWinUIApplication
{
    public App()
    {
        this.InitializeComponent();
        UnhandledException += (sender, args) =>
        {
            var msg = args.Exception?.ToString() ?? "Unknown error";
            File.WriteAllText(
                Path.Combine(AppContext.BaseDirectory, "crash.log"),
                $"[{DateTime.Now}] {msg}");
            args.Handled = true;
        };
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
