using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 抽象类
{
    class Program
    {
        static void Main(string[] args)
        {

            Shape shape = new Circle(5);
            double area = shape.GetArea();
            double perimeter = shape.GetPerimeter();
            Console.WriteLine("周长为{0}，面积为{1}", perimeter, area);
            Console.ReadKey();
        }
    }

    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    public class Circle : Shape
    {
       private double _r;
       public double R
       {
           get { return _r; }
           set { _r = value; }
       }

       public Circle(double r)
       {
           this.R = r;
       }

       public override double GetArea()
       {
           return Math.PI * this.R * this.R;
       }

       public override double GetPerimeter()
       {
           return 2 * Math.PI * this.R;
       }
    }

    public class Rectangle : Shape
    {
        private double _height;

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        private double _width;

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;

        }

        public override double GetArea()
        {
            return this.Height * this.Width;
        }

        public override double GetPerimeter()
        {
            return 2 * (this.Height + this.Width);
        }
    }
}
