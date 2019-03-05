using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        #region Support Methods


        #endregion


    }
}
