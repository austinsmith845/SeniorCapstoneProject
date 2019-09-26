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
using System.Windows.Shapes;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for FurnitureSetupWindow.xaml
    /// </summary>
    public partial class FurnitureSetupWindow : Window
    {
        public delegate void InformationEntered(string height, string width, string length, int rotation);
        InformationEntered callback;

        public FurnitureSetupWindow()
        {
            InitializeComponent();
        }

        public bool ShowDialog(InformationEntered caller)
        {
            callback += caller;
            this.ShowDialog();
            return false; // to terminate the while loop in the calling furniture.
        }

        private void SaveClick(object sender, RoutedEventArgs args)
        {
            ComboBoxItem item = (ComboBoxItem)cmbRotation.SelectedItem;
            

            callback(txtHeight.Text,txtWidth.Text,txtLength.Text,int.Parse((string)item.Content));
            this.Close();

        }
    }
}
