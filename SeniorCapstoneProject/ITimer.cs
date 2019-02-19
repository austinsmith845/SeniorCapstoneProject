using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public interface ITimer
    {
        bool Enabled { get; set; }
        void Tick();
    }
}
