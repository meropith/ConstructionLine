using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;        
        private Dictionary<Guid, List<Shirt>> _ColourResults;


        public SearchEngine(List<Shirt> shirts)
        {

            _shirts = shirts;
            _ColourResults = new Dictionary<Guid, List<Shirt>>();


            foreach (var color in Color.All)
            {
                _ColourResults.Add(color.Id, _shirts.Where(s => s.Color.Id == color.Id).ToList());
            }
           

        }


        public SearchResults Search(SearchOptions options)
        {
            var searchResult = new SearchResults();



            if (options.Colors.Any())
            {
                var l1 = _ColourResults.Where(kv => options.Colors.Select(s => s.Id).Contains(kv.Key));

                if (options.Sizes.Any())
                {
                    foreach (var kvp in l1)
                    {
                        searchResult.ColorCounts.FirstOrDefault(cc => cc.Color.Id == kvp.Key).Count = kvp.Value.Count;
                        var l2 = kvp.Value.Where(sh => options.Sizes.Contains(sh.Size));
                        searchResult.Shirts.AddRange(l2);

                        searchResult.SizeCounts.FirstOrDefault(ls => ls.Size == Size.Small).Count += l2.Count(l=>l.Size == Size.Small);
                        searchResult.SizeCounts.FirstOrDefault(ls => ls.Size == Size.Medium).Count += l2.Count(l => l.Size == Size.Medium);
                        searchResult.SizeCounts.FirstOrDefault(ls => ls.Size == Size.Large).Count += l2.Count(l => l.Size == Size.Large);
                    }
                }
                else
                {
                    foreach (var kvp in l1)
                    {
                        searchResult.ColorCounts.FirstOrDefault(cc => cc.Color.Id == kvp.Key).Count = kvp.Value.Count;                        
                        searchResult.Shirts.AddRange(kvp.Value);                        

                        searchResult.SizeCounts.FirstOrDefault(ls => ls.Size == Size.Small).Count += kvp.Value.Count(l => l.Size == Size.Small);
                        searchResult.SizeCounts.FirstOrDefault(ls => ls.Size == Size.Medium).Count += kvp.Value.Count(l => l.Size == Size.Medium);
                        searchResult.SizeCounts.FirstOrDefault(ls => ls.Size == Size.Large).Count += kvp.Value.Count(l => l.Size == Size.Large);
                    }
                }

            }



            return searchResult;
        }
    }
}