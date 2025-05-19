using MLZ2025.Core.Services;

namespace MLZ2025.Core.Tests;

public class TestsBase
{
    protected readonly TestDialogService _testDialogService = new();

    protected ServiceProvider CreateServiceProvider()
    {
        return new ServiceCollection()
            .AddCoreServices()
            .AddSingleton<IDialogService>(_testDialogService)
            .AddSingleton<IConnectivity, TestConnectivity>()
            .BuildServiceProvider();
    }

    protected class TestDialogService : IDialogService
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
