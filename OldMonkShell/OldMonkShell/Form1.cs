namespace OldMonkShell
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;

        public Form1()
        {
            // Initialize NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("C:\\Users\\uif79177\\source\\repos\\OldMonkShell\\OldMonkShell\\monk.ico"); // Add your icon file path here
            notifyIcon.Text = "My Tray App";
            notifyIcon.Visible = true;

            // Initialize ContextMenu
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Restore", null, Restore);
            contextMenu.Items.Add("Exit", null, Exit);

            notifyIcon.ContextMenuStrip = contextMenu;

            // Handle double-click event
            notifyIcon.DoubleClick += (sender, e) => Restore(sender, e);

            // Handle form resize event
            this.Resize += (sender, e) =>
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                }
            };
        }

        private void Restore(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
