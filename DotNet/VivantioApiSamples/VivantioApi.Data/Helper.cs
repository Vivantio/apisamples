using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace VivantioApi.Data
{
    public static class Helper
    {
        public static void ConfigureHttpClient(HttpClient client, string baseUrl, string username, string password)
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));

            client.BaseAddress = new Uri(baseUrl + "/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        }
    }
}
