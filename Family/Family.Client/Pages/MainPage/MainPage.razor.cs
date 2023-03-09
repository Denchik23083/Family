using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.MainPage
{
    public partial class MainPage
    {
        [Inject] public NavigationManager NavigationManager { get; set; }

        public void AddFamily()
        {
            NavigationManager.NavigateTo("/family/add");
        }

        public void AddParent()
        {
            NavigationManager.NavigateTo("/parents/add");
        }

        public void AddChild()
        {
            NavigationManager.NavigateTo("/children/add");
        }
    }
}
