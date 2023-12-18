using Family.Db.Entities.Web;
using Family.Http.ParentsHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.ParentsComponent
{
    public partial class AddEditParentComponent
    {
        [Parameter] public int ParentId { get; set; }

        [Parameter] public bool Edit { get; set; } = false;

        [Parameter] public bool Add { get; set; } = false;

        [Inject] public IParentsHttpService ParentsHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Parent Parent { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            if (ParentId == 0)
            {
                Parent = new Parent();
            }
            else
            {
                Parent = await ParentsHttpService.GetParent(ParentId);
            }
        }

        public async Task Submit()
        {
            if (Add)
            {
                await ParentsHttpService.CreateParent(Parent);

                NavigationManager.NavigateTo("/parents");
            }
            if (Edit)
            {
                await ParentsHttpService.EditParent(Parent, ParentId);

                NavigationManager.NavigateTo("/parents");
            }
        }
    }
}
