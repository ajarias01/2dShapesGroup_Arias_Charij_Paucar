using ShapesApp.Forms;

namespace _2dShapesGroup
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // High DPI and default font configuration
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmHome());
        }
    }
}
