namespace MLZ2026.Core.Tests;

[TestFixture]
public sealed class DialogServiceTests
{
    [Test]
    public async Task TestShow()
    {
        var dialogService = CreateDialogService();

        await dialogService.Show("title", "description");
    }

    [Test]
    public async Task TestAsk()
    {
        var dialogService = CreateDialogService();

        var answer = await dialogService.Ask("title", "description");

        Assert.AreEqual(answer, true);
    }

    private static IDialogService CreateDialogService()
    {
        var provider = new ServiceCollection()
            .AddTestCore()
            .BuildServiceProvider();

        var dialogService = provider.GetRequiredService<IDialogService>();
        return dialogService;
    }
}