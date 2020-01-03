using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    internal class Triangle
    {
        private double _a;
        private double _b;
        private double _c;
        public double A
        {
            set
            {
                CheckInequality(Math.Abs(value),_b,_c);
                _a = Math.Abs(value);
            }
            get => _a;
        }

        public double B
        {
            set
            {
                CheckInequality(_a,Math.Abs(value),_c);
                _b = Math.Abs(value);
            }
            get => _b;
        }

        public double C
        {
            set
            {
                CheckInequality(_a,_b,Math.Abs(value));
                _c = Math.Abs(value);
            }
            get => _c;
        }

        public Triangle(double a, double b, double c)
        {
            CheckInequality(a,b,c);
            _a = a;
            _b = b;
            _c = c;
        }

        private void CheckInequality(double a,double b,double c)
        {
            if (!(a < (b + c) && b < (a + c) && c < (a + b)))
                throw new ArgumentException("Triangle inequality error!");
        }

        public double Perimeter
        {
            get => _a + _b + _c;
        }

        public double Area
        {
            get => Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - _a) * 
                (Perimeter / 2 - _b) * (Perimeter / 2 - _c));
        }

        public override string ToString()
        {
            return $"Triangle. a = {_a}, b = {_b}, c = {_c}." + Environment.NewLine
                + $"Area = {Area:N2}, Perimeter = {Perimeter:N2}.";
        }
    }

    class TriangleDemo
    {
        private static void ChangeTriangle(Triangle triangle)
        {
            Console.WriteLine("Trying to change A to 0");
            try
            {
                triangle.A = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Trying to change B to 0");
            try
            {
                triangle.B = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Trying to change C to 0");
            try
            {
                triangle.C = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Demo()
        {
            double a;
            double b;
            double c;
            Triangle triangle = null;
            Console.WriteLine("Enter lengths of triangle sides. If a negative value is entered, the absolute value is used.");
            Console.WriteLine("(If the input is wrong, you will have to enter one more time.)" + Environment.NewLine);

            do
            {
                do
                {
                    Console.WriteLine("Enter a:");
                } while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,out a));

                do
                {
                    Console.WriteLine("Enter b:");
                } while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,out b));

                do
                {
                    Console.WriteLine("Enter c:");
                } while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,out c));

                try
                {
                    triangle = new Triangle(a,b,c);
                    Console.WriteLine("Triangle has been created.");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true);

            Console.WriteLine(triangle);
            Console.ReadLine();

            ChangeTriangle(triangle);
            Console.WriteLine(triangle);
            Console.ReadLine();
        }
    }
}
