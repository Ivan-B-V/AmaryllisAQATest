using Core.Models;
using Core.Utilities;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http.Json;
using System.Text;

namespace Core.HttpApiClient;

public class HttpApiClient
{
    protected HttpClient client;

    public HttpApiClient()
    {
        client = new HttpClient()
        {
            BaseAddress = new Uri(Settings.PetStoreBaseUrl),
            Timeout = Settings.WaitTime,
        };
    }

    public HttpResponseMessage ExecutePostRequest(string resource, Dictionary<string, string> parameters, object? body)
    {
        var response = client.Send(GetRequestMessage(resource, HttpMethod.Post, parameters, body));
        return response;
    }

    public HttpResponseMessage ExecutePutRequest(string resource, Dictionary<string, string> parameters, object? body)
    {
        var response = client.Send(GetRequestMessage(resource, HttpMethod.Put, parameters, body));
        return response;
    }

    public HttpResponseMessage ExecuteDeleteRequest(string resource)
    {
        var response = client.Send(GetRequestMessage(resource, HttpMethod.Delete, null, null));
        return response;
    }

    public HttpResponseMessage ExecuteGetRequest(string resource)
    {
        var response = client.Send(GetRequestMessage(resource, HttpMethod.Get, null, null));
        return response;
    }

    private ApiSettings Settings => ConfigurationReader.GetApiSettings();


    private HttpRequestMessage GetRequestMessage(string resource, HttpMethod method, Dictionary<string, string> parameters, object? body)
    {
        var requestUri = resource;
        if (parameters != null)
        {
            requestUri = QueryHelpers.AddQueryString(requestUri, parameters);

        }

        HttpRequestMessage request = new()
        {
            RequestUri = new Uri(requestUri, UriKind.RelativeOrAbsolute),
            Method = method
        };

        if (body is not null)
        {
            //var cont = JsonConvert.SerializeObject(body, new StringEnumConverter());
            //request.Content = new StringContent(cont, Encoding.UTF8, "application/json");
            request.Content = JsonContent.Create(body);
        }
        return request;
    }
}