namespace EasyAbp.IdentityServerAdmin
{
    public static class IdentityServerAdminDbProperties
    {
        public static string DbTablePrefix { get; set; } = "IdentityServerAdmin";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "IdentityServerAdmin";
    }
}
