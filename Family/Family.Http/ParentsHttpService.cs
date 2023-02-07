using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http
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
            var result = await _httpClient.GetAsync("https://localhost:6001/api/Parents");

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(body);
            }

            return JsonSerializer.Deserialize<IEnumerable<Parent>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
