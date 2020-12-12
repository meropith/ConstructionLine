using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class SearchResults
    {
        public SearchResults()
        {
            Shirts = new List<Shirt>();
            SizeCounts = new List<SizeCount>();
            ColorCounts = new List<ColorCount>();

            foreach (var col in Color.All)
            {
                ColorCounts.Add(new ColorCount { Color = col, Count = 0 });
            }

            foreach (var size in Size.All)
            {
                SizeCounts.Add(new SizeCount { Size = size, Count = 0 });
            }
        }

        public List<Shirt> Shirts { get; set; }


        public List<SizeCount> SizeCounts { get; set; }


        public List<ColorCount> ColorCounts { get; set; }
    }


    public class SizeCount
    {
        public Size Size { get; set; }

        public int Count { get; set; }
    }


    public class ColorCount
    {
        public Color Color { get; set; }

        public int Count { get; set; }
    }
}