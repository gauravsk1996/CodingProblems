using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems
{
    public class MiscProblems
    {
        public MiscProblems()
        {
            ProductArray(new int[5] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Output is : {CheckIfTwoNumbersAddUpToANumber(new List<int> { 10, 15, 3, 7 }, 17)}");
        }

        /// <summary>
        /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
        /// For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private bool CheckIfTwoNumbersAddUpToANumber(List<int> numbers, int k)
        {
            HashSet<int> hashset = new HashSet<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (hashset.Contains(k - numbers[i]))
                {
                    return true;
                }
                hashset.Add(numbers[i]);
            }
            return false;
        }

        /// <summary>
        /// Given an array of integers, return a new array such that each element at index i of the new array 
        /// is the product of all the numbers in the original array except the one at i.
        /// For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. 
        /// If our input was [3, 2, 1], the expected output would be [2, 3, 6].
        /// </summary>
        /// <param name="originalArray"></param>
        private void ProductArray(int[] originalArray)
        {
            if (originalArray.Length < 2)
            {
                return;
            }
            int[] newArray = new int[originalArray.Length];
            int[] leftArray = new int[originalArray.Length];
            int[] rightArray = new int[originalArray.Length];
            leftArray[0] = 1;
            rightArray[originalArray.Length - 1] = 1;
            for (int i = 1; i < originalArray.Length; i++)
            {
                leftArray[i] = originalArray[i - 1] * leftArray[i - 1];
            }
            for (int i = originalArray.Length - 2; i >= 0; i--)
            {
                rightArray[i] = originalArray[i + 1] * rightArray[i + 1];
            }
            for (int i = 0; i < originalArray.Length; i++)
            {
                newArray[i] = leftArray[i] * rightArray[i]; 
            }
        }
    }
}
