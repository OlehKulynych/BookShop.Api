namespace BookShop.Web.Static
{
    public static class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:7236";
#endif
        internal readonly static string s_register = $"{ServerBaseUrl}/api/User/Register";
        internal readonly static string s_signIn = $"{ServerBaseUrl}/api/User/signin";
    }
}
