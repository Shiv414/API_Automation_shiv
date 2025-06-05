//namespace API_Automation_shiv;

using NUnit.Framework;
using Newtonsoft.Json;
namespace API_Automation_shiv;

[TestFixture]
public class CacheTests
{
    private CacheClient _client;
    private const string TestKey = "SampleKey";

    [SetUp]
    public void SetUp()
    {
        _client = new CacheClient();
    }

    [Test, Order(1)]
    public void PostDataTest()
    {
        var payload = new CacheTestRequest
        {
            Key = TestKey,
            Ttl = 400,
            Value = new CacheTestRequest.ValueData
            {
                UserId = 101,
                Name = "pankaj",
                Role = "Tester"
            }
        };

        var response = _client.PostData(payload);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
    }

    [Test, Order(2)]
    public void GetDataTest()
    {
        var response = _client.GetData(TestKey);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));

        var data = JsonConvert.DeserializeObject<CacheTestResponse>(response.Content);
        Assert.That(data.Value.Name, Is.EqualTo("pankaj"));
        Assert.That(data.Value.UserId, Is.EqualTo(101));
    }

    [Test, Order(3)]
    public void DeleteDataTest()
    {
        var response = _client.DeleteData(TestKey);
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
    }
}

