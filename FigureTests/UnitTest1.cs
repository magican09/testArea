using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaClassLibrary;
namespace FigureTests
{
    [TestClass]
    public class FugureTests
    {
        [TestMethod]
        public void Triangle_Area_Calc_Withs_Points() //Проверка площади треугольника по точкам
        {
            Triangle triangle = new Triangle();
            triangle.Points.Add(new Point(-1, -1));
            triangle.Points.Add(new Point(1, 3));
            triangle.Points.Add(new Point(3, -1));
            double expected = 8;
            double result = triangle.Area;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Triangle_Is_Rectan_Withs_Points() //Проверка треуголька на прямоугольность
        {
            Triangle triangle = new Triangle();
            triangle.Points.Add(new Point(0, 0));
            triangle.Points.Add(new Point(2, 2));
            triangle.Points.Add(new Point(4, 0));
            bool expected = true;
            bool result = triangle.IsTriangleRectan();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Triangle_Area_Calc_Withs_Sides() //Проверка площади треугольника по сторонам
        {
            Triangle triangle = new Triangle(5, 7.071, 5);
            double expected = 12.5;
            double result = triangle.Area;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Triangle_Is_Rectan_Withs_Sides() //Проверка треуголька на прямоугольность
        {
            Triangle triangle = new Triangle(5, 7.071, 5);
            bool expected = true;
            bool result = triangle.IsTriangleRectan();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Poligon_Area_Calc() //Проверка площади произвольного полигона
        {
            Poligon poligon = new Poligon();
            poligon.Points.Add(new Point(1, 2));
            poligon.Points.Add(new Point(3, 4));
            poligon.Points.Add(new Point(6, 6));
            poligon.Points.Add(new Point(5, 1));
            poligon.Points.Add(new Point(4, 2));
            double expected = 10;
            double result = poligon.Area;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Circle_Area_Calc()//Проверка площади круга
        {
            Circle circle = new Circle();
            circle.CentrePoint = new Point(0, 0);
            circle.Radius = 1;
            double expected = Math.PI;
            double result = circle.Area;
            Assert.AreEqual(expected, result);
        }
    }
}
