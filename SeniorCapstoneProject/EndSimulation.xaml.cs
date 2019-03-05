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
    }
}
