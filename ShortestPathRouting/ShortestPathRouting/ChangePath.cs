using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathRouting
{
    public static class ChangePath
    {
        public static Path path;

        public static bool isCreatePath = false;

        public static bool isDeletePath = false;

        public static Node GetNode;

        public const string TypeSpace = "%%%%%";

        public const string TypeEnd = ";;;;;";
    }
}
