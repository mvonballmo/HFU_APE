using System.Text.Json;

namespace Core.Tests;

[TestFixture]
public class JSONTests
{
    [Test]
    public void TestSerializationAndDeserialization()
    {
        var settingsModel = new SettingsModel();

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        var settingsModelAsText = JsonSerializer.Serialize(settingsModel, options);

        Assert.That(settingsModelAsText, Is.EqualTo("{\n  \"Id\": null,\n  \"FirstName\": \"Hans\",\n  \"LastName\": \"Muster\",\n  \"Count\": 1\n}"));

        var deserialized = JsonSerializer.Deserialize<SettingsModel>(settingsModelAsText);

        Assert.That(deserialized, Is.Not.Null);

        Assert.That(deserialized.Id, Is.Null);
        Assert.That(deserialized.FirstName, Is.EqualTo("Hans"));
        Assert.That(deserialized.LastName, Is.EqualTo("Muster"));
        Assert.That(deserialized.Count, Is.EqualTo(1));
        Assert.That(deserialized.Id, Is.Null);
    }
}