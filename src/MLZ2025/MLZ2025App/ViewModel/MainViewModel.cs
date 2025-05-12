using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MLZ2025.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<string> _items =
    [
        "Apples",
        "Bananas",
        "Oranges"
    ];

    [ObservableProperty] private string _text = "Something";

    [RelayCommand]
    private void Add()
    {
        // TODO Show a message instead.
        if (string.IsNullOrWhiteSpace(Text))
        {
            // TODO Use a logger instead.

            Debug.WriteLine("Text is empty");

            return;
        }

        Items.Add(Text);
        Text = "";
    }

    [RelayCommand]
    private void Delete(string item)
    {
        // TODO Show a message instead.
        if (string.IsNullOrWhiteSpace(item))
        {
            // TODO Use a logger instead.

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
            // TODO Use a logger instead.

            Debug.WriteLine("Text is empty");

            return;
        }

        // TODO Use the dictionary instead.
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailViewModel.Text)}={item}");
    }
}
