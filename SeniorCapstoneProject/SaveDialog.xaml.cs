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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SaveDialog : Window
    {
        string roomName;
        public delegate void NameEntered(string name);
        public NameEntered callback;

        public SaveDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the save room dialog.
        /// </summary>
        /// <param name="name">The name of the room</param>
        public void ShowDialog(NameEntered caller)
        {
            callback += caller;
            this.Show();
        }

        private void SaveClick(object sender, RoutedEventArgs args)
        {
            roomName = this.txtName.Text;
            if(roomName == string.Empty)
            {
                MessageBox.Show("You must enter a name.");
                return;
            }
           
            callback(roomName);
            this.Close();
                
        }

        private void Save()
        {
            roomName = this.txtName.Text;
            if (roomName == string.Empty)
            {
                MessageBox.Show("You must enter a name.");
                return;
            }

            callback(roomName);
            this.Close();

        }

        private void KeyPressed(object senderd, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Save();
            }
        }
    }
}
