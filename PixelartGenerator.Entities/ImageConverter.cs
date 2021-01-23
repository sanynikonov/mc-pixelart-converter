using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PixelartGenerator.Entities
{
    public class ImageConverter
    {
        private readonly IEnumerable<Color> _pallet;
        private readonly Dictionary<Color, Color> _cachedColors = new Dictionary<Color, Color>();

        public ImageConverter(IEnumerable<Color> pallet)
        {
            _pallet = pallet;
        }

        public Color[,] Transform(Color[,] image, INearestColorStrategy nearestColorStrategy)
        {
            var result = new Color[image.GetLength(0), image.GetLength(1)];

            for (int y = 0; y < image.GetLength(0); y++)
            {
                for (int x = 0; x < image.GetLength(1); x++)
                {
                    result[y, x] = FindMostSuitableAvailibleColor(image[y, x], nearestColorStrategy);
                }
            }

            return result;
        }

        private Color FindMostSuitableAvailibleColor(Color color, INearestColorStrategy nearestColorStrategy)
        {
            if (_cachedColors.TryGetValue(color, out var neighbour))
            {
                return neighbour;
            }

            var distances = _pallet.Select(c =>
                new { Neighbour = c, Distance = nearestColorStrategy.DistanceToNeighbour(color, c) });
            var minDistance = distances.Min(x => x.Distance);
            neighbour = distances.First(x => x.Distance == minDistance).Neighbour;

            _cachedColors.Add(color, neighbour);
            return neighbour;
        }
    }
}
