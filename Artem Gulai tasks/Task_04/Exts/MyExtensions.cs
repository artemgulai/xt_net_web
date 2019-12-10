using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_04.Exts
{
    public static class MyExtensions
    {
        #region Array extensions
        // Generic method with delegate providing summation rule
        public static T MySum<T>(this T[] array, Func<T,T,T> summation)
        {
            T sum = default;
            foreach (var item in array)
            {
                sum = summation(sum,item);
            }
            return sum;
        }

        public static long MySum(this byte[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static long MySum(this sbyte[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static long MySum(this short[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static long MySum(this ushort[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static long MySum(this int[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static long MySum(this uint[] array)
        {
            long sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static BigInteger MySum(this long[] array)
        {
            BigInteger sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static BigInteger MySum(this ulong[] array)
        {
            BigInteger sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static double MySum(this double[] array)
        {
            double sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static double MySum(this float[] array)
        {
            double sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }
        #endregion

        public static bool IsPositiveInt(this string value)
        {
            if (value == null || value.Length == 0)
                return false;
            string trimmedString = value.Trim();
            if (trimmedString.Length == 0) return false;
            if (trimmedString.Length == 1 && trimmedString[0] == '0') return false;
            foreach (var item in trimmedString)
            {
                if (!Char.IsDigit(item))
                    return false;
            }
            return true;
        }

        public static bool IsInt(this string value)
        {
            if (value == null || value.Length == 0)
                return false;
            string trimmedString = value.Trim();
            if (trimmedString.Length == 1 && !Char.IsDigit(trimmedString[0])) return false;
            else
            {
                for (int i = 1; i < trimmedString.Length; i++)
                {
                    if (!Char.IsDigit(trimmedString[i]))
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Parses a string into a System.Int32.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="strToParse">String containing text representation of a number to parse.</param>
        /// <returns>Parsed System.Int32 value</returns>
        public static int MyParse(this int value, string strToParse)
        {
            if (strToParse.IsInt())
            {
                int exp = 0;
                long result = 0;
                //parse negative integer
                if (strToParse[0] == '-')
                {
                    checked // used to catch overflow for very large numbers
                    {
                        for (int i = strToParse.Length - 1; i >= 1; i--)
                        {
                            result += (long)Math.Pow(10,exp++) * (strToParse[i] - '0');
                        }
                    }
                    if (result > (long)int.MaxValue + 1)
                        throw new OverflowException("The number is less than System.Int32.MinValue.");
                    return (int)-result;
                }
                //parse positive integer
                else
                {
                    checked // used to catch overflow for very large numbers
                    {
                        for (int i = strToParse.Length - 1; i >= 0; i--)
                        {
                            result += (long)Math.Pow(10,exp++) * (strToParse[i] - '0');
                        }
                    }
                    if (result > int.MaxValue)
                        throw new OverflowException("The number is greater than System.Int32.MaxValue.");
                    return (int)result;
                }
            }
            throw new FormatException("You have not entered an integer.");
        }
    }

    public class MyExtensionsDemo
    {
        public static void NumberArrayDemo()
        {
            Console.Clear();
            Console.WriteLine("Task 4.4. Number array sum.");
            Console.WriteLine(Environment.NewLine + "All number arrays now have MySum() method, " +
                "calculating a sum of all elements.");

            Console.WriteLine("Press enter to calculate a sum of byte[] array.");
            Console.ReadLine();
            var rand = new Random();
            var byteArr = new byte[20];
            for (int i = 0; i < byteArr.Length; i++)
            {
                byteArr[i] = (byte)rand.Next(byte.MinValue,byte.MaxValue);
            }
            Console.WriteLine(byteArr);
            Task_01.CSharpLanguage.Display1DArray<byte>(byteArr);
            Console.WriteLine();
            Console.WriteLine($"byte[].MySum() = {byteArr.MySum()}");

            Console.WriteLine(Environment.NewLine + "Press enter to calculate a sum of short[] array.");
            Console.ReadLine();
            var shortArr = new short[20];
            for (int i = 0; i < shortArr.Length; i++)
            {
                shortArr[i] = (short)rand.Next(short.MinValue,short.MaxValue);
            }
            Console.WriteLine(shortArr);
            Task_01.CSharpLanguage.Display1DArray<short>(shortArr);
            Console.WriteLine();
            Console.WriteLine($"short[].MySum() = {shortArr.MySum()}");

            Console.WriteLine(Environment.NewLine + "Press enter to calculate a sum of int[] array.");
            Console.ReadLine();
            var intArr = new int[20];
            for (int i = 0; i < intArr.Length; i++)
            {
                intArr[i] = rand.Next(int.MinValue,int.MaxValue);
            }
            Console.WriteLine(intArr);
            Task_01.CSharpLanguage.Display1DArray<int>(intArr);
            Console.WriteLine();
            Console.WriteLine($"int[].MySum() = {intArr.MySum()}");

            Console.WriteLine(Environment.NewLine + "Press enter to calculate a sum of long[] array.");
            Console.ReadLine();
            var longArr = new long[20];
            for (int i = 0; i < longArr.Length; i++)
            {
                longArr[i] = rand.Next(0,int.MaxValue);
            }
            Console.WriteLine(longArr);
            Task_01.CSharpLanguage.Display1DArray<long>(longArr);
            Console.WriteLine();
            Console.WriteLine($"long[].MySum() = {longArr.MySum()}");

            Console.WriteLine(Environment.NewLine + "Press enter to calculate a sum of double[] array.");
            Console.ReadLine();
            var doubleArr = new double[20];
            for (int i = 0; i < doubleArr.Length; i++)
            {
                doubleArr[i] = rand.NextDouble() * 200000 - 100000;
            }
            Console.WriteLine(doubleArr);
            Task_01.CSharpLanguage.Display1DArray<double>(doubleArr);
            Console.WriteLine();
            Console.WriteLine($"long[].MySum() = {doubleArr.MySum():N2}");

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void StringToIntParseDemo()
        {
            Console.Clear();
            Console.WriteLine("Task 4.5. To Int or Not to Int.");
            
            while (true)
            {
                Console.WriteLine("Enter a number.");
                string str = Console.ReadLine().Trim();
                Console.WriteLine($"{str} is positive integer: {str.IsPositiveInt()}");
                Console.WriteLine("Try again? y/n");
                var again = Console.ReadLine();
                if (again.Length != 0 && (Char.ToLower(again[0]) == 'y'))
                    continue;
                break;
            }

            Console.WriteLine("Bonus! Enter a number and discover if it can be converted into System.Int32.");
            while (true)
            {
                Console.WriteLine("Enter a number.");
                try
                {
                    int a = -1;
                    a = a.MyParse(Console.ReadLine());
                    Console.WriteLine($"{a} can be converted into System.Int32.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType());
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Try again? y/n");
                var again = Console.ReadLine();
                if (again.Length != 0 && (Char.ToLower(again[0]) == 'y'))
                    continue;
                break;
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
