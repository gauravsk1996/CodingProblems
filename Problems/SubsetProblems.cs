using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class SubsetProblems
    {
        public SubsetProblems()
        {
            Console.WriteLine($"Output is => {SplitArrayToSubsetsandReturnMaxSum(new int[6] { 5, 1, 2, 7, 3, 4 }, 3)}");
        }

        /// <summary>
        /// Given an array of N numbers and an integer K, your task is to split N into K partitions
        /// such that the maximum sum of any partition is minimized. Return the sum.
        ///
        /// For eg. Given 
        /// N = [5, 1, 2, 7, 3, 4], K = 3
        /// you should return 8, since optimal partition is [5, 1, 2], [7], [3, 4]
        /// </summary>
        /// <param name="numbers">inital array</param>
        /// <param name="totalSubsets">maximum number of subsets we are allowed to make</param>
        /// <returns>max sum from the subsets</returns>
        private int SplitArrayToSubsetsandReturnMaxSum(int[] numbers, int totalSubsets)
        {
            Array.Sort(numbers);
            Array.Reverse(numbers);
            List<int>[] subsets = new List<int>[totalSubsets];
            //Initialize all the subsets
            for (int i = 0; i < subsets.Length; i++)
            {
                subsets[i] = new List<int>();
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                int subCount = 0;
                while (subCount < totalSubsets)
                {
                    if (subCount + 1 != subsets.Length && subsets[subCount].Sum() > subsets[subCount + 1].Sum())
                    {
                        subCount++;
                    }
                    else
                    {
                        subsets[subCount].Add(numbers[i]);
                        break;
                    }
                }
            }
            return (from maxValue in subsets select maxValue.Sum()).Max();
        }
    }
}
