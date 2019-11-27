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
            int a = 0, b = 0;
            bool flagA = false, flagB = false;
            while (!flagA)
            {
                Console.WriteLine("Enter a:");
                if (int.TryParse(Console.ReadLine(),out a))
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
                if (int.TryParse(Console.ReadLine(),out b))
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
        }

        /// <summary>
        /// Requests N from a user and prints a rectangular triangle made of *.
        /// </summary>
        public static void Triangle_1_2()
        {
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter N.");
                if (int.TryParse(Console.ReadLine(),out n))
                {
                    if (n > 0)
                    {
                        Console.WriteLine("Using two for-loops:");
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j<= i; j++)
                            {
                                Console.Write('*');
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        Console.WriteLine("Using StringBuilder:");
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
        }

        /// <summary>
        /// Requests N from a user and prints an isosceles triangle made of *.
        /// </summary>
        public static void AnotherTriangle_1_3()
        {
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter N.");
                if (int.TryParse(Console.ReadLine(),out n))
                {
                    if (n > 0)
                    {
                        Console.WriteLine("Using for-loops:");
                        for (int i = 1; i <= n; i++)
                        {
                            for (int j = 0; j < n-i; j++)
                            {
                                Console.Write(' ');
                            }
                            for (int k = 0; k < 2*i-1; k++)
                            {
                                Console.Write('*');
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        Console.WriteLine("Using StringBuilder:");
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
        }

        /// <summary>
        /// Requests N from a user and prints an Xmas tree made of *.
        /// </summary>
        public static void XmasTree_1_4()
        {
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter N.");
                if (int.TryParse(Console.ReadLine(),out n))
                {
                    if (n > 0)
                    {
                        Console.WriteLine("Using for-loops (complex way):");
                        for (int l = 1; l <= n; l++)
                        {
                            for (int i = 1; i <= l; i++)
                            {
                                for (int j = 0; j < n - i; j++)
                                {
                                    Console.Write(' ');
                                }
                                for (int k = 0; k < 2 * i - 1; k++)
                                {
                                    Console.Write('*');
                                }
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine();

                        Console.WriteLine("Using String Builder (simpler way):");
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
                            sbTree.Append(Environment.NewLine);
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
        }

        /// <summary>
        /// Finds the sum of numbers less than 1000 and multiple of 3 or 5.
        /// </summary>
        public static void SumOfNumbers_1_5()
        {
            Console.WriteLine("Using two loops (check for 3 in one (from 3 to 999 inc by 3) and for 5 in another(from 5 to 999 inc by 5)).");
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
            Console.WriteLine("Sum of numbers less than 1000 and multiple of 3 or 5: {0}", sum);
            Console.WriteLine();

            Console.WriteLine("Using one loop (check for 3 and 5 (from 3 to 999 inc by 1))");
            sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum of numbers less than 1000 and multiple of 3 or 5: {0}" ,sum);
            Console.WriteLine();
        }

        /// <summary>
        /// Enumeration for font adjustment.
        /// </summary>
        [Flags]
        enum FontStyle : byte
        {
            None = 0,
            Bold = 0x01,
            Italic = 0x02,
            Underline = 0x04,
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
                if (byte.TryParse(Console.ReadLine(), out enter))
                {
                    if (enter < 1 || enter > 3)
                    {
                        Console.WriteLine("Incorrect number.");
                        continue;
                    }
                    fs ^= (FontStyle)Math.Pow(2,enter - 1);
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                }
                numberOfIterations++;
                if (numberOfIterations == 10)
                {
                    Console.WriteLine("Enough!");
                }
            }
        }
    }
}
