using SQLite;

namespace MLZ2026.Core;

public interface  IDatabaseService
{
    IEnumerable<string> GetTables();
    
    // TODO Can we make this generic?
    Task<int> Insert(TodoItem item);
    
    AsyncTableQuery<TodoItem> GetItems();
    
    Task<int> DeleteAll();
    
    Task<int> Delete(TodoItem item);
    
    Task<int> Update(TodoItem todoItem);
    
    Task EnsureTablesExist();
}