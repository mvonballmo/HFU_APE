namespace MLZ2026.Core;

public class AppService : IAppService
{
    private readonly IExternalDataService _externalDataService;
    private readonly IDatabaseServiceFactory _databaseServiceFactory;

    public AppService(IExternalDataService externalDataService, IDatabaseServiceFactory databaseServiceFactory)
    {
        _externalDataService = externalDataService ?? throw new ArgumentNullException(nameof(externalDataService));
        _databaseServiceFactory = databaseServiceFactory ?? throw new ArgumentNullException(nameof(databaseServiceFactory));
    }

    public async Task SeedIfEmpty()
    {
        var databaseService = await _databaseServiceFactory.CreateService();

        var item = await databaseService.GetItems().FirstOrDefaultAsync();

        if (item == null)
        {
            var todoItems = await _externalDataService.GetTodoItems();

            foreach (var todoItem in todoItems)
            {
                await databaseService.Insert(todoItem);
            }
        }
    }

    public async Task DeleteAll()
    {
        var databaseService = await _databaseServiceFactory.CreateService();
        
        await databaseService.DeleteAll();
    }
}