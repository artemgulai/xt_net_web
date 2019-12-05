using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.DynamicArray
{
    class DynamicArrayDemo
    {
        public static void SimpleDemo()
        {
            #region Creating DynamicArray
            Console.Clear();
            Console.WriteLine("Task 3.4. Dynamic Array." + Environment.NewLine);
         
            Console.WriteLine("Creating DynamicArray in 3 ways." + Environment.NewLine);
            Console.WriteLine("Creating empty DynamicArray of ints with default capacity.");
            DynamicArray<int> intDynamicArray = new DynamicArray<int>();
            Console.WriteLine($"intDynamicArray. Length = {intDynamicArray.Length}. " + 
                $"Capacity = {intDynamicArray.Capacity}. Type = {intDynamicArray.GetType()}.");
            Console.WriteLine("Press enter to create another DynamicArray");
            Console.ReadLine();

            Console.WriteLine("Creating empty DynamicArray of strings with initial capacity equal to 45.");
            DynamicArray<string> stringDynamicArray = new DynamicArray<string>(45);
            Console.WriteLine($"stringDynamicArray. Length = {stringDynamicArray.Length}. " +
                $"Capacity = {stringDynamicArray.Capacity}. Type = {stringDynamicArray.GetType()}.");
            Console.WriteLine("Press enter to create another DynamicArray");
            Console.ReadLine();

            Console.WriteLine("Creating DynamicArray based on array of doubles.");
            double[] baseArray = new double[] { 34.3,0.04,-232.123,9431,0,12312.12637 };
            Console.Write($"Array of doubles. Type = {baseArray.GetType()}." + Environment.NewLine + "{ ");
            foreach (var item in baseArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
            DynamicArray<double> doubleDynamicArray = new DynamicArray<double>(baseArray);
            Console.WriteLine("DynamicArray.");
            Console.WriteLine(doubleDynamicArray);
            Console.WriteLine($"doubleDynamicArray. Length = {doubleDynamicArray.Length}. " +
                $"Capacity = {doubleDynamicArray.Capacity}. Type = {doubleDynamicArray.GetType()}.");
            Console.WriteLine(Environment.NewLine + "Press enter to go to demonstration of DynamicArray functionality.");
            Console.ReadLine();
            #endregion

            #region DynamicArray Add and AddRange
            Console.Clear();
            Console.WriteLine("Task 3.4. Dynamic Array." + Environment.NewLine);
            Console.WriteLine("Demonstration of DynamicArray Add methods." + Environment.NewLine);

            Console.WriteLine("Let's start with the following DynamicArray<int>:");
            DynamicArray<int> dArr = new DynamicArray<int>(new int[] { 1,2,3,4,5,1,2,3,4,6,5,3,4,2,1 });
            dArr.ShowInfo();
            Console.WriteLine(dArr);
            Console.WriteLine(Environment.NewLine + "Press enter to add 56 to the end of DynamicArray.");
            Console.ReadLine();

            dArr.Add(56);
            dArr.ShowInfo();
            Console.WriteLine(dArr);
            Console.WriteLine("Length is increased by 1, Capacity is doubled.");
            Console.WriteLine(Environment.NewLine + "Press enter to add -10 to the end.");
            Console.ReadLine();

            dArr.Add(10);
            dArr.ShowInfo();
            Console.WriteLine(dArr);
            Console.WriteLine("Length is increased by 1, Capacity is the same.");
            Console.WriteLine(Environment.NewLine +  "Press enter to add a List<int> to the end.");
            Console.ReadLine();

            List<int> listToAdd = new List<int>() { 12,14,85,-45,87,13,15,9,85,43,94,103,-54,-67,-985, 5463 };
            Console.WriteLine($"List<int> = {listToAdd}.");
            Console.Write("{ ");
            foreach (var item in listToAdd)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");

            dArr.AddRange(listToAdd);
            dArr.ShowInfo();
            Console.WriteLine(dArr);
            Console.WriteLine("Length is increased by the Legth of the List<int>. " +
                "Capacity is increased in such way to contain all elements of List<int>");

            Console.WriteLine(Environment.NewLine + "Press enter to go to demonstration of Remove methods.");
            Console.ReadLine();
            #endregion

            #region Dynamic Remove and RemoveAll
            Console.Clear();
            Console.WriteLine("Task 3.4. Dynamic Array." + Environment.NewLine);
            Console.WriteLine("Demonstration of DynamicArray Remove methods." + Environment.NewLine);

            Console.WriteLine("Ok, we have the following DynamicArray:");
            Console.WriteLine(dArr);
            dArr.ShowInfo();

            Console.WriteLine(Environment.NewLine + "Press enter to remove the first entry of 1");
            Console.ReadLine();
            Console.WriteLine($"1 is removed: {dArr.Remove(1)}" );
            Console.WriteLine(dArr);
            dArr.ShowInfo();
            Console.WriteLine("Length is decreased by 1, Capacity is the same.");

            Console.WriteLine(Environment.NewLine + "Press enter to remove 14.");
            Console.ReadLine();

            Console.WriteLine($"14 is removed: {dArr.Remove(14)}");
            Console.WriteLine(dArr);
            Console.WriteLine(Environment.NewLine + "Press enter to remove 100000 (our DynamicArray does'n contain 100000).");
            Console.ReadLine();
            Console.WriteLine($"100000 is removed: {dArr.Remove(100000)}");
            
            Console.WriteLine(Environment.NewLine + "Press enter to remove all entries of 3.");
            Console.ReadLine();

            Console.WriteLine("DynamicArray before removing 3's:" + Environment.NewLine + dArr);
            Console.WriteLine($"3's are removed: {dArr.RemoveAll(3)}");
            Console.WriteLine("DynamicArray after removing 3's:" + Environment.NewLine + dArr);

            Console.WriteLine(Environment.NewLine + "Press enter to remove 3's again.");
            Console.ReadLine();
            Console.WriteLine($"3's are removed: {dArr.RemoveAll(3)}");

            Console.WriteLine(Environment.NewLine + "Press enter to remove an item at position 8.");
            Console.ReadLine();
            Console.WriteLine($"An item at position 8 is removed: {dArr.RemoveAt(8)}");
            Console.WriteLine(dArr);

            Console.WriteLine(Environment.NewLine + "Press enter to remove an item at position -10.");
            Console.ReadLine();
            try
            {
                Console.WriteLine($"An item at position -10 is removed: {dArr.RemoveAt(-10)}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.GetType() + " is thrown.");
            }

            Console.WriteLine(Environment.NewLine + "Press enter to go to Insert demonstration.");
            Console.ReadLine();
            #endregion

            #region DynamicArray Insert
            Console.Clear();
            Console.WriteLine("Task 3.4. Dynamic Array." + Environment.NewLine);
            Console.WriteLine("Demonstration of DynamicArray Insert method." + Environment.NewLine);

            Console.WriteLine("Ok, we have the following DynamicArray:");
            Console.WriteLine(dArr);
            dArr.ShowInfo();

            Console.WriteLine(Environment.NewLine + "Press enter to Insert 12345 to position 0.");
            Console.ReadLine();

            Console.WriteLine($"12345 is inserted to position 0: {dArr.Insert(12345, 0)}");
            Console.WriteLine(dArr);

            Console.WriteLine(Environment.NewLine + "Press enter to Insert 12345 to position Length-1.");
            Console.ReadLine();

            Console.WriteLine($"12345 is inserted to position Length-1: {dArr.Insert(12345,dArr.Length-1)}");
            Console.WriteLine(dArr);

            Console.WriteLine(Environment.NewLine + "Press enter to Insert 213 to position -1.");
            Console.ReadLine();
            try
            {
                Console.WriteLine($"213 is inserted to position -1: {dArr.Insert(213,-1)}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.GetType() + " is thrown.");
            }

            Console.WriteLine(Environment.NewLine + "Press enter to Insert 213 to position Length.");
            Console.ReadLine();
            try
            {
                Console.WriteLine($"213 is inserted to position Length: {dArr.Insert(213,dArr.Length)}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.GetType() + " is thrown.");
            }

            Console.WriteLine(Environment.NewLine + "Press enter to go to Indexer demostration.");
            Console.ReadLine();
            #endregion

            #region DynamicArray Indexer
            Console.Clear();
            Console.WriteLine("Task 3.4. Dynamic Array." + Environment.NewLine);
            Console.WriteLine("Demonstration of DynamicArray Insert method." + Environment.NewLine);

            Console.WriteLine("Ok, we have the following DynamicArray:");
            Console.WriteLine(dArr);
            dArr.ShowInfo();

            Console.WriteLine(Environment.NewLine + "Press enter to get element by index 4:");
            Console.ReadLine();
            Console.WriteLine($"dynamicArray[4] = {dArr[4]}");

            Console.WriteLine(Environment.NewLine + "Press enter to get element by index 0:");
            Console.ReadLine();
            Console.WriteLine($"dynamicArray[0] = {dArr[0]}");

            Console.WriteLine(Environment.NewLine + "Press enter to get element by index Length-1:");
            Console.ReadLine();
            Console.WriteLine($"dynamicArray[0] = {dArr[dArr.Length - 1]}");

            Console.WriteLine(Environment.NewLine + "Press enter to get element by index -5.");
            Console.ReadLine();
            try
            {
                Console.WriteLine($"dynamicArray[-5] = {dArr[-5]}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.GetType() + " is thrown");
            }

            Console.WriteLine(Environment.NewLine + "Press enter to get element by index Length.");
            Console.ReadLine();
            try
            {
                Console.WriteLine($"dynamicArray[-5] = {dArr[dArr.Length]}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.GetType() + " is thrown");
            }
            Console.ReadLine();
            #endregion

            #region DynamicArray Foreach
            Console.Clear();
            Console.WriteLine("Task 3.4. Dynamic Array." + Environment.NewLine);
            Console.WriteLine("Demonstration of DynamicArray Foreach." + Environment.NewLine);

            Console.WriteLine("Ok, we have the following DynamicArray:");
            Console.WriteLine(dArr);
            dArr.ShowInfo();

            Console.WriteLine(Environment.NewLine + "Press enter to show all elements of DynamicArray using foreach.");
            Console.ReadLine();

            foreach(var item in dArr)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Press enter to exit DynamicArray demonstration.");
            Console.ReadLine();
            #endregion
        }

        public static void HardcoreDemo()
        {

        }

        public static void CycledDemo()
        {

        }
    }
}
