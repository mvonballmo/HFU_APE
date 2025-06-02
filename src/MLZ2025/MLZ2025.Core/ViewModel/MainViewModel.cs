using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MLZ2025.Core.Model;
using MLZ2025.Core.Services;

namespace MLZ2025.Core.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly IConnectivity _connectivity;
    private readonly IDialogService _dialogService;
    private readonly DataAccess<DatabaseAddress> _dataAccess;
    private readonly IHttpServerAccess _httpServerAccess;

    // TODO Use a custom object instead.
    [ObservableProperty] private ObservableCollection<string> _items = [];

    [ObservableProperty] private string _firstName = "Bob";
    [ObservableProperty] private string _lastName = "Jones";
    [ObservableProperty] private string _zipCode = "13357";
    [ObservableProperty] private DateTime _birthday = DateTime.Today;

    public MainViewModel(IConnectivity connectivity, IDialogService dialogService, DataAccess<DatabaseAddress> dataAccess, IHttpServerAccess httpServerAccess)
    {
        _connectivity = connectivity;
        _dialogService = dialogService;
        _dataAccess = dataAccess;
        _httpServerAccess = httpServerAccess;

        // TODO add a loading property

        // Task.Run(LoadAsync);
    }

    [RelayCommand]
    private async Task Load()
    {
        // TODO Map all properties from the address to the UI
        var firstNames = _dataAccess.Table().Select(address => address.FirstName).ToList();

        if (firstNames.Count == 0)
        {
            var serverAddresses = await _httpServerAccess.GetAddressesAsync();
            firstNames = serverAddresses.Select(address => address.FirstName).ToList();
        }

        Items = new ObservableCollection<string>(firstNames);
    }

    [RelayCommand]
    private async Task Add()
    {
        var text = FirstName;

        if (await ValidateText(text))
        {
            Items.Add(text);

            _dataAccess.Insert(new DatabaseAddress
            {
                FirstName = FirstName,
                LastName = LastName,
                ZipCode = ZipCode,
                Birthday = Birthday
            });
        }
    }

    [RelayCommand]
    private async Task Delete(string item)
    {
        if (await ValidateText(item))
        {
            if (!Items.Remove(item))
            {
                Debug.WriteLine($"Cannot remove {item} because it is not in the list.");
            }
        }
    }

    [RelayCommand]
    private async Task Select(string item)
    {
        if (await ValidateText(item))
        {
            // TODO Use the dictionary instead.
            // Figure out how to test the Shell <https://software-engineering-corner.zuehlke.com/how-to-test-a-net-maui-app-part-1#heading-testing-of-a-view-model>
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailViewModel.Text)}={item}");
        }
    }

    private async Task<bool> ValidateText(string text)
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await _dialogService.ShowErrorMessage("No Internet. Please check your internet connection.");

            return false;
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            await ShowEmptyTextErrorMessage();

            // TODO Use a logger instead.
            Debug.WriteLine("Text is empty");

            return false;
        }

        return true;
    }

    private async Task ShowEmptyTextErrorMessage()
    {
        await _dialogService.ShowErrorMessage("Please enter a text");
    }
}
