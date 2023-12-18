using Family.Db.Entities.Web;
using Family.Http.GenusHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.GenusComponent
{
    public partial class ConfirmRemoveGenusComponent
    {
        [Parameter] public EventCallback OnShow { get; set; }

        [Parameter] public EventCallback OnCancel { get; set; }

        [Parameter] public Genus Genus { get; set; }

        [Parameter] public int GenusId { get; set; }

        [Inject] public IGenusHttpService GenusHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public bool Display { get; set; }

        public void Show() => Display = true;

        public void Hide() => Display = false;

        public void Delete()
        {
            GenusHttpService.DeleteGenus(GenusId);

            NavigationManager.NavigateTo("/genus", true);
        }
    }
}
