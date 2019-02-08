using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    interface IFurniture
    {
        float Height { get;  }
        float Width { get;  }
        bool CanPassUnder();
        void Select();
    }
}
