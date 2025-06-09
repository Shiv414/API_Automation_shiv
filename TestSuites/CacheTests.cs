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


    [Test, Order(0)]
    [Ignore("This test will be skipped, because it's not implemented yet")]
    public void InvalidToken_ShouldReturnUnauthorized()
    {
        // Temporarily set an invalid token
        var originalToken = Config.Token;
        Config.Token = "invalid_token";

        var response = _client.GetData(TestKey);
        Console.WriteLine($"INVALID TOKEN StatusCode: {(int)response.StatusCode}");
        Console.WriteLine($"INVALID TOKEN Response Content: {response.Content}");

        Assert.That((int)response.StatusCode, Is.EqualTo(401)); // Or whatever your API returns for unauthorized

        // Restore the original token
        Config.Token = originalToken;
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
                Name = "Shubham",
                Role = "Tester"
            }
        };

        var response = _client.PostData(payload);
        Console.WriteLine($"POST StatusCode: {(int)response.StatusCode}");
        Console.WriteLine($"POST Response Content: {response.Content}");

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
    }

    [Test, Order(2)]
    public void GetDataTest()
    {
        var response = _client.GetData(TestKey);
        Console.WriteLine($"GET StatusCode: {(int)response.StatusCode}");
        Console.WriteLine($"GET Response Content: {response.Content}");

        Assert.That((int)response.StatusCode, Is.EqualTo(200));

        var data = JsonConvert.DeserializeObject<CacheTestResponse>(response.Content);
        Console.WriteLine($"GET Deserialized Name: {data.Value.Name}");
        Console.WriteLine($"GET Deserialized UserId: {data.Value.UserId}");

        // Adjust expected values if you want to check the updated values after PUT
        Assert.That(data.Value.Name, Is.EqualTo("Shubham"));
        Assert.That(data.Value.UserId, Is.EqualTo(101));
    }





    [Test, Order(3)]
    public void DeleteDataTest()
    {
        var response = _client.DeleteData(TestKey);
        Console.WriteLine($"DELETE StatusCode: {(int)response.StatusCode}");
        Console.WriteLine($"DELETE Response Content: {response.Content}");

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
    }


 [Test, Order(4)]
    [Ignore("This test will be skipped, because it's not implemented yet")]
    public void PutDataTest()
    {
        var payload = new CacheTestRequest
        {
            Key = TestKey,
            Ttl = 400,
            Value = new CacheTestRequest.ValueData
            {
                UserId = 202,
                Name = "UpdatedUser",
                Role = "Lead"
            }
        };

        var response = _client.PutData(payload);
        Console.WriteLine($"PUT StatusCode: {(int)response.StatusCode}");
        Console.WriteLine($"PUT Response Content: {response.Content}");

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
    }
}
