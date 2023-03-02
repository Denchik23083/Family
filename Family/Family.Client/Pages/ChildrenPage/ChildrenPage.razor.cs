using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.Http.ChildrenHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.ChildrenPage
{
    public partial class ChildrenPage
    {
        [Inject] public IChildrenHttpService ChildrenHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public IEnumerable<Child> Children { get; set; } = new List<Child>();

        protected override async Task OnInitializedAsync()
        {
            Children = await ChildrenHttpService.GetAllChildren();
        }

        /*protected override async Task OnParametersSetAsync()
        {
            Children = await ChildrenHttpService.GetAllChildren();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Children = await ChildrenHttpService.GetAllChildren();
        }*/

        public void RouteToChild(int childId)
        {
            NavigationManager.NavigateTo($"/children/{childId}");
        }
    }
}
