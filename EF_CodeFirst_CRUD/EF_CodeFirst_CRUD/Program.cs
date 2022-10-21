using EF_CodeFirst_CRUD.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirst_CRUD
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (CrmContext db = new CrmContext())
            {
                db.Database.Migrate();

            }
            Application.Run(new MainForm());
        }
    }
}