using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Family.Core;
using Family.Db.Entities;
using Family.Http.GenusHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.GenusComponent
{
    public partial class AddEditGenusComponent
    {
        [Parameter] public int GenusId { get; set; }

        [Parameter] public bool Edit { get; set; } = false;

        [Parameter] public bool Add { get; set; } = false;

        [Inject] public IGenusHttpService GenusHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Genus Genus { get; set; } = new();
        
        public IEnumerable<Parent> Mothers { get; set; } = new List<Parent>();

        public Parent Mother { get; set; } = new() { Gender = new() { GenderType = GenderType.Female }};

        protected override async Task OnInitializedAsync()
        {
            if (GenusId == 0)
            {
                Genus = new Genus();
            }
            else
            {
                //Genus = await ParentsHttpService.GetParent(ParentId);
                var parents = await GenusHttpService.GetAllMothers();
                Mothers = parents.Where(b => b.Gender.GenderType == GenderType.Female);
            }
        }

        public async Task Submit()
        {
            if (Add)
            {
                await GenusHttpService.CreateGenus(Genus);

                NavigationManager.NavigateTo("/genus");
            }
            if (Edit)
            {
                //await ParentsHttpService.EditParent(Parent, ParentId);

                NavigationManager.NavigateTo("/genus");
            }
        }
    }
}
