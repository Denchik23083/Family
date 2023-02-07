using Family.Db.Entities;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.ChildrenComponent
{
    public partial class IndividualChildrenComponent
    {
        [Parameter] public Child Child { get; set; }
    }
}
