namespace MLZ2026.Core;

public interface IDialogService
{
    Task Show(string title, string description, string cancel);

    Task<bool> Ask(string title, string description, string accept, string cancel);
}