using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.Http;
using Microsoft.AspNetCore.Components;

namespace Family.Display.Pages
{
    public partial class ParentsPage
    {
        [Inject] public IParentHttpRepository ParentHttpRepository { get; set; }

        public IEnumerable<Parent> Parents { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Parents = await ParentHttpRepository.GetAllParents();
        }
    }
}
