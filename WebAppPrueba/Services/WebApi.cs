using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppPrueba.Models;

namespace WEBapi.Services
{
    public class WebApi : IWebApi
    {
        private readonly HttpClient _httpClient;
        public WebApi(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<string> GetToken(string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "login");

            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "username:admin", "password:admin2"}
            });
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);


            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);

            return authResult.AccessToken;
         }

        public Task<string> GetUsers()
        {
            throw new NotImplementedException();
        }
    }

    
}