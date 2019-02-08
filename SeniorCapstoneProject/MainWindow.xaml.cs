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


namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       //Kelli was here
       //walker was here
        public MainWindow()
        {
            InitializeComponent();
        }

      
        private void EnterClicked(Object sender, RoutedEventArgs e )
        {
            SelectionScreen window = new SelectionScreen(this);
            this.Hide();
            window.Show();
        }

    }
}
