namespace ImGuiTesting;

internal static class Program
{
    [STAThread]
    static async Task Main()
    {
        var services = new ServiceCollection()
            .AddSingleton<App>(x => ActivatorUtilities.CreateInstance<App>(x, "Vision Helper"))
            .AddSingleton<UserInterface>()
            .BuildServiceProvider();

        var userInterface = services.GetRequiredService<UserInterface>();
        await services.GetRequiredService<App>().SetWindowFunction(userInterface.Run).ConfigureAwait(false);
    }
}