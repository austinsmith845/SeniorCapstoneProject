using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Win32;

namespace SeniorCapstoneProject
{
    public class Statistics : IStatistics
    {

        #region Properties / Attributes

        private int _timeTaken = 0;
        public int TimeTaken
        {
            get { return _timeTaken; }
            set { _timeTaken = value; }
        }

        private float _coverage = 0;
        public float Coverage
        {
            get { return _coverage; }
            set { _coverage = value; }
        }

        private string _algorithm;
        public string Algorithm
        {
            get { return _algorithm; }
            set { _algorithm = value; }
        }


        #endregion

        public Statistics(int timetaken, float coverage, string algorithm)
        {
            TimeTaken = timetaken;
            Coverage = coverage;
            Algorithm = algorithm;
            SaveStatistics();
        }

        #region Support Methods

        public void SaveStatistics()
        {
            DateTime now = DateTime.Now;
            string name =   now.Day + "."+ now.Hour +"."+now.Minute+"." +now.Second+ "." + Algorithm + "stats.rvss";
            Stream file = File.Create(name);

            try
            {
                BinaryFormatter writer = new BinaryFormatter();
                writer.Serialize(file, this);
               
            }
            catch (ArgumentNullException a)
             {
                Console.WriteLine("Cannot save a null statistics object.\n" + a.Message);
             }
            catch (SerializationException s)
            {
                Console.WriteLine("An error occured while writing the file.\n" + s.Message);

            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("You do not have permission to save in the required save directory.");
            }
            finally
            {
                file.Close(); //Close the file to prevent a memory leak.
            }
        }

        #endregion


    }
}
