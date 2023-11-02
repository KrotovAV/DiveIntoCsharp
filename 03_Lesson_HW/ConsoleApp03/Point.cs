using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp03
{
    //enum Way { Left, Right, Up, Down, None };
    public struct Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public string? way { get; set; }

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
        public Point(int x, int y, string way)
        {
            this.x = x;
            this.y = y;
            this.way = way;
        }
        public override string ToString()
        {
            return $"{x}, {y} way: {way}";
        }
    }
}
