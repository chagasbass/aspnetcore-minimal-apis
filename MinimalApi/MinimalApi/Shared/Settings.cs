using System.Text;

namespace MinimalApi.Shared
{
    public static class Settings
    {
        static readonly string Secret = "f1a146274a3a415bb069a24ce4ef47e9";
        static readonly string RoleAdmin = "Admin";
        static readonly string RoleUser = "User";

        public static byte[] GetSecretArray()
        {
            return Encoding.ASCII.GetBytes(Secret);
        }

        public static string GetSecret()
        {
            return Secret;
        }

        public static string GetRoleAdmin() => RoleAdmin;
        public static string GetRoleUser() => RoleUser;
    }
}
