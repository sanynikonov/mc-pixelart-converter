using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelartGenerator.Entities
{
    public class CustomNearestColorStrategy : INearestColorStrategy
    {
        private double _rWeight;
        private double _bWeight;
        private double _gWeight;

        public CustomNearestColorStrategy(double rWeight, double gWeight, double bWeight)
        {
            _rWeight = rWeight;
            _bWeight = bWeight;
            _gWeight = gWeight;
        }

        public double DistanceToNeighbour(Color c1, Color c2)
        {
            return _rWeight * Math.Pow(c2.R - c1.R, 2)
                + _gWeight * Math.Pow(c2.G - c1.G, 2)
                + _bWeight * Math.Pow(c2.B - c1.B, 2);
        }
    }
}
