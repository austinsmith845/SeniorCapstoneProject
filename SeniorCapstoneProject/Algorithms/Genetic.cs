using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject.Algorithms
{
    public class Genetic : IAlgorithm
    {
        #region Properties / Attributes

        public string Algorithm
        {
            get { return "Genetic"; }
        }

        #endregion
        public Genetic()
        {

        }

        public void NextMove(RobotVacuum vacuum)
        {
            throw new NotImplementedException();
        }
    }
}
