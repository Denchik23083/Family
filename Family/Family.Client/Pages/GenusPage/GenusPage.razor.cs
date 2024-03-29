﻿using Family.Db.Entities.Web;
using Family.Http.GenusHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.GenusPage
{
    public partial class GenusPage
    {
        [Inject] public IGenusHttpService GenusHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public IEnumerable<Genus> Genus { get; set; } = new List<Genus>();

        protected override async Task OnInitializedAsync()
        {
            Genus = await GenusHttpService.GetAllGenus();
        }

        public void RouteToGenus(int genusId)
        {
            NavigationManager.NavigateTo($"/genus/{genusId}");
        }
    }
}
