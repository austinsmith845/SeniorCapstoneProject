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
    /// Interaction logic for SimulationSetupScreen.xaml
    /// </summary>
    public partial class SimulationSetupScreen : Window
    {
        public delegate void StartSimulation(bool view);
        StartSimulation commence;
        public SimulationSetupScreen(StartSimulation starter)
        {
            InitializeComponent();
            commence = starter;
        }

        public void StartClick(object sender, RoutedEventArgs e)
        {
            if(rdbSimulation.IsChecked == true)
            {
                commence(true);
            }
            else
            {
                commence(false);
            }
           
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                      
            if (this.cbxAlgorithms.SelectedIndex >= 0)
            {
                this.btnStart.IsEnabled = true;
            }
        }
    }
}
