using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelartGenerator.Entities
{
    public class HumanPerceptionNearestColorStrategy : INearestColorStrategy
    {
        private static CustomNearestColorStrategy _strategy = new CustomNearestColorStrategy(30, 59, 11);

        public double DistanceToNeighbour(Color color, Color neighbour)
        {
            return _strategy.DistanceToNeighbour(color, neighbour);
        }
    }
}
