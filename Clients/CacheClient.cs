using RestSharp;
using Newtonsoft.Json;

public class CacheClient : BaseClient
{
    public CacheClient() : base(Config.BaseUrl) { }

    public RestResponse PostData(CacheTestRequest body)
    {
        var request = CreateRequest(Method.Post);
        request.AddJsonBody(body);
        return client.Execute(request);
    }

    public RestResponse GetData(string key)
    {
        var request = CreateRequest(Method.Get, $"?key={key}");
        return client.Execute(request);
    }

    public RestResponse DeleteData(string key)
    {
        var request = CreateRequest(Method.Delete, $"?key={key}");
        return client.Execute(request);
    }
}

