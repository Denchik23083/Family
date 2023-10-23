using Family.Client.PageComponents.GenusComponent;
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

        public Genus Genus { get; set; } = new()
        {
            //Father = new() { Gender = new() },
            //Mother = new() { Gender = new() },
            Children = new List<Child>()
        };

        public ConfirmRemoveGenusComponent ConfirmRemoveGenusComponent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Genus = await GenusHttpService.GetGenus(GenusId);
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

        public void Edit()
        {
            NavigationManager.NavigateTo($"/genus/{Genus.Id}/edit");
        }

        public void OnShow() => ConfirmRemoveGenusComponent.Show();

        public void OnCancel() => ConfirmRemoveGenusComponent.Hide();
    }
}
