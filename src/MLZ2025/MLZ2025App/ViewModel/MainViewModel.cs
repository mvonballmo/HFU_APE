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
    void Add()
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
    void Delete(string item)
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
}
