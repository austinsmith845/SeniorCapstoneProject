using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    /// <summary>
    /// Acts as the contract for the algorithms to ensure that the NextMove() method is there.
    /// </summary>
    public interface IAlgorithm
    {
        void NextMove(RobotVacuum vacuum);
        
    }
}
