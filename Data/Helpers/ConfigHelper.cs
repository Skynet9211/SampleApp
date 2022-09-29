namespace SampleApp.Data
{
    public class ConfigHelper
    {
        private static readonly IConfigurationRoot root;

        static ConfigHelper()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            root = builder.Build();
        }

        /// <summary>
        /// Usage: Get("Section:FirstKey")
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return root[key];
        }

        /// <summary>
        /// Get section
        /// Usage: GetSection("SectionKey")["Key"]
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IConfigurationSection GetSection(string key)
        {
            return root.GetSection(key);
        }


        /// <summary>
        /// Get ConnectionString
        /// Usage: GetConnectionString("DefaultConnection")
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return root.GetConnectionString(key);
        }
    }
}
