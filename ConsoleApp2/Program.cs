using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AreaClassLibrary;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure NFigure = new Figure();
            Point P1 = new Point(-1, 0);
            Point P2 = new Point(0, 1);
            Point P3 = new Point(1, 0);
            //Point P4 = new Point(0, -1);

            NFigure.Points.Add(P1);
            NFigure.Points.Add(P2);
            NFigure.Points.Add(P3);
          ///  NFigure.Points.Add(P4);
            double area = NFigure.Area;
            NFigure.Radius = 1;
            area = NFigure.Area;
            bool IsReg = NFigure.IsTriangleRectan();
        }
    }
}
