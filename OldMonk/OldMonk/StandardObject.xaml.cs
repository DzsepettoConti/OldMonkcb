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

namespace OldMonk
{
    /// <summary>
    /// Interaction logic for StandardObject.xaml
    /// </summary>
    public partial class StandardObject : UserControl
    {
        public StandardObject(string imagePath, string buttonText)
        {
            InitializeComponent();
            ButtonImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            ImageButton.Content = buttonText;
        }
    }
}

