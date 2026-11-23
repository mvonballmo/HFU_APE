namespace MLZ2026.Core.Tests;

[TestFixture]
public class HttpClientTests : TestsBase
{
    [Test]
    public async Task TestGetUrl()
    {
        var externalDataService = CreateExternalDataService();

        var todos = await externalDataService.GetTodoItems();
        
        Assert.IsNotNull(todos);
    }
    
    private static IExternalDataService CreateExternalDataService()
    {
        return CreateService<IExternalDataService>();
    }
}