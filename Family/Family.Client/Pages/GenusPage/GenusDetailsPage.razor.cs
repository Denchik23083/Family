using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Core;
using Family.Db.Entities;
using Family.Http.GenusHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.GenusPage
{
    public partial class GenusDetailsPage
    {
        [Parameter] public int GenusId { get; set; }

        [Inject] public IGenusHttpService GenusHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Genus Parents { get; set; } = new()
        {
            Father = new() { Gender = new() { GenderType = GenderType.Undefined } },
            Mother = new() { Gender = new() { GenderType = GenderType.Undefined } }
        };

        public IEnumerable<Child> Children { get; set; } = new List<Child>();

        protected override async Task OnInitializedAsync()
        {
            Parents = await GenusHttpService.GetGenusParents(GenusId);

            Children = await GenusHttpService.GetGenusChildren(GenusId);
        }

        public void RouteToFather(int fatherId)
        {
            NavigationManager.NavigateTo($"/parents/{fatherId}");
        }

        public void RouteToMother(int motherId)
        {
            NavigationManager.NavigateTo($"/parents/{motherId}");
        }

        public void RouteToChild(int childId)
        {
            NavigationManager.NavigateTo($"/children/{childId}");
        }
    }
}
