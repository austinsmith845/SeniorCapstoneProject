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
    /// Interaction logic for EndSimulation.xaml
    /// </summary>
    public partial class EndSimulation : Window
    {
        public EndSimulation(string reason)
        {
            InitializeComponent();
            lblEnded.Content += "\t " + reason;
        }

        public EndSimulation(string reason, IStatistics stats) : this(reason)
        {
            InitializeComponent();
            DisplayStatistics(stats);
            
        }

        private void DisplayStatistics(IStatistics stats)
        {
            string TimeTaken = string.Format("{1:00}:{0:00}", stats.TimeTaken % 60, stats.TimeTaken / 60);
            this.lblThisRunStats.Content = String.Format("Time Taken: \t {0}\nCoverage: \t {1:0.000}%\nAlgorithm: \t {2}", TimeTaken, stats.Coverage, stats.Algorithm); 
        }
    }
}
