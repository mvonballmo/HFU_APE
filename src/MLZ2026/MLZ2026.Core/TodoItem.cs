using SQLite;

namespace MLZ2026.Core;

public class TodoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
}