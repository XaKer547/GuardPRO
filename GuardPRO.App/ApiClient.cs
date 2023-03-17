using GuardPRO.API7.Database.Models;
using GuardPRO.App.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuardPRO.App
{
    public class ApiClient
    {
        public const string BASE_URL = "http://localhost:26258";
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            _httpClient = new HttpClient();
        }

        public async Task<Applicant?> Login(int number)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/api/Autorize?number={number}");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            string content = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<Applicant>(content, _jsonOptions);
            return result;
        }

        public async Task<List<Invite>?> GetAllInvites()
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/api/invite");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string content = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<List<Invite>>(content, _jsonOptions);
            return result;
        }

        public async Task<List<Department>?> GetAllDepartment()
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/api/Department");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string content = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<List<Department>>(content, _jsonOptions);
            return result;
        }
    }
}
