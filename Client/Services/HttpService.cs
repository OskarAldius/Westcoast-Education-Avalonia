using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Client.Services;

public class HttpService<T> : IDisposable, IHttpService<T> where T : class
{
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
