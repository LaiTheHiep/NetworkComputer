using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathRouting
{
    public class RelationNode
    {
        public Node NameNode { get; set; }

        public int RankNode { get; set; }

        public Node NodeParent { get; set; }


        public RelationNode(Node namenode, int ranknode, Node nodeparent)
        {
            NameNode = namenode;
            RankNode = ranknode;
            NodeParent = nodeparent;
        }
    }
}
