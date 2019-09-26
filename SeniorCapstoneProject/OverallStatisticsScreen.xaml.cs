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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Interaction logic for OverallStatisticsScreen.xaml
    /// </summary>
    public partial class OverallStatisticsScreen : Window
    {
        public OverallStatisticsScreen()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)((ComboBox)sender).SelectedItem;
            GetOverallStatistics((string)item.Tag);
        }

        private void GetOverallStatistics(String currentAlgorithm)
        {
            string[] files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
            IEnumerable<string> statsFile = from string f in files where f.Contains(".rvss") select f;  //Filers out files that are not statistics files. This is a LINQ expression which is very similar to SQL.
            List<Statistics> stats = new List<Statistics>();

            foreach (string str in statsFile)
            {
                Statistics stat = LoadStatistic(str);
                if (stat != null && stat.Algorithm.Equals(currentAlgorithm))
                {
                    stats.Add(stat);
                }
            }
            
            if(stats.Count == 0)
            {
                this.lblOverallStats.Content = "No statistics to show.";

                return;
            }

            int AverageTimeTaken = Statistics.AverageTimeTaken(stats.ToArray<Statistics>());
            float AverageCoverage = Statistics.AverageCoverage(stats.ToArray<Statistics>());
            this.lblOverallStats.Content = String.Format("Algorithm: \t\t {0}.\nAverage time taken: \t {1:00}:{2:00}.\nAverage coverage: \t {3:0}%.\nNumber of runs: \t\t {4}.", currentAlgorithm, AverageTimeTaken / 60, AverageTimeTaken % 60, AverageCoverage, stats.Count);

        }

        private Statistics LoadStatistic(string str)
        {
            Stream input = File.OpenRead(str);
            Statistics stat = null;
            BinaryFormatter reader = new BinaryFormatter();
            if (str == string.Empty)
            {
                return null;
            }
            try
            {
                stat = (Statistics)reader.Deserialize(input);
            }
            catch (ArgumentNullException a)
            {
                MessageBox.Show("There were no statistics files found.\n" + a.Message);
            }
            catch (SerializationException s)
            {
                MessageBox.Show(String.Format("An error occured while reading the statistics file: {0}.\n{1}", str, s.Message));
            }
            catch (System.Security.SecurityException s)
            {
                MessageBox.Show("You do not have access to this file.");
            }
            finally
            {
                input.Close();
            }
            return stat;
        }

    }
}
