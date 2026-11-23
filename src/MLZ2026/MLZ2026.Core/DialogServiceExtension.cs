namespace MLZ2026.Core;

public static class DialogServiceExtension
{
    public static Task<bool> Ask(this IDialogService dialogService, string title, string description)
    {
        return dialogService.Ask(title, description, "yes", "no");
    }

    public static Task Show(this IDialogService dialogService, string title, string description)
    {
        return dialogService.Show(title, description, "ok");
    }
}