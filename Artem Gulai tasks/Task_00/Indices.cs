using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_00
{
    internal static class Indices
    {
        /// <summary>
        /// Method computing the next set of indices of multidimension array (just as in nester for loops)
        /// </summary>
        /// <param name="arrayLength">Array conatining dimensions of multidimension array</param>
        /// <param name="arrayIndex">Array containing indices of multidimension array</param>
        /// <returns>True if the next set is available, else false.</returns>
        public static bool getNextIndices(int[] arrayLength, int[] arrayIndex, int levelNumber = 0)
        {
            int thisLevelArrayLength = arrayLength[levelNumber] - 1; // переменная для сравнения индексов
            // branch for the last comparison
            if (levelNumber == arrayIndex.Length-1)
            {
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

            bool flag = getNextIndices(arrayLength,arrayIndex, levelNumber + 1);

            // branch for other comparisons
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
