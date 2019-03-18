using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorCapstoneProject
{
    public class SettingsRegistry
    {

        private int _SpiralRotationModifier;
        public int SprialRotationModifier
        {
            get { return _SpiralRotationModifier; }
            set { _SpiralRotationModifier = value; }
        }

        private int _geneticRotationModifier;
        public int GeneticRotationModifier
        {
            get { return _geneticRotationModifier; }
            set { _geneticRotationModifier = value; }
        }

        private int _snakeAndWalkRotationModifier;
        public int SnakeAndWalkRotationModifier
        {
            get { return _snakeAndWalkRotationModifier; }
            set { _snakeAndWalkRotationModifier = value; }
        }

    }
}
