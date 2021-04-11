using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AreaClassLibrary
{
    public enum FigureType //Тип фигуры
    {
        POLIGON,
        TRIANGLE,
        CIRCLE
    }
    public class Point : ICloneable //Класс точка.
    {
        public double X { get; set; }
        public double Y { get; set; }
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
        public void ToZero() //Приведедение вектора к началу координат.
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
        public static double ScalarProd(Point p1, Point p2) //Скалярное произведение векторов.
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }
        public static double Distance(Point p1, Point p2) //Расстояние между точками
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        public static int GetDecimalDigitsCount(double number)
        {
            string[] str = number.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." }).Split('.');
            return str.Length == 2 ? str[1].Length : 0;
        }
    }

    public abstract class Figure //Абстракный класс фигура
    {
        public abstract double Area { get; set; }
        public FigureType Type { get; set; }

    }
    public class Poligon : Figure //Класс полигон
    {
        public int accuracyLevel;//Точность вычислений
        private double area;
        public override double Area
        {
            get
            {
                area = 0;
                for (int ii = 0; ii < Points.Count - 1; ii++) //Вычисление прощади полигона по формуле Гаусса 
                    area += Math.Round(Points[ii].X * Points[ii + 1].Y - Points[ii].Y * Points[ii + 1].X, accuracyLevel);
                area += Math.Round(Points[Points.Count - 1].X * Points[0].Y - Points[Points.Count - 1].Y * Points[0].X, accuracyLevel);
                area = Math.Abs(area / 2);
                return area;
            }
            set { }
        } //Площадь фигуры
        public ObservableCollection<Point> Points;//Точки вершин полигона. 
        public ObservableCollection<double> Sides;//Длины сторон полигона.
        public Poligon()
        {
            Points = new ObservableCollection<Point>();
            Sides = new ObservableCollection<double>();
            Type = FigureType.POLIGON;
            Points.CollectionChanged += Points_CollectionChanged;//Устанавливаем обработчик изменения  точек в польгоне.
        }
        private void Points_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)//Обработчки изменения количества точек полигона.
        {
            Sides.Clear();
            Sides.Add(0);
            for (int ii = 0; ii < Points.Count - 1; ii += 1)
                Sides.Add(Func.Distance(Points[ii], Points[ii + 1]));
            Sides[0] = Func.Distance(Points[0], Points[Points.Count - 1]);
        }
    }
    public class Triangle : Poligon
    {

        public bool IsTriangleRectan()//Проверка является ли треугольник прямоугольным
        {
            double result;
            if (Points.Count == 3)//Если известны имеются все координаты...
            {
                Vector v1 = new Vector(Points[0], Points[1]);
                Vector v2 = new Vector(Points[1], Points[2]);
                Vector v3 = new Vector(Points[2], Points[0]);
                v1.ToZero();
                v2.ToZero();
                v3.ToZero();
                result = Math.Round(Func.ScalarProd(v1, v2), accuracyLevel) *
                         Math.Round(Func.ScalarProd(v1, v3), accuracyLevel) *
                         Math.Round(Func.ScalarProd(v2, v3), accuracyLevel);//Является ли треугольник прямоугольным - произведение скалярных произведенией векторов == 0
                return result == 0;
            }
            else
            {
                throw new Exception("Фигура не является треугольником. Проверте количество вершин.");
            }
        }
        public Triangle()
        {
            accuracyLevel = 15;
            Type = FigureType.TRIANGLE;
        }
        public Triangle(double a, double b, double c)
        {
            if (accuracyLevel < Func.GetDecimalDigitsCount(a)) //Устанавливаем точность вычислений по самому точному значению входных параметров.
                accuracyLevel = Func.GetDecimalDigitsCount(a);
            if (accuracyLevel < Func.GetDecimalDigitsCount(b))
                accuracyLevel = Func.GetDecimalDigitsCount(b);
            if (accuracyLevel < Func.GetDecimalDigitsCount(c))
                accuracyLevel = Func.GetDecimalDigitsCount(c);

            Points.Add(new Point(0, 0));//Располагаем треугольник в первой четверти координатной сетки стороной 'а' вдоль оси ОХ.
            Points.Add(new Point(a, 0));
            double cos_a = (Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b);//По теореме косинусов находим координаты третей вершины треугольника.
            double bc_x = cos_a * b;
            double bc_y = Math.Sqrt(Math.Pow(b, 2) - Math.Pow(bc_x, 2));
            Points.Add(new Point(bc_x, bc_y));
            Type = FigureType.TRIANGLE;
        }


    }
    public class Circle : Figure
    {
        public Point CentrePoint { get; set; }//Коодинаты центра окружности.
        public double Radius { get; set; }
        public override double Area
        {
            get
            {
                Area = Math.PI * Radius * Radius;
                return Area;
            }
            set
            {
            }
        }
        public Circle()
        {
            Type = FigureType.CIRCLE;
        }


    }
}
