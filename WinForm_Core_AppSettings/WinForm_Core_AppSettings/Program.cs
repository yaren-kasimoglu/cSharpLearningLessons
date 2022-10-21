using Microsoft.Extensions.Configuration;


namespace WinForm_Core_AppSettings
{
    internal static class Program
    {
        public static IConfiguration config { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


             config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}