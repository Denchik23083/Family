using Family.Db.Entities;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PagesComponents.ParentsComponent
{
    public partial class IndividualParentsComponent
    {
        [Parameter] public Parent Parent { get; set; } = new();
    }
}
