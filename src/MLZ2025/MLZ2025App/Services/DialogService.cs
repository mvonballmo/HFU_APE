namespace MLZ2025.ViewModel;

public class DialogService : IDialogService
{
    public async Task ShowErrorMessage(string message)
    {
        await Shell.Current.DisplayAlert("Error", message, "OK");
    }
}
