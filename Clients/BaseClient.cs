using RestSharp;

public class BaseClient
{
    protected RestClient client;

    public BaseClient(string baseUrl)
    {
        client = new RestClient(baseUrl);
    }

    protected RestRequest CreateRequest(Method method, string resource = "")
    {
        var request = new RestRequest(resource, method);
        request.AddHeader("Content-Type", "application/json");
        return request;
    }
}

