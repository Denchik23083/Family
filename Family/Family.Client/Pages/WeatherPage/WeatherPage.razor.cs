using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Family.Db.Entities;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.WeatherPage
{
    public partial class WeatherPage
    {
        [Inject] public HttpClient HttpClient { get; set; }

        public Weather[] Weather { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Weather = await HttpClient.GetFromJsonAsync<Weather[]>("sample-data/weather.json");

            /*var mainAddress = "https://weather.com/weather/tenday/l/aef1ae844a5a6d6514dd32c8f723d7cd1ad4e49f08085207b5c0b336a9d0116d";

            var config = Configuration.Default.WithDefaultLoader();

            var mainPageDocument = await BrowsingContext.New(config).OpenAsync(mainAddress);

            var doc = mainPageDocument.QuerySelectorAll($"table.table tr td:nth-child()")
                .Select(_ => _.TextContent).ToList();*/
        }
    }
}
