namespace MLZ2026.Core.Tests;

[TestFixture]
public sealed class DialogServiceTests : TestsBase
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
        return CreateService<IDialogService>();
    }
}