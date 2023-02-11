﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.Http.ParentsHttpService;
using Microsoft.AspNetCore.Components;

namespace Family.Client.Pages.ParentsPage
{
    public partial class ParentsPage
    {
        [Inject] public IParentsHttpService ParentsHttpService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        public IEnumerable<Parent> Parents { get; set; } = new List<Parent>();

        protected override async Task OnInitializedAsync()
        {
            Parents = await ParentsHttpService.GetAllParents();
        }

        public void RouteId(int parentId)
        {
            NavigationManager.NavigateTo($"/parents/{parentId}");
        }
    }
}
