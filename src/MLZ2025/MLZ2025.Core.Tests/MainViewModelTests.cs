using Microsoft.Maui.Networking;
using MLZ2025.Core.Services;
using MLZ2025.Core.ViewModel;

namespace MLZ2025.Core.Tests;

public class MainViewModelTests : TestsBase
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
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.Text = text;

        viewModel.AddCommand.Execute(null);

        Assert.That(_testDialogService.LastMessage, Is.EqualTo("Please enter a text"));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("\r")]
    [TestCase("   ")]
    [TestCase(null)]
    [TestCase("\n")]
    public void TestCannotSelectEmptyText(string? text)
    {
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.Text = text;

        viewModel.SelectCommand.Execute(null);

        Assert.That(_testDialogService.LastMessage, Is.EqualTo("Please enter a text"));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("\r")]
    [TestCase("   ")]
    [TestCase(null)]
    [TestCase("\n")]
    public void TestCannotDeleteEmptyText(string? text)
    {
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();
        viewModel.Text = text;

        viewModel.DeleteCommand.Execute(null);

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

    [Test]
    public void TestDeleteItem()
    {
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainViewModel>();

        var item = viewModel.Items.Last();

        viewModel.DeleteCommand.Execute(item);

        Assert.That(_testDialogService.LastMessage, Is.EqualTo(""));
        Assert.That(viewModel.Items, Does.Not.Contain(item));
    }
}
