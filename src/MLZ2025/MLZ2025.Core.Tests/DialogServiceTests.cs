using Microsoft.Maui.Networking;
using MLZ2025.Core.Services;
using MLZ2025.Core.ViewModel;

namespace MLZ2025.Core.Tests;

public class DialogServiceTests
{
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("\r")]
    [TestCase("   ")]
    [TestCase(null)]
    [TestCase("\n")]
    public void TestCannotAddEmptyText(string? text)
    {
        var testDialogService = new TestDialogService();
        var serviceProvider = new ServiceCollection()
            .AddCoreServices()
            .AddSingleton<IDialogService>(testDialogService)
            .BuildServiceProvider();

        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.Text = text;

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
