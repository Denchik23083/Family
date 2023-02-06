using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http
{
    public class ParentHttpRepository : IParentHttpRepository
    {
        private readonly HttpClient _client;

        public ParentHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Parent>> GetAllParents()
        {
            var response = await _client.GetAsync("products");
            var content = await response.Content.ReadAsStringAsync();

            var result = await _client.GetAsync("https://localhost:6001/api/Parents");

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<IEnumerable<Parent>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
