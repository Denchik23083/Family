using Family.Core.Utilities;

namespace Family.Db.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public RoleType? RoleType { get; set; }

        public List<RolePermission>? RolePermission { get; set; }
    }
}
