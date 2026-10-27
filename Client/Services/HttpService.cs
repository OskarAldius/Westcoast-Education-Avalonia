using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Media;
using Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Client.Services;

public class HttpService<T> : IDisposable, IHttpService<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = string.Empty;

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    public HttpService()
    {
        var config = new ConfigurationBuilder().AddJsonFile("UrlAndKey.json").Build();

        var apiKey = config.GetSection("Settings:ApiKey").Value!;
        _baseUrl = config.GetSection("Settings:BaseUrl").Value!;
        _httpClient = new()
        {
            BaseAddress = new Uri(_baseUrl)
        };
        _httpClient.DefaultRequestHeaders.Add("Cache-Control", "none");
        _httpClient.DefaultRequestHeaders.Add("x-apikey", apiKey);

    }
    public Task Delete(string resource, string id)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<System.Collections.Generic.List<T>> Get(string resource)
    {
        throw new NotImplementedException();
    }

    public Task<T> Get(string resource, string predicate)
    {
        throw new NotImplementedException();
    }

    public Task Post(string resource, T data)
    {
        throw new NotImplementedException();
    }

    public Task Put(string resource, T data, string objectId)
    {
        throw new NotImplementedException();
    }
}
