using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.GenusHttpService
{
    public class GenusHttpService : IGenusHttpService
    {
        private readonly HttpClient _httpClient;

        public GenusHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /*public async Task<IEnumerable<Parent>> GetAllParents()
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
        }*/

        public async Task<IEnumerable<Genus>> GetAllGenus()
        {
            var body = await GetData("https://localhost:6001/api/Genus");

            return JsonSerializer.Deserialize<IEnumerable<Genus>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateGenus(Genus createdGenus)
        {
            var content = JsonContent.Create(createdGenus);

            await _httpClient.PostAsync("https://localhost:6001/api/Genus", content);
        }

        /*public async Task EditParent(Parent editedParent, int parentId)
        {
            var content = JsonContent.Create(editedParent);

            await _httpClient.PutAsync($"https://localhost:6001/api/Parents/id?id={parentId}", content);
        }

        public async Task DeleteParent(int parentId)
        {
            await _httpClient.DeleteAsync($"https://localhost:6001/api/Parents/id?id={parentId}");
        }*/

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
