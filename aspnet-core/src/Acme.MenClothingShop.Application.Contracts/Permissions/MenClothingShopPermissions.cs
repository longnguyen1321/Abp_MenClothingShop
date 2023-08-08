namespace Acme.MenClothingShop.Permissions;

public static class MenClothingShopPermissions
{
    public const string GroupName = "MenClothingShop";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Clothes
    {
        public const string Default = GroupName + ".Clothes";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Exports
    {
        public const string Default = GroupName + ".Exports";
        public const string Create = Default + ".Create";
        public const string Cancel = GroupName + ".Cancel";
    }
}
