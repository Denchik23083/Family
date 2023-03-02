using Family.Db.Entities;
using Family.Http.ChildrenHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.ChildrenComponent
{
    public partial class ConfirmRemoveChildComponent
    {
        [Parameter] public EventCallback OnShow { get; set; }

        [Parameter] public EventCallback OnCancel { get; set; }

        [Parameter] public Child Child { get; set; }

        [Parameter] public int ChildId { get; set; }

        [Inject] public IChildrenHttpService ChildrenHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public bool Display { get; set; }

        public void Show() => Display = true;

        public void Hide() => Display = false;

        public void Delete()
        {
            ChildrenHttpService.DeleteChild(ChildId);

            NavigationManager.NavigateTo("/children");
        }
    }
}
