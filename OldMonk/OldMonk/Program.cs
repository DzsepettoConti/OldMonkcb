namespace OldMonk
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create the form but do not show it
            Form1 form = new Form1();
            form.ShowInTaskbar = false; // Ensure the form does not show in the taskbar
            form.WindowState = FormWindowState.Minimized; // Minimize the form
            form.Show(); // Show the form to trigger the Load event
            form.Hide(); // Hide the form immediately

            Application.Run();
        }
    }
}