namespace MLZ2026.Core.Tests;

public class TestDialogService : IDialogService
{
    public Task Show(string title, string description, string cancel)
    {
        return Task.CompletedTask;
    }

    public Task<bool> Ask(string title, string description, string accept, string cancel)
    {
        return Task.FromResult(true);
    }
}