using Family.Db.Entities.Web;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.ParentsComponent
{
    public partial class IndividualParentsComponent
    {
        [Parameter] public Parent Parent { get; set; } = new();

        public string Status { get; set; } = nameof(Parent);
    }
}
