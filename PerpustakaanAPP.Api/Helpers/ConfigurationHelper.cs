namespace PerpustakaanAPP.Api.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration Config = new ConfigurationBuilder().Build();
        public static void Initialize(IConfiguration Configuration)
        {
            Config = Configuration;
        }
    }
}
