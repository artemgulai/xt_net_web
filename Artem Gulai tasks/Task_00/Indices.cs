using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_00
{
    static class Indices
    {
        // метод, принимающий массив с размерностями массива и массив с индексами.
        // при каждом вызове метод преобразует массив с индексами так, чтобы он представлял
        // собой следующий набор индексов, как во вложенных циклах for.
        public static bool getNextIndices(int[] arrayLength, int[] arrayIndex, bool printBraces, int levelNumber = 0)
        {
            int thisLevelArrayLength = arrayLength[levelNumber] - 1; // переменная для сравнения индексов
            // ветка для последнего сравнения
            if (levelNumber == arrayIndex.Length-1)
            {
                if (printBraces && (arrayIndex[levelNumber] == 0 ))
                {
                    Console.Write("{");
                }
                if (arrayIndex[levelNumber] < thisLevelArrayLength)
                {
                    arrayIndex[levelNumber]++;
                    return false;
                }
                if (arrayIndex[levelNumber] == thisLevelArrayLength)
                {
                    arrayIndex[levelNumber] = 0;
                    return true;
                }
            }

            bool flag = getNextIndices(arrayLength,arrayIndex, printBraces, levelNumber + 1);

            // ветка для промежуточных сравнений
            if ((arrayIndex[levelNumber] < thisLevelArrayLength) && !flag)
            {
                return false;
            }
            if ((arrayIndex[levelNumber] < thisLevelArrayLength) && flag)
            {
                arrayIndex[levelNumber]++;
                return false;
            }
                
            if ((arrayIndex[levelNumber] == thisLevelArrayLength) && !flag)
            {
                return false;
            }
            if (levelNumber != 0)
            {
                arrayIndex[levelNumber] = 0;
            }
            return true;
        }
    }
}
