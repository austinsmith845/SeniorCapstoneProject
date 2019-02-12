using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeniorCapstoneProject.Furniture;
using System.Windows.Controls;

namespace SeniorCapstoneProject
{
    public class FurnitureFactory
    {
        public IFurniture InsertFurniture(string whatToInsert, Grid grid)
        {
            whatToInsert = whatToInsert.ToLower();
            if(whatToInsert == "recliner")
            {
                return new Recliner(FurnitureTypes.recliner,grid);
            }
            return null;
        }


    }
}
