using Family.Db.Entities;
using Family.Http.ParentsHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.ParentsComponent
{
    public partial class ConfirmRemoveParentComponent
    {
        [Parameter] public EventCallback OnShow { get; set; }

        [Parameter] public EventCallback OnCancel { get; set; }

        [Parameter] public Parent Parent { get; set; }

        [Parameter] public int ParentId { get; set; }

        [Inject] public IParentsHttpService ParentsHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public bool Display { get; set; }

        public void Show() => Display = true;

        public void Hide() => Display = false;

        public void Delete()
        {
            ParentsHttpService.DeleteParent(ParentId);

            NavigationManager.NavigateTo("/parents", true);
        }
    }
}
