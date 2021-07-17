using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems
{
    public class BinarySequence
    {

        public void PrintAllSequences(char[] range, int itemLength)
        {
            string lastElement = ReturnString(range.Last(), itemLength);
            List<Tuple<int, string>> combinations = new List<Tuple<int, string>>();
            combinations.Add(new Tuple<int, string>(1, ReturnString(range.First(), itemLength)));
            while (combinations.Last().Item2 != lastElement)
            {
                StringBuilder builder = new StringBuilder();
                char[] prevString = combinations.Last().Item2.ToCharArray();
                for (int i = 0; i < itemLength; i++)
                {
                    builder.Append(ReturnNextChar(range, i, combinations.Count(), prevString[i]));
                }
                Tuple<int, string> data = new Tuple<int, string>(combinations.Count() + 1, builder.ToString());
                Console.WriteLine($"{data.Item1} : {data.Item2}");
                combinations.Add(data);
            }
            Console.WriteLine($"Total Possibilities created :{combinations.Count()}{Environment.NewLine}Actual Possibilites : {Math.Pow(range.Length, itemLength)}");
        }

        private char ReturnNextChar(char[] range, int itemPosition, int combinationCount, char currentChar)
        {
            int firstCharResetOn = range.Length;
            if (itemPosition == 0)
            {
                if (firstCharResetOn == combinationCount || combinationCount % firstCharResetOn == 0)
                {
                    return range.First();
                }
                int index = range.ToList().IndexOf(currentChar);
                return range[index + 1];
            }
            else
            {
                int thisCharChangesOn = Convert.ToInt32(Math.Pow(firstCharResetOn, itemPosition));
                if (thisCharChangesOn == combinationCount || combinationCount % thisCharChangesOn == 0)
                {
                    if (itemPosition == 3)
                    {

                    }
                    int index = range.ToList().IndexOf(currentChar);
                    if (index + 1 == range.Length)
                    {
                        return range.First();
                    }
                    return range[index + 1];
                }
                return currentChar;
            }
            //return 'a';
        }

        private string ReturnString(char charToAdd, int itemLength)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < itemLength; i++)
            {
                builder.Append(charToAdd);
            }
            return builder.ToString();
        }
    }
}
