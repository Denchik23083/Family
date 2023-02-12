using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.Http.ParentsHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.ParentsPage
{
    public partial class ParentsDetailsPage
    {
        [Parameter] public int ParentId { get; set; }

        [Inject] public IParentsHttpService ParentsHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Parent Parent { get; set; } = new();

        public IEnumerable<Child> Children { get; set; } = new List<Child>();

        protected override async Task OnInitializedAsync()
        {
            Parent = await ParentsHttpService.GetParent(ParentId);

            Children = await ParentsHttpService.GetParentsChildren(Parent.Id);
        }

        private void RouteToChild(int childId)
        {
            NavigationManager.NavigateTo($"/children/{childId}");
        }
    }
}
