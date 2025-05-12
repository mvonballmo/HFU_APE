using MLZ2025.ViewModel;

namespace MLZ2025;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
        BindingContext = mainViewModel;
	}
}

