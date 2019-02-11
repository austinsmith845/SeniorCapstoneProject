using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeniorCapstoneProject.Furniture;

namespace SeniorCapstoneProject
{
    public class FurnitureFactory
    {
        public IFurniture InsertFurniture(string whatToInsert)
        {
            whatToInsert = whatToInsert.ToLower();
            if(whatToInsert == "recliner")
            {
                return new Recliner();
            }
            return null;
        }
    }
}
