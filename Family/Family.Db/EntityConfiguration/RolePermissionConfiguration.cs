using Family.Core.Utilities;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Family.Db.EntityConfiguration
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.PermissionType).HasConversion<int>();

            builder.HasOne(_ => _.Role)
                .WithMany(_ => _.RolePermissions)
                .HasForeignKey(_ => _.RoleId);

            builder.ToTable("RolePermissions").HasData(
                new RolePermission
                {
                    Id = 1,
                    RoleId = 1,
                    PermissionType = PermissionType.GetInfo
                },
                new RolePermission
                {
                    Id = 2,
                    RoleId = 1,
                    PermissionType = PermissionType.GetChild
                },
                new RolePermission
                {
                    Id = 3,
                    RoleId = 1,
                    PermissionType = PermissionType.GetParent
                },
                new RolePermission
                {
                    Id = 4,
                    RoleId = 1,
                    PermissionType = PermissionType.CrudGenus
                },
                new RolePermission
                {
                    Id = 5,
                    RoleId = 1,
                    PermissionType = PermissionType.RemoveUser
                },
                new RolePermission
                {
                    Id = 6,
                    RoleId = 1,
                    PermissionType = PermissionType.UserToAdmin
                },
                new RolePermission
                {
                    Id = 7,
                    RoleId = 1,
                    PermissionType = PermissionType.AdminToUser
                },
                new RolePermission
                {
                    Id = 8,
                    RoleId = 2,
                    PermissionType = PermissionType.GetInfo
                },
                new RolePermission
                {
                    Id = 9,
                    RoleId = 2,
                    PermissionType = PermissionType.GetChild
                },
                new RolePermission
                {
                    Id = 10,
                    RoleId = 2,
                    PermissionType = PermissionType.GetParent
                },
                new RolePermission
                {
                    Id = 11,
                    RoleId = 2,
                    PermissionType = PermissionType.CrudGenus
                },
                new RolePermission
                {
                    Id = 12,
                    RoleId = 2,
                    PermissionType = PermissionType.RemoveUser
                },
                new RolePermission
                {
                    Id = 13,
                    RoleId = 3,
                    PermissionType = PermissionType.GetInfo
                },
                new RolePermission
                {
                    Id = 14,
                    RoleId = 3,
                    PermissionType = PermissionType.GetChild
                },
                new RolePermission
                {
                    Id = 15,
                    RoleId = 3,
                    PermissionType = PermissionType.GetParent
                },
                new RolePermission
                {
                    Id = 16,
                    RoleId = 3,
                    PermissionType = PermissionType.CrudGenus
                },
                new RolePermission
                {
                    Id = 17,
                    RoleId = 4,
                    PermissionType = PermissionType.GetInfo
                },
                new RolePermission
                {
                    Id = 18,
                    RoleId = 4,
                    PermissionType = PermissionType.GetChild
                },
                new RolePermission
                {
                    Id = 19,
                    RoleId = 5,
                    PermissionType = PermissionType.GetInfo
                });
        }
    }
}
