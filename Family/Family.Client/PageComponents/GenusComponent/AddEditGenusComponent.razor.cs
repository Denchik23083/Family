using Family.Core.Utilities;
using Family.Db.Entities;
using Family.Http.ChildrenHttpService;
using Family.Http.GenusHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.GenusComponent
{
    public partial class AddEditGenusComponent
    {
        [Parameter] public int GenusId { get; set; }

        [Parameter] public bool Edit { get; set; }

        [Parameter] public bool Add { get; set; }

        [Inject] public IGenusHttpService GenusHttpService { get; set; }

        [Inject] public IChildrenHttpService ChildrenHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Genus Genus { get; set; } = new();

        public List<Parent> Mothers { get; set; } = new();

        public List<Parent> Fathers { get; set; } = new();

        public List<Child> Children { get; set; } = new();
        
        public List<Child> SelectedChildren = new();

        public bool IsShow { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (GenusId == 0)
            {
                Genus = new Genus();

                var parentsEnumerable = await GenusHttpService.GetAllGenusParents();
                var parents = parentsEnumerable.ToList();
                Mothers = parents.Where(b => b.Gender.Type == GenderType.Female).ToList();
                Fathers = parents.Where(b => b.Gender.Type == GenderType.Male).ToList();

                var children = await GenusHttpService.GetAllGenusChildren();
                Children = children.ToList();
            }
            else
            {
                var parentsEnumerable = await GenusHttpService.GetAllGenusParents();
                var parents = parentsEnumerable.ToList();
                Mothers = parents.Where(b => b.Gender.Type == GenderType.Female).ToList();
                Fathers = parents.Where(b => b.Gender.Type == GenderType.Male).ToList();

                var children = await GenusHttpService.GetAllGenusChildren();
                Children = children.ToList();

                Genus = await GenusHttpService.GetGenus(GenusId);
                //Mothers.Add(Genus.Mother);
                //Fathers.Add(Genus.Father);
                SelectedChildren = Genus.Children;
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
                await GenusHttpService.EditGenus(Genus, GenusId);

                NavigationManager.NavigateTo("/genus");
            }
        }

        public void AddSelectedChild(Child child)
        {
            SelectedChildren.Add(child);

            var item = Children.FirstOrDefault(x => x.Id == child.Id);

            Children.Remove(item);

            Genus.Children = SelectedChildren;
        }

        public void RemoveSelectedChild(Child child)
        {
            var item = SelectedChildren.FirstOrDefault(x => x.Id == child.Id);

            SelectedChildren.Remove(item);

            Children.Add(child);

            Genus.Children = SelectedChildren;
        }
    }
}
