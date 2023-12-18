using Family.Core.Utilities;

namespace Family.Db.Entities.Auth
{
    public class Role
    {
        public int Id { get; set; }

        public RoleType? RoleType { get; set; }

        public List<RolePermission>? RolePermissions { get; set; }
    }
}
