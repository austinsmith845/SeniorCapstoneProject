using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// This class creates instances of the algorithms using reflection.
    /// </summary>
    public class AlgorithmFactory
    {

        public IAlgorithm GetAlgorithm(string algorithm)
        {
            Type type = Type.GetType("SeniorCapstoneProject.Algorithms."+algorithm);
            IAlgorithm algo = (IAlgorithm) Activator.CreateInstance(type); //creates an instance of the algorithm type.

            return algo;
        }
        
    }
}
