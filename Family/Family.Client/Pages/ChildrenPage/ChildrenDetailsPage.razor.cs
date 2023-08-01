using Family.Client.PageComponents.ChildrenComponent;
using Family.Core;
using Family.Db.Entities;
using Family.Http.ChildrenHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.ChildrenPage
{
    public partial class ChildrenDetailsPage
    {
        [Parameter] public int ChildId { get; set; }

        [Inject] public IChildrenHttpService ChildrenHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Child Child { get; set; } = new() { Gender = new() { GenderType = GenderType.Undefined } };

        public IEnumerable<Parent> Parents { get; set; } = new List<Parent>();

        public ConfirmRemoveChildComponent ConfirmRemoveChildComponent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Child = await ChildrenHttpService.GetChild(ChildId);

            Parents = await ChildrenHttpService.GetChildrenParents(Child.Id);
        }

        public void RouteToParent(int parentId)
        {
            NavigationManager.NavigateTo($"/parents/{parentId}");
        }

        public void Edit()
        {
            NavigationManager.NavigateTo($"/children/{Child.Id}/edit");
        }

        public void OnShow() => ConfirmRemoveChildComponent.Show();

        public void OnCancel() => ConfirmRemoveChildComponent.Hide();
    }
}
