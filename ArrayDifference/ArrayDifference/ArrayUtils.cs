using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDifference
{
    internal class ArrayUtils
    {
        public static string[] DifferenceWithoutCollections(string[] firstArray, string[] secondArray) {
            for (int i = 0; i < secondArray.Length; i++) {
                inner:
                for (int j = 0; j < firstArray.Length; j++) {
                    if (secondArray[i].Equals(firstArray[j])) { 
                        RemoveElementFromArray(ref firstArray, j);
                        goto inner;
                    }
                }
            }

            return firstArray;
        }

        private static void RemoveElementFromArray(ref string[] array, int index) { 
            string[] newArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)  
                newArray[i] = array[i];
            for (int i = index + 1; i < array.Length; i++) 
                newArray[i - 1] = array[i];
            
            array = newArray;  
        }

        public static List<string> DifferenceWithCollections(string[] firstArray, string[] secondArray) {
            List<string> firstList = firstArray.ToList();
            List<string> secondList = secondArray.ToList();
            firstList.RemoveAll(elementFormFirstList => secondList.Contains(elementFormFirstList));
            return firstList;
        }
    }
}
