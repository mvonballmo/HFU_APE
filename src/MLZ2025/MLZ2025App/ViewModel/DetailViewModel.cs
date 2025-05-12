using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MLZ2025.ViewModel;

[QueryProperty(nameof(Text), nameof(Text))]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    private string _text = "";

    [RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..", true);
    }
}
