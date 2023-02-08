using System;
using System.Collections.Generic;
using System.Net.Http;
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
            var result = await _httpClient.GetAsync("https://localhost:6001/api/Children");

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(body);
            }

            return JsonSerializer.Deserialize<IEnumerable<Child>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
