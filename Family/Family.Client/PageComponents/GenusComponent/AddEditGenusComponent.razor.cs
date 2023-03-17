﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Family.Core;
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

        public bool IsShow { get; set; }

        [Inject] public IGenusHttpService GenusHttpService { get; set; }

        [Inject] public IChildrenHttpService ChildrenHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public Genus Genus { get; set; } = new();

        public IEnumerable<Parent> Mothers { get; set; } = new List<Parent>()
        {
            new Parent { Id = 1, FirstName = "Hallo", LastName = "Hallo", Age = 21, GenderId = 1 }
        };

        public IEnumerable<Parent> Fathers { get; set; } = new List<Parent>()
        {
            new Parent { Id = 2, FirstName = "Hallo", LastName = "Hallo", Age = 21, GenderId = 2 }
        };

        public List<Child> Children { get; set; } = new();
        
        public List<Child> SelectedChildren = new();

        protected override async Task OnInitializedAsync()
        {
            if (GenusId == 0)
            {
                Genus = new Genus();
                var children = await ChildrenHttpService.GetAllChildren();
                Children = children.ToList();
            }
            else
            {
                var children = await ChildrenHttpService.GetAllChildren();
                Children = children.ToList();
                //Genus = await ParentsHttpService.GetParent(ParentId);
                //var parents = await GenusHttpService.GetAllMothers();
                //Mothers = parents.Where(b => b.Gender.GenderType == GenderType.Female);
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
