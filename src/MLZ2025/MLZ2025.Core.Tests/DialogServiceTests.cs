using Microsoft.Maui.Networking;
using MLZ2025.Core.Services;
using MLZ2025.Core.ViewModel;

namespace MLZ2025.Core.Tests;

public class DialogServiceTests
{
    private readonly TestDialogService _testDialogService = new();

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("\r")]
    [TestCase("   ")]
    [TestCase(null)]
    [TestCase("\n")]
    public void TestCannotAddEmptyText(string? text)
    {
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.Text = text;

        viewModel.AddCommand.Execute(null);

        Assert.That(_testDialogService.LastMessage, Is.EqualTo("Please enter a text"));
    }

    [Test]
    public void TestAddItem()
    {
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.Text = "Item 1";

        viewModel.AddCommand.Execute(null);

        Assert.That(_testDialogService.LastMessage, Is.EqualTo(""));
        Assert.That(viewModel.Items.Last(), Is.EqualTo("Item 1"));
    }

    private ServiceProvider CreateServiceProvider()
    {
        return new ServiceCollection()
            .AddCoreServices()
            .AddSingleton<IDialogService>(_testDialogService)
            .AddSingleton<IConnectivity, TestConnectivity>()
            .BuildServiceProvider();
    }

    private class TestDialogService : IDialogService
    {
        public Task ShowErrorMessage(string message)
        {
            LastMessage = message;

            return Task.CompletedTask;
        }

        public string LastMessage { get; private set; } = string.Empty;
    }

    private class TestConnectivity : IConnectivity
    {
        public NetworkAccess NetworkAccess => NetworkAccess.Internet;
        public event EventHandler<ConnectivityChangedEventArgs>? ConnectivityChanged;

        public IEnumerable<ConnectionProfile> ConnectionProfiles => new List<ConnectionProfile>
        {
            ConnectionProfile.WiFi,
            ConnectionProfile.Cellular
        };
    }
}
