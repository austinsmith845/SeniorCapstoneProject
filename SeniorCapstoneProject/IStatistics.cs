using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public interface IStatistics
    {
        int TimeTaken { get; }
        float Coverage { get; }    
        string Algorithm { get; }

    }
}
