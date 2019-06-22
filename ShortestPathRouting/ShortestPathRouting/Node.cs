using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathRouting
{
    public class Node
    {
        public int Vertex { get; set; }

        public int VertexSource { get; set; }

        public int Distance { get; set; }

        public int Update { get; set; }

        public Button ButtonNode { get; set; }

        public List<PacketSend> Queue { get; set; }

        public List<byte> DataNode { get; set; }

        public Node(int vertex, int vertexsource, int distance)
        {
            Vertex = vertex;
            VertexSource = vertexsource;
            Distance = distance;
            Update = 0;
            ButtonNode = new Button();
            Queue = new List<PacketSend>();
            DataNode = new List<byte>();
        }

        public Node(int vertex)
        {
            Vertex = vertex;
            VertexSource = 100000000;
            Distance = 100000000;
            Update = 0;
            ButtonNode = new Button();
            Queue = new List<PacketSend>();
            DataNode = new List<byte>();
        }

        public Node(int vertex, Button button)
        {
            Vertex = vertex;
            VertexSource = 100000000;
            Distance = 100000000;
            Update = 0;
            ButtonNode = button;
            Queue = new List<PacketSend>();
            DataNode = new List<byte>();
        }

        // Convert Data
        // ;;;;;[Node]...[Node];;;;;[Data]
        // [Data] == %%%%%FileName%%%%%[DataFile]
        
    }
}
