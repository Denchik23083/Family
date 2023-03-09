using Family.Db.Entities;
using Microsoft.AspNetCore.Components;

namespace Family.Client.PageComponents.GenusComponent
{
    public partial class IndividualGenusComponent
    {
        [Parameter] public Genus Genus { get; set; }
    }
}
