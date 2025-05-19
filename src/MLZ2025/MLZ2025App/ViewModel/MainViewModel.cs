using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MLZ2025.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly IConnectivity _connectivity;
    private readonly IDialogService _dialogService;

    // TODO Use a custom object instead.
    [ObservableProperty] private ObservableCollection<string> _items =
    [
        "Apples",
        "Bananas",
        "Oranges"
    ];

    [ObservableProperty] private string _text = "Something";

    public MainViewModel(IConnectivity connectivity, IDialogService dialogService)
    {
        _connectivity = connectivity;
        _dialogService = dialogService;
    }

    [RelayCommand]
    private async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
        {
            await ShowEmptyTextErrorMessage();

            // TODO Use a logger instead.

            Debug.WriteLine("Text is empty");

            return;
        }

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            // TODO extract the dialog to a service.
            await Shell.Current.DisplayAlert("No Internet", "Please check your internet connection.", "OK");
        }

        Items.Add(Text);
        Text = "";
    }

    [RelayCommand]
    private async Task Delete(string item)
    {
        // TODO Show a message instead.
        if (string.IsNullOrWhiteSpace(item))
        {
            await ShowEmptyTextErrorMessage();

            Debug.WriteLine("Text is empty");

            return;
        }

        if (!Items.Remove(item))
        {
            Debug.WriteLine($"Cannot remove {item} because it is not in the list.");
        }
    }

    [RelayCommand]
    private async Task Select(string item)
    {
        // TODO Show a message instead.
        if (string.IsNullOrWhiteSpace(item))
        {
            await ShowEmptyTextErrorMessage();

            Debug.WriteLine("Text is empty");

            return;
        }

        // TODO Use the dictionary instead.
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailViewModel.Text)}={item}");
    }

    private async Task ShowEmptyTextErrorMessage()
    {
        await _dialogService.ShowErrorMessage("Please enter a text");
    }
}
