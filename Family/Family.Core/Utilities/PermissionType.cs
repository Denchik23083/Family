namespace Family.Core.Utilities
{
    public enum PermissionType
    {
        //User, Child, ParentChild, Admin, God
        GetInfo,
        CreateGenus,

        //Child, ParentChild, Admin, God
        GetChild,
        GetGenus,

        //ParentChild, Admin, God
        GetParent,
        EditDeleteGenus,

        //Admin, God
        RemoveUser,

        //God
        UserToAdmin,
        AdminToUser
    }
}
