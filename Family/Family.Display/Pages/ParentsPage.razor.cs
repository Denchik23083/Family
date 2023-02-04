using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Family.Db.Entities;
using Microsoft.AspNetCore.Components;

namespace Family.Display.Pages
{
    public partial class ParentsPage
    {
        [Inject] public HttpClient HttpClient { get; set; }

        public IEnumerable<Parent> Parents { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await HttpClient.GetAsync("https://localhost:6001/api/Parents");

            var body = await result.Content.ReadAsStringAsync();

            Parents = JsonSerializer.Deserialize<IEnumerable<Parent>>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
