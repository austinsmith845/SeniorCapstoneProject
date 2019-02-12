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
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        string _result;
        public delegate void NameEntered(string result);
        public NameEntered callback;

        public DialogBox(string text)
        {
            InitializeComponent();
            this.lblPrompt.Content = text;
        }

        /// <summary>
        /// Shows the save room dialog.
        /// </summary>
        /// <param name="name">The name of the room</param>
        public bool? ShowDialog(NameEntered caller)
        {
            callback += caller;
            return this.ShowDialog();
        }

        private void OkClick(object sender, RoutedEventArgs args)
        {
            _result = this.txtName.Text;
            if (_result == string.Empty)
            {
                MessageBox.Show("You must enter a value.");
                return;
            }

            callback(_result);
            this.Close();

        }

        private void Ok()
        {
            _result = this.txtName.Text;
            if (_result == string.Empty)
            {
                MessageBox.Show("You must enter a value.");
                return;
            }

            callback(_result);
            this.Close();

        }

        private void KeyPressed(object senderd, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ok();
            }
        }
    }
}

