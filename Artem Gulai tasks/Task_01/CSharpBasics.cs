using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class CSharpBasics
    {
        /// <summary>
        /// Calculates the area of a rectangle with sides equal to a and b.
        /// </summary>
        public static void Rectangle_1_1()
        {
            Console.WriteLine("Calculating the area of a rectangle with sides equal a and b.");
            int a = 0, b = 0;
            bool flagA = false, flagB = false;
            while (!flagA)
            {
                Console.WriteLine("Enter a:");
                if (Int32.TryParse(Console.ReadLine(),out a))
                {
                    if (a <= 0)
                    {
                        Console.WriteLine("A side cannot be non-positive. Try again.");
                    }
                    else
                    {
                        flagA = true;
                    }
                }
            }
            while (!flagB)
            {
                Console.WriteLine("Enter b:");
                if (Int32.TryParse(Console.ReadLine(),out b))
                {
                    if (b <= 0)
                    {
                        Console.WriteLine("A side cannot be non-positive. Try again.");
                    }
                    else
                    {
                        flagB = true;
                    }
                }
            }

            int area = a * b;
            Console.WriteLine("The area of the rectangle equals to " + area + ".");
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Requests N from a user and prints a rectangular triangle made of *.
        /// </summary>
        public static void Triangle_1_2()
        {
            Console.WriteLine("Drawing a rectangular triangle with sides equal to N.");
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter N.");
                if (Int32.TryParse(Console.ReadLine(),out n))
                {
                    if (n > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i <= n; i++)
                        {
                            sb.Append('*');
                            Console.WriteLine(sb);
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Requests N from a user and prints an isosceles triangle made of *.
        /// </summary>
        public static void AnotherTriangle_1_3()
        {
            Console.WriteLine("Drawing an isosceles triangle with sides equal to N.");
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter N.");
                if (Int32.TryParse(Console.ReadLine(),out n))
                {
                    if (n > 0)
                    {
                        StringBuilder sbSpace = new StringBuilder();
                        for (int i = 1; i < n; i++)
                        {
                            sbSpace.Append(' ');
                        }
                        sbSpace.Append('*');

                        for (int i = 1; i <= n; i++)
                        {
                            Console.WriteLine(sbSpace);
                            sbSpace.Append("**");
                            sbSpace.Remove(0,1);
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Requests N from a user and prints an Xmas tree made of *.
        /// </summary>
        public static void XmasTree_1_4()
        {
            Console.WriteLine("Drawing an isosceles triangle with sides equal to N.");
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter N.");
                if (Int32.TryParse(Console.ReadLine(),out n))
                {
                    if (n > 0)
                    {
                        StringBuilder sbTree = new StringBuilder();
                        StringBuilder sbAsterisk = new StringBuilder();

                        for (int i = 0; i < n - 1; i++)
                        {
                            sbAsterisk.Append(' ');
                        }
                        sbAsterisk.Append('*');

                        for (int i = 0; i < n; i++)
                        {
                            sbTree.Append(sbAsterisk);
                            Console.WriteLine(sbTree);
                            sbAsterisk.Append("**");
                            sbAsterisk.Remove(0,1);
                            sbTree.Append('\n');
                        }

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Finds the sum of numbers less than 1000 and multiple of 3 or 5.
        /// </summary>
        public static void SumOfNumbers_1_5()
        {
            int sum = 0;
            for (int i = 3; i < 1000; i += 3)
            {
                sum += i;
            }
            for (int i = 5; i < 1000; i += 5)
            {
                if (i % 3 != 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum of numbers less than 1000 and multiple of 3 or 5: " + sum);
            Console.ReadLine();
        }

        /// <summary>
        /// Enumeration for font adjustment.
        /// </summary>
        [Flags]
        enum FontStyle : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        /// <summary>
        /// Requests an option number from a user and sets a font parameter.
        /// </summary>
        public static void FontAdjustment_1_6()
        {
            FontStyle fs = new FontStyle();
            byte enter = 0;
            int numberOfIterations = 0;
            while (numberOfIterations < 10)
            {
                Console.WriteLine("Параметры надписи: " + fs);
                Console.WriteLine("Введите:");
                Console.WriteLine("\t1: bold");
                Console.WriteLine("\t2: italic");
                Console.WriteLine("\t3: underline");
                if (Byte.TryParse(Console.ReadLine(), out enter))
                {
                    if (enter < 1 || enter > 3)
                    {
                        Console.WriteLine("Incorrect number.");
                        continue;
                    }
                    if (fs.HasFlag((FontStyle)Math.Pow(2,enter-1)))
                    {
                        fs ^= (FontStyle)Math.Pow(2,enter - 1);
                    }
                    else
                    {
                        fs |= (FontStyle)Math.Pow(2,enter - 1);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                }
                numberOfIterations++;
                if (numberOfIterations == 10)
                {
                    Console.WriteLine("Enough!");
                    Console.ReadLine();
                }
            }
        }
    }
}
