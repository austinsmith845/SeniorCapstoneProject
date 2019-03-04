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
    /// Interaction logic for SelectionScreen.xaml
    /// </summary>
    public partial class SelectionScreen : Window
    {
        #region Properties
        private MainWindow _main;
        #endregion
      

        public SelectionScreen(MainWindow win)
        {
            InitializeComponent();
            _main = win;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _main.Show();
        }

        private void ButtonClicked(object sender, RoutedEventArgs args)
        {
            Button btn = (Button)sender;
            if((string)btn.Tag == "Load")
            {
                if (!Simulator.IsRunning)
                {
                    Simulator simulator = new Simulator();
                    simulator.Show();
                }

                else
                {
                    MessageBox.Show("You cannot have more than one instance of the simulator running.","Already running");
                }
            }
             
            else if ((string)btn.Tag == "Create")
            {
                Creator creator = new Creator(false);
                creator.Show();
            }
            
            else if ((string)btn.Tag == "Algorithm")
            {
                MessageBox.Show("Algorithm functionality has not yet been implemented.");
            }
        }
    }
}
