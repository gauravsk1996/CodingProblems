using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class StringProblems
    {
        public StringProblems()
        {
            Console.WriteLine(AppendRemove("HackerRank", "HackerEarth", 9));
        }

        /// <summary>
        /// We need to replace original string with replacement string character by character and if we can do that within functionCount then return new original string
        /// we need to remove character from original string and decrese functionCount by 1 and add character from replacement string and decrese functionCount by 1
        /// eg. input "HackerEarth", "HackerRank", 9
        /// output = "HackerRank"
        /// We first need to delete "Earth" characters => functionCount decrese by 5
        /// then we need to add "Rank" characters => functionCount decrese by 4
        /// At the end functionCount = 0 therefore question is Valid and return "HackerRank"
        /// if in input functionCount <> 9 then show "Failed...!!!!!" 
        /// </summary>
        /// <param name="orginalString">original string</param>
        /// <param name="replacementString">replacement string</param>
        /// <param name="functionCount">times till which char operations should be made on original string</param>
        /// <returns>new original String</returns>
        private string AppendRemove(string orginalString, string replacementString, int functionCount)
        {
            List<int> differentChars = Difference(orginalString, replacementString);
            List<char> originalChars = orginalString.ToCharArray().ToList();
            List<char> replacementChars = replacementString.ToCharArray().ToList();
            functionCount -= differentChars.Count();
            if (orginalString.Length > replacementString.Length)
            {
                for (int i = replacementChars.Count - 1; i < orginalString.Length; i++)
                {
                    functionCount--;
                    originalChars[i] = '\0';
                }
            }
            foreach (int item in differentChars)
            {
                functionCount--;
                originalChars[item] = replacementString[item];
            }
            if (replacementString.Length > orginalString.Length)
            {
                for (int i = originalChars.Count; i < replacementString.Length; i++)
                {
                    functionCount--;
                    originalChars.Add(replacementChars[i]);
                }
            }
            if (functionCount < 0)
            {
                Console.WriteLine("Failed...!!!!!");
            }
            return new string(originalChars.ToArray());
        }

        private List<int> Difference(string orginalString, string replacementString)
        {
            List<int> differentChars = new List<int>();
            for (int i = 0; i < orginalString.Length; i++)
            {
                if (replacementString.Length > i && orginalString[i] != replacementString[i])
                {
                    differentChars.Add(i);
                }
            }
            return differentChars;
        }
    }
}
