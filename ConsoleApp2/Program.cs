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
            Poligon NFigure = new Poligon();
            Point P1 = new Point(0, 0);
            Point P2 = new Point(0, 2);
            Point P3 = new Point(1, 2);
            Point P4 = new Point(1, 0);
            NFigure.Points.Add(P1);
            NFigure.Points.Add(P2);
            NFigure.Points.Add(P3);
            NFigure.Points.Add(P4);
            double area = NFigure.Area;
            NFigure.Points.Remove(P4);
            area = NFigure.Area;
            Triangle triangle = new Triangle(5, 7.071, 5);
            area = triangle.Area;
            bool IsReg = triangle.IsTriangleRectan();
            Triangle triangle_1 = new Triangle();
            triangle_1.Points.Add(new Point(0, 0));
            triangle_1.Points.Add(new Point(0, 4));
            triangle_1.Points.Add(new Point(5, 0));
            area = triangle_1.Area;
            IsReg = triangle_1.IsTriangleRectan();

        }
    }
}
