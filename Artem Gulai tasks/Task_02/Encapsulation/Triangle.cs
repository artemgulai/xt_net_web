using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Triangle
    {
        private Double _a;
        private Double _b;
        private Double _c;
        public Double A
        {
            set
            {
                _a = Math.Abs(value);
            }
            get => _a;
        }

        public Double B
        {
            set
            {
                _b = Math.Abs(value);
            }
            get => _b;
        }

        public Double C
        {
            set
            {
                _c = Math.Abs(value);
            }
            get => _c;
        }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Double Perimeter
        {
            get => _a + _b + _c;
        }

        public Double Area
        {
            get => Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - _a) * 
                (Perimeter / 2 - _b) * (Perimeter / 2 - _c));
        }

        public override string ToString()
        {
            return $"Triangle. a = {_a}, b = {_b}, c = {_c}." + Environment.NewLine
                + $"Area = {Area:N2}, Perimeter = {Perimeter}.";
        }
    }

    class TriangleDemo
    {
        public static void Demo()
        {
            Double a;
            Double b;
            Double c;
            Console.WriteLine("Enter lengths of triangle sides. If a negative value is entered, the absolute value is used.");
            Console.WriteLine("(If the input is wrong, you will have to enter one more time.)" + Environment.NewLine);

            do
            {
                do
                {
                    Console.WriteLine("Enter a:");
                } while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,out a));

                do
                {
                    Console.WriteLine("Enter b:");
                } while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,out b));

                do
                {
                    Console.WriteLine("Enter c:");
                } while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,
                        CultureInfo.InvariantCulture,out c));

                // Checking the triangle inequality
                if (a < (b + c) && b < (a + c) && c < (a + b))
                {
                    break;
                }
                Console.WriteLine("The triangle inequality error. Try again.");
            } while (true);

            Triangle triangle = new Triangle(a,b,c);
            Console.WriteLine(triangle);
            Console.ReadLine();
        }
    }
}
