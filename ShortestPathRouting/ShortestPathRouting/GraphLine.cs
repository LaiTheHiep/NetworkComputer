﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathRouting
{
    public class GraphLine
    {
        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public GraphLine(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }
    }
}