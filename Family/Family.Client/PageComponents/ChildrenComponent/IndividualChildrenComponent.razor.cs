using Family.Db.Entities.Web;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.ChildrenComponent
{
    public partial class IndividualChildrenComponent
    {
        [Parameter] public Child Child { get; set; } = new();

        public string Status { get; set; } = nameof(Child);
    }
}
