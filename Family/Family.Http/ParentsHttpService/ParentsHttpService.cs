using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.ParentsHttpService
{
    public class ParentsHttpService : IParentsHttpService
    {
        private readonly HttpClient _httpClient;

        public ParentsHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Parent>> GetAllParents()
        {
            var body = await GetData("https://localhost:6001/api/Parents");

            return JsonSerializer.Deserialize<IEnumerable<Parent>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Child>> GetParentsChildren(int parentId)
        {
            var body = await GetData($"https://localhost:6001/api/ParentsChildren/id?id={parentId}");

            return JsonSerializer.Deserialize<IEnumerable<Child>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Parent> GetParent(int parentId)
        {
            var body = await GetData($"https://localhost:6001/api/Parents/id?id={parentId}");

            return JsonSerializer.Deserialize<Parent>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private async Task<string> GetData(string requestUrl)
        {
            var result = await _httpClient.GetAsync(requestUrl);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(body);
            }

            return body;
        }
    }
}
