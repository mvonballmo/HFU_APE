using CommunityToolkit.Mvvm.ComponentModel;

namespace MLZ2025.ViewModel;

public partial class MainViewModel : ObservableObject
{
  [ObservableProperty]
  private string _text = "Something";
}