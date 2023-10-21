using Family.Db.Entities;
using Family.Http.ChildrenHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.ChildrenComponent
{
    public partial class AddEditChildComponent
    {
        [Parameter] public int ChildId { get; set; }

        [Parameter] public bool Edit { get; set; } = false;

        [Parameter] public bool Add { get; set; } = false;

        [Inject] public IChildrenHttpService ChildrenHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Child Child { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            if (ChildId == 0)
            {
                Child = new Child();
            }
            else
            {
                Child = await ChildrenHttpService.GetChild(ChildId);
            }
        }

        public async Task Submit()
        {
            if (Add)
            {
                await ChildrenHttpService.CreateChild(Child);

                NavigationManager.NavigateTo("/children");
            }
            if (Edit)
            {
                await ChildrenHttpService.EditChild(Child, ChildId);

                NavigationManager.NavigateTo("/children");
            }
        }
    }
}
