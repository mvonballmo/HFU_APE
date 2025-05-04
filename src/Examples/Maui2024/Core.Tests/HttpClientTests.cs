using System.Text.Json;

namespace Core.Tests;

[TestFixture]
public class HttpClientTests
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
    }

    [Test]
    public async Task TestGetAllPeople()
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:3000/")
        };

        var result = await client.GetAsync("people/");

        Assert.That(result.IsSuccessStatusCode);

        var stringResult = await result.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var people = JsonSerializer.Deserialize<IList<Person>>(stringResult, options);

        Assert.That(people, Is.Not.Null);
        Assert.That(people.Count, Is.EqualTo(2));

        var firstPerson = people[0];

        Assert.That(firstPerson.Name, Is.EqualTo("Bob Smith"));
        Assert.That(firstPerson.Age, Is.EqualTo(42));
        Assert.That(firstPerson.Id, Is.EqualTo("e330"));
    }
}