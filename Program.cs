using StudyCenter.Models;

namespace StudyCenter
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

            var dbContext = new StudyCenterContext();

            Application.Run(new Frm_StudyCenter(dbContext));
        }
    }
}