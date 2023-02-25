using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.ChildrenHttpService
{
    public class ChildrenHttpService : IChildrenHttpService
    {
        private readonly HttpClient _httpClient;

        public ChildrenHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Child>> GetAllChildren()
        {
            var body = await GetData("https://localhost:6001/api/Children");

            return JsonSerializer.Deserialize<IEnumerable<Child>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Parent>> GetChildrenParents(int childId)
        {
            var body = await GetData($"https://localhost:6001/api/ChildrenParents/id?id={childId}");

            return JsonSerializer.Deserialize<IEnumerable<Parent>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Child> GetChild(int childId)
        {
            var body = await GetData($"https://localhost:6001/api/Children/id?id={childId}");

            return JsonSerializer.Deserialize<Child>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateChild(Child createdChild)
        {
            var content = JsonContent.Create(createdChild);

            await _httpClient.PostAsync("https://localhost:6001/api/Children", content);
        }

        public async Task EditChild(Child editedChild, int childId)
        {
            var content = JsonContent.Create(editedChild);

            await _httpClient.PutAsync($"https://localhost:6001/api/Children/id?id={childId}", content);
        }

        public async Task DeleteChild(int childId)
        {
            await _httpClient.DeleteAsync($"https://localhost:6001/api/Children/id?id={childId}");
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
