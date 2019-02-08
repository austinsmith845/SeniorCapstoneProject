using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    internal interface IRoom
    {
       float Length { get; set; } 
       float Width { get; set; }
       string Name { get; set; }

        void Insert(IFurniture furniture, int x, int y);
        void Remove(IFurniture selected);
        void Save();

    }
}
