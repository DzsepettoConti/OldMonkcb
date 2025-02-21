using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace OldMonk
{
    /// <summary>
    /// Interaction logic for NewItemWindow.xaml
    /// </summary>
    public partial class NewItemWindow : Window
    {
        public NewItemWindow()
        {
            InitializeComponent();
            ComboBoxController();
        }
        private string _selectedItem = "hang";
        private string _selectedItemPath = "";

        private void ComboBoxController() 
        {
            ComboBoxItem item1 = new ComboBoxItem { Content = "Hang" };
            ComboBoxItem item2 = new ComboBoxItem { Content = "Kép" };
            ComboBoxItem item3 = new ComboBoxItem { Content = "Video" };

            cbSelectType.Items.Add(item1);
            cbSelectType.Items.Add(item2);
            cbSelectType.Items.Add(item3);

            cbSelectType.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbSelectType.SelectedItem;
            string selectedContent = selectedItem.Content.ToString();

            // Switch a kiválasztott elem alapján
            switch (selectedContent)
            {
                case "Hang":
                    _selectedItem = "hang";
                    ifSound();
                    break;

                case "Kép":
                    _selectedItem = "kep";
                    ifPicture();
                    break;

                case "Video":
                    _selectedItem = "video";
                    ifVideo();
                    break;

                default:
                    Debug.WriteLine("Hibás elem lett kiválasztva");
                    break;
            }
            }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedItem == "kep")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Képek

                if (openFileDialog.ShowDialog() == true)
                {
                    string imagePath = openFileDialog.FileName;
                    Debug.WriteLine(imagePath);
                    _selectedItemPath = imagePath;
                    LoadedImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(imagePath));


                    // Kép láthatóvá tétele és videó elrejtése
                    LoadedImage.Visibility = Visibility.Visible;
                    LoadedVideo.Visibility = Visibility.Collapsed;

                }
            }
            if (_selectedItem == "video") 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.mkv"; // Videók

                if (openFileDialog.ShowDialog() == true)
                {
                    string videoPath = openFileDialog.FileName;
                    _selectedItemPath = videoPath;
                    LoadedVideo.Source = new Uri(videoPath);

                    // Videó láthatóvá tétele és kép elrejtése
                    LoadedVideo.Visibility = Visibility.Visible;
                    LoadedImage.Visibility = Visibility.Collapsed;

                    // Videó lejátszása
                    LoadedVideo.Play();
                }
                }
        }


        private void ifSound() 
        {
            lblTitle.Content = "Hang feltöltése";
           
        
        
        }


        private void ifVideo()
        {
            lblTitle.Content = "Video Feltöltése";



        }


        private void ifPicture()
        {
            lblTitle.Content = "Kép feltöltése";



        }

        public void saveSelectedItem() 
        {
            cbSelectType.SelectedItem.ToString().Trim();
            MessageBox.Show(cbSelectType.SelectedItem.ToString().Trim());
        
        }

        private void bntSave_Click(object sender, RoutedEventArgs e)
        {
            saveSelectedItem();
            string source = _selectedItemPath;

            string exeDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string dest = System.IO.Path.Combine(exeDirectory, "Items");

            Console.WriteLine("Az Items mappa elérési útja: " + dest);

            try
            {
                CopyFile(dest, source);
                MessageBox.Show("A kép sikeresen átmásolva");
            }
            catch (Exception)
            {
                MessageBox.Show("A képet nem sikerült átmásolni");

                throw;
            }


        }

        private void CopyFile(string dest, string source) 
        {

                if (!Directory.Exists(dest))
                {
                    Directory.CreateDirectory(dest);
                }

                string destinationFile = System.IO.Path.Combine(dest, System.IO.Path.GetFileName(source));

                File.Copy(source, destinationFile, true);

                Console.WriteLine($"A fájl sikeresen másolva lett: {destinationFile}");

                string newFileName = tbNewName.Text;

                string newDestination = System.IO.Path.Combine(dest, $"{newFileName}.png");

                if (File.Exists(destinationFile))
                {
                    File.Move(destinationFile, newDestination);
                    Console.WriteLine($"A fájl át lett nevezve: {newDestination}");
                }
                else
                {
                    Console.WriteLine("A fájl nem található a megadott helyen.");
                }
        }

    }
}
