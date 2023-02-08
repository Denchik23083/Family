using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.Http.ParentsHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.ParentsPage
{
    public partial class ParentsPage
    {
        [Inject] public IParentsHttpService ParentsHttpService { get; set; }

        public IEnumerable<Parent> Parents { get; set; } = new List<Parent>();

        protected override async Task OnInitializedAsync()
        {
            Parents = await ParentsHttpService.GetAllParents();
        }
    }
}
