using System.Diagnostics;

namespace OldMonk
{
    public partial class Form1 : Form
    {

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;

        public Form1()
        {
            string iconPath = "D:\\GitHub\\OldMonkcb\\Resources\\Icons\\monk.ico";
            // Initialize NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(iconPath); // Add your icon file path here
            notifyIcon.Text = "My Tray App";
            notifyIcon.Visible = true;

            // Initialize ContextMenu
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Edit", null, Edit);
            contextMenu.Items.Add("Exit", null, Exit);
            contextMenu.Items.Add("Start Bot", null, StartBot);

            notifyIcon.ContextMenuStrip = contextMenu;

            // Handle double-click event
            notifyIcon.DoubleClick += (sender, e) => Edit(sender, e);

            // Handle form resize event
            this.Resize += (sender, e) =>
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                }
            };

            
        }


        private void Edit(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void StartBot(object sender, EventArgs e) 
        {
            string botPath = "example.path";
            Console.WriteLine(botPath);
            string arguments = "-arg1 -arg2"; // Argumentumok

            // ProcessStartInfo beállítása
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName =  botPath;
            startInfo.Arguments = arguments;

            // Process indítása
            Process.Start(startInfo);

            Console.WriteLine("Az exe fájl elindult argumentumokkal.");

        }

    }
}
