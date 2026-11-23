using SQLite;

namespace MLZ2026.Core;

public record TodoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public override string ToString() => Title;
}