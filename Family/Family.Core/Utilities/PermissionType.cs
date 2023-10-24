namespace Family.Core.Utilities
{
    public enum PermissionType
    {
        //User, Child, Parent, Admin, God
        GetInfo,

        //Child, Parent, Admin, God
        GetChild,

        //Parent, Admin, God
        GetParent,
        CrudGenus,

        //Admin, God
        RemoveUser,

        //God
        UserToAdmin,
        AdminToUser
    }
}
