using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace OldMonk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.NotifyIcon notifyIcon;
        public MainWindow()
        {
            InitializeComponent();
            //this.Hide();
            LoadObjects();

            notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Icon = new System.Drawing.Icon("monk.ico"),
                Visible = true,
                Text = "OldMonkWPF"
            };


            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_Click);


            System.Windows.Forms.ContextMenu notifyIconContextMenu = new System.Windows.Forms.ContextMenu();

            notifyIconContextMenu.MenuItems.Add("Connect", new EventHandler(Connect_Click));
            notifyIconContextMenu.MenuItems.Add("Disonnect", new EventHandler(Disconnect_Click));
            notifyIconContextMenu.MenuItems.Add("Edit", new EventHandler(Edit_Click));
            notifyIconContextMenu.MenuItems.Add("Exit", new EventHandler(Exit_Click));

            notifyIcon.ContextMenu = notifyIconContextMenu;

        }
        private void Connect_Click(object sender, EventArgs e)
        {
            string titlemsg = "Bot Connected";
            string msgBody = "OldMonk has succesfully connected to your twitch chat";

            Bot_StatusMsg(titlemsg, msgBody);

        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
            string titlemsg = "Bot Disconnected";
            string msgBody = "OldMonk has succesfully disconnected from your twitch chat";
            Bot_StatusMsg(titlemsg, msgBody);

        }
        private void Edit_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
        }
        private void Exit_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void Bot_StatusMsg(string Title, string Msg)
        {

            notifyIcon.ShowBalloonTip(500, Title, Msg, System.Windows.Forms.ToolTipIcon.Info);

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NewItemWindow niw = new NewItemWindow();
            niw.Show();

        }


        private void LoadObjects()
        {
            string exeDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string dest = System.IO.Path.Combine(exeDirectory, "Items");
            string csvFile = System.IO.Path.Combine(dest, "Items.csv");

            var items = ProcessCsv(csvFile);  // CSV fájl beolvasása és feldolgozása

            foreach (var item in items)
            {
                // Minden elemhez létrehozunk egy StandardObject kontrollt
                var control = new StandardObject(item.Key, item.Value);
                control.Width = 100; // kisebb, hogy a margin + width = pont kiférjen
                control.Margin = new Thickness(10); // 10px térköz minden oldalra
                MainWrapPanel.Children.Add(control);
            }
        }

        // CSV fájl feldolgozása
        private Dictionary<string, string> ProcessCsv(string csvFile)
        {
            var result = new Dictionary<string, string>();

            if (File.Exists(csvFile))
            {
                foreach (var line in File.ReadLines(csvFile))
                {
                    var parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        var itemPath = parts[0].Trim();
                        var itemName = parts[1].Trim();
                        Debug.WriteLine(itemName, itemPath);

                        result[itemName] = itemPath;
                    }
                }
            }

            return result;
        }


    }
}
