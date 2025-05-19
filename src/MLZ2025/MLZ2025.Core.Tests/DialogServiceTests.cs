using Microsoft.Maui.Networking;
using MLZ2025.Core.Services;
using MLZ2025.Core.ViewModel;

namespace MLZ2025.Core.Tests;

public class DialogServiceTests
{
    [Test]
    public void TestCannotAddEmptyText()
    {
        var testDialogService = new TestDialogService();
        var serviceProvider = new ServiceCollection()
            .AddCoreServices()
            .AddSingleton<IDialogService>(testDialogService)
            .BuildServiceProvider();

        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.Text = "";

        viewModel.AddCommand.Execute(null);

        Assert.That(testDialogService.LastMessage, Is.EqualTo("Please enter a text"));
    }

    private class TestDialogService : IDialogService
    {
        public Task ShowErrorMessage(string message)
        {
            LastMessage = message;

            return Task.CompletedTask;
        }

        public string LastMessage { get; set; }
    }
}
