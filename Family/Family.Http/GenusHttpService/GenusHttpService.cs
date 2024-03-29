﻿using System.Net.Http.Json;
using System.Text.Json;
using Family.Db.Entities.Web;

namespace Family.Http.GenusHttpService
{
    public class GenusHttpService : IGenusHttpService
    {
        private readonly HttpClient _httpClient;

        public GenusHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Genus>> GetAllGenus()
        {
            var body = await GetData("https://localhost:6001/api/Genus");

            return JsonSerializer.Deserialize<IEnumerable<Genus>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<IEnumerable<Parent>> GetAllGenusParents()
        {
            var body = await GetData("https://localhost:6001/api/GenusParents");

            return JsonSerializer.Deserialize<IEnumerable<Parent>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<IEnumerable<Child>> GetAllGenusChildren()
        {
            var body = await GetData("https://localhost:6001/api/GenusChildren");

            return JsonSerializer.Deserialize<IEnumerable<Child>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<Genus> GetGenus(int genusId)
        {
            var body = await GetData($"https://localhost:6001/api/Genus/id?id={genusId}");

            return JsonSerializer.Deserialize<Genus>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task CreateGenus(Genus createdGenus)
        {
            var content = JsonContent.Create(createdGenus);

            await _httpClient.PostAsync("https://localhost:6001/api/Genus", content);
        }

        public async Task EditGenus(Genus editedGenus, int genusId)
        {
            var content = JsonContent.Create(editedGenus);

            await _httpClient.PutAsync($"https://localhost:6001/api/Genus/id?id={genusId}", content);
        }

        public async Task DeleteGenus(int genusId)
        {
            await _httpClient.DeleteAsync($"https://localhost:6001/api/Genus/id?id={genusId}");
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
