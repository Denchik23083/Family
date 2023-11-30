namespace Family.Core.Utilities
{
    public enum PermissionType
    {
        //User, Child, Parent, Admin, God
        GetInfo,

        //User, Admin, God
        CreateGenus,

        //Child, Parent, Admin, God
        GetChild,
        
        //Parent, Admin, God
        GetParent,
        GetGenus,
        UpdateDeleteGenus,

        //Admin, God
        DeleteUser,

        //God
        UserToAdmin,
        AdminToUser
    }
}
