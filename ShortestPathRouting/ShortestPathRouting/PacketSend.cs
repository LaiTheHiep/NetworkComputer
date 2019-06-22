using System.Collections.Generic;
using System.Drawing;

namespace ShortestPathRouting
{
    public class PacketSend
    {
        public string Tree { get; set; } 

        public List<byte> Data { get; set; }

        public int CountSegment { get; set; }

        public Pen ColorLine { get; set; }

        public PacketSend(string tree, List<byte> data)
        {
            Tree = tree;
            Data = data;
            ColorLine = Pens.Blue;
            CountSegment = 0;
        }

        public PacketSend(string tree, List<byte> data, Pen color)
        {
            Tree = tree;
            Data = data;
            ColorLine = color;
            CountSegment = 0;
        }

    }
}
