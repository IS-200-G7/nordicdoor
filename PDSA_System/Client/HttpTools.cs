using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PDSA_System.Client;

public class HttpTools
{
    [Inject]
    public static IJSRuntime JSRuntime { get; set; }

    public HttpTools(IJSRuntime jsRuntime)
    {
        JSRuntime = jsRuntime;
    }

    public static string GetFromLocalStorage(string key)
    {
        return JSRuntime.InvokeAsync<string>("localStorage.getItem", key).Result;
    }

    public bool SetToLocalStorage(string key, string value)
    {
        return JSRuntime.InvokeAsync<bool>("localStorage.setItem", key, value).Result;
    }

    public static async Task<TValue?> PostWithAuth<TValue>(string url, object data)
    {
        var token = GetFromLocalStorage("token");
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.PostAsync(url, new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"));
        return JsonSerializer.Deserialize<TValue>(response.Content.ReadAsStringAsync().Result);
    }

    public static async Task<TValue?> GetWithAuth<TValue>(string url)
    {
        var token = GetFromLocalStorage("token");
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.GetAsync(url);
        return JsonSerializer.Deserialize<TValue>(response.Content.ReadAsStringAsync().Result);
    }
}
