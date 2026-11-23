namespace MLZ2026.Core;

public interface  IDatabaseService
{
    IEnumerable<string> GetTables();
    
    // TODO Can we make this generic?
    int Insert(TodoItem item);
    
    IEnumerable<TodoItem> GetItems();
    
    void DeleteAll();
    
    void Delete(TodoItem item);
    
    void Update(TodoItem todoItem);
}