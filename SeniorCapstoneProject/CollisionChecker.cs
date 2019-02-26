using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SeniorCapstoneProject
{
    public class CollisionChecker
    {
        List<IFurniture> furniture;

        public CollisionChecker(List<IFurniture> furn)
        {
            furniture = furn;
        }
        
        /// <summary>
        /// This method will check for collsions.
        /// </summary>
        /// <returns></returns>
        public bool CollisionOccured()
        {
            //This method has not been implemented yet.
            foreach(IFurniture furn in furniture)
            {
                
            }
            return false;
        }
    }
}
