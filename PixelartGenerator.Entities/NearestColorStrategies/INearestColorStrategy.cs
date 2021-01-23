using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PixelartGenerator.Entities
{
    public interface INearestColorStrategy
    {
        double DistanceToNeighbour(Color color, Color neighbour);
    }
}
