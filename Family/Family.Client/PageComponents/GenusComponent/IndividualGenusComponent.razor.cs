using Family.Db.Entities.Web;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.GenusComponent
{
    public partial class IndividualGenusComponent
    {
        [Parameter] public Genus Genus { get; set; }
    }
}
