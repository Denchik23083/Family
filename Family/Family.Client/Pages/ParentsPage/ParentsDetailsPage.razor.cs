using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Client.PageComponents.ParentsComponent;
using Family.Core;
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

        public Parent Parent { get; set; } = new() { Gender = new() { GenderType = GenderType.Undefined } };

        public IEnumerable<Child> Children { get; set; } = new List<Child>();

        public ConfirmRemoveParentComponent ConfirmRemoveParentComponent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Parent = await ParentsHttpService.GetParent(ParentId);
            
            Children = await ParentsHttpService.GetParentsChildren(Parent.Id);
        }

        public void RouteToChild(int childId)
        {
            NavigationManager.NavigateTo($"/children/{childId}");
        }

        public void Edit()
        {
            NavigationManager.NavigateTo($"/parents/{Parent.Id}/edit");
        }

        public void OnShow() => ConfirmRemoveParentComponent.Show();

        public void OnCancel() => ConfirmRemoveParentComponent.Hide();
    }
}
