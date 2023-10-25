namespace Family.Core.Utilities
{
    public enum PermissionType
    {
        //User, Child, ParentChild, Admin, God
        GetInfo,

        //Child, ParentChild, Admin, God
        GetChild,

        //ParentChild, Admin, God
        GetParent,
        CrudGenus,

        //Admin, God
        RemoveUser,

        //God
        UserToAdmin,
        AdminToUser
    }
}
