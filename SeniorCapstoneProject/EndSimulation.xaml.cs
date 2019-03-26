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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
            GetOverallStatistics(stats.Algorithm);
            
        }

        private void ButtonClick(object sender, RoutedEventArgs args)
        {
            Button button = (Button)sender;
            string tag = (string)button.Tag;

            if(tag.ToLower() == "close")
            {
                this.Close();
            }
            else if(tag.ToLower() == "visualization")
            {
                MessageBox.Show("This feature has not yet been implemented.");
            }
        }

        private void DisplayStatistics(IStatistics stats)
        {
            string TimeTaken = string.Format("{1:00}:{0:00}", stats.TimeTaken % 60, stats.TimeTaken / 60);
            this.lblThisRunStats.Content = String.Format("Time Taken: \t {0}\nCoverage: \t {1:0.000}%\nAlgorithm: \t {2}", TimeTaken, stats.Coverage, stats.Algorithm); 
        }

        private void GetOverallStatistics(String currentAlgorithm)
        {
            string[] files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
            IEnumerable<string> statsFile = from string f in files where f.Contains(".rvss") select f;  //Filers out files that are not statistics files. This is a LINQ expression which is very similar to SQL.
            List<Statistics> stats = new List<Statistics>();
            
            foreach(string str in statsFile)
            {
                Statistics stat = LoadStatistic(str);
                if (stat != null && stat.Algorithm.Equals(currentAlgorithm))
                {
                    stats.Add(stat);
                }
            }

            int AverageTimeTaken = Statistics.AverageTimeTaken(stats.ToArray<Statistics>());
            float AverageCoverage = Statistics.AverageCoverage(stats.ToArray<Statistics>());
            this.lblOverallStats.Content = String.Format("Algotrithm: \t\t {0}.\nAverage time taken: \t {1:00}:{2:00}.\nAverage coverage: \t {3:0.000}%.\nNumber of runs: \t\t {4}.", currentAlgorithm, AverageTimeTaken / 60, AverageTimeTaken % 60, AverageCoverage, stats.Count);

        }

        private Statistics LoadStatistic(string str)
        {
            Stream input = File.OpenRead(str);
            Statistics stat = null;
            BinaryFormatter reader = new BinaryFormatter();
            if(str == string.Empty)
            {
                return null;
            }
            try
            {
                stat = (Statistics) reader.Deserialize(input);
            }
            catch (ArgumentNullException a)
            {
                MessageBox.Show("There were no statistics files found.\n" + a.Message);
            }
            catch (SerializationException s)
            {
                MessageBox.Show(String.Format("An error occured while reading the statistics file: {0}.\n{1}", str, s.Message));
            }
            catch(System.Security.SecurityException s)
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
