using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AreaClassLibrary
{
    public enum FiguraType
    {
        POLIGON,
        CIRCLE
    }
    public class Point : ICloneable //Класс точка
    {
        public double X;
        public double Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point() { }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class Vector : Point, ICloneable //Класс вектор
    {
        public Point P1;
        public Point P2;
        public Vector(Point p1, Point p2)
        {

            P1 = (Point)p1.Clone();
            P2 = (Point)p2.Clone();
        }
        public Vector() { }
        public void ToZero() //Приведедение вектора к началу координат
        {
            P2.X -= P1.X;
            P1.X = 0;
            P2.Y -= P1.Y;
            P1.Y = 0;
            base.X = P2.X;
            base.Y = P2.Y;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public static class Func //Функции...
    {
        public static double SclarPod(Point p1, Point p2) //Скалярное поивзедение векторов
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }
    }
    public class Figure //Класс фигура
    {
        private double area; //Порщадь фигуры
        private Point circlelCenters;
        private double  radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                circlelCenters =(Point)Points[0].Clone(); //Принимаем цетром радиуса первую точку в списке.
                Points.Clear();
                Points.Add(circlelCenters);
                Type = FiguraType.CIRCLE;
                radius = value;
            }
        }
        public FiguraType Type;
        public double Area
        {
            get
            {
                area = 0;
                if(Type== FiguraType.POLIGON )
                { 
                for (int ii = 0; ii < Points.Count - 1; ii++) //Вычисление прощади многоугольника по формуле Гаусса 
                    area += Points[ii].X * Points[ii + 1].Y - Points[ii].Y * Points[ii + 1].X;
                area += Points[Points.Count - 1].X * Points[0].Y - Points[Points.Count - 1].Y * Points[0].X;
                area = Math.Abs(area / 2);
                }
                else
                {
                    area = Math.PI * Radius * Radius;
                }
                return area;
            }
            set
            {

            }
        } //Плозадь фигуры
        public double Perimeter { get; set; } //Периметр фигуры
        public ObservableCollection<Point> Points;
        public Figure()
        {
            Points = new ObservableCollection<Point>();
            Type = FiguraType.POLIGON;//По умолчанию создаем полигон
        }
        public bool IsTriangleRectan()//Проверка является ли треугольник прямоугольным
        {
            double result = 0;
            if (Points.Count == 3)//Является ли  фигура треугольником 
            {

                Vector v1 = new Vector(Points[0], Points[1]);
                Vector v2 = new Vector(Points[1], Points[2]);
                Vector v3 = new Vector(Points[2], Points[0]);
                v1.ToZero();
                v2.ToZero();
                v3.ToZero();
                result = Func.SclarPod(v1, v2) * Func.SclarPod(v1, v3) * Func.SclarPod(v2, v3);//Является ли треугольник прямоугольным - произведение скалярных произведенией векторов == 0
                return result == 0;
            }
            else
                return false;
        }

    }

}
