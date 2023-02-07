using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.Http;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.ChildrenPage
{
    public partial class ChildrenPage
    {
        [Inject] public IChildrenHttpService ChildrenHttpService { get; set; }

        public IEnumerable<Child> Children { get; set; } = new List<Child>();

        protected override async Task OnInitializedAsync()
        {
            Children = await ChildrenHttpService.GetAllChildren();
        }
    }
}
