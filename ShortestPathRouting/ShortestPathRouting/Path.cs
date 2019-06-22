using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathRouting
{
    public class Path
    {
        public int Source { get; set; }

        public int Dest { get; set; }

        public int Link { get; set; }

        // true  : 2 chieu
        // false : 1 chieu
        public bool Vector { get; set; }

        public Path(int source, int dest, int link)
        {
            Dest = dest;
            Source = source;
            Vector = true;
            Link = link;
        }

        public Path(int source, int dest, int link, bool vector)
        {
            Dest = dest;
            Source = source;
            Link = link;
            Vector = vector;
        }
    }
}
