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
        GetGenus,

        //Admin, God
        EditFamily,
        RemoveUser,

        //God
        UserToAdmin,
        AdminToUser
    }
}
