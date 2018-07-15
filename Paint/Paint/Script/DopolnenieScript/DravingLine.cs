using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public class DravingLine
    {
        public DravingLine() { }

        public Point X;
        public Point Y;
        public byte id;
        public int count;
        public DravingLine(Point x, Point y, byte id, int count)
        {
            X = x;
            Y = y;
            this.id = id;
            this.count = count;
        }

        public Point x1;
        public Point y1;

        public int dop_x1;
        public int dop_y1;
        public int dop_x2;
        public int dop_y2;
        public DravingLine(Point x1, Point y1, byte id)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.id = id;
        }
    }
}