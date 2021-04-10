using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaClassLibrary;
namespace FigureTests
{
    [TestClass]
    public class FugureTests
    {
        [TestMethod]
        public void Triangle_Area_Calc() //Проверка площади треугольника
        {
            Figure figure = new Figure();
            figure.Points.Add(new Point(-1, -1));
            figure.Points.Add(new Point(1, 3));
            figure.Points.Add(new Point(3, -1));
            double expected = 8;
            double result = figure.Area;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Triangle_Is_Rectan() //Проверка треуголька на прямоугольность
        {
            Figure figure = new Figure();
            figure.Points.Add(new Point(0, 0));
            figure.Points.Add(new Point(2, 2));
            figure.Points.Add(new Point(4, 0));
            bool expected = true;
            bool result = figure.IsTriangleRectan();
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
          public void Poligon_Area_Calc() //Проверка площади произвольного полигона
        {
            Figure figure = new Figure();
            figure.Points.Add(new Point(1, 2));
            figure.Points.Add(new Point(3, 4));
            figure.Points.Add(new Point(6, 6));
            figure.Points.Add(new Point(5, 1));
            figure.Points.Add(new Point(4, 2));
            double expected = 10;
            double result = figure.Area;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Circle_Area_Calc()//Проверка площади круга
        {
            Figure figure = new Figure();
            figure.Points.Add(new Point(0, 0));
            figure.Radius = 1;
            double expected = Math.PI;
            double result = figure.Area;
            Assert.AreEqual(expected, result);
        }
    }
}
