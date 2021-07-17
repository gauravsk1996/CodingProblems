using System;
using System.Diagnostics;

namespace CodingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //Execute your Code here 

            //new LinkedListProblems();
            //new StringProblems();
            //new TowerProblems();
            //new MiscProblems();
            BinarySequence bSequence = new BinarySequence();
            bSequence.PrintAllSequences(new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' }, 3);

            stopwatch.Stop();
            Console.WriteLine($"Time Elapsed in Executing Code is : {stopwatch.ElapsedMilliseconds} Miliseconds");
            //Done
            Console.ReadLine();
        }
    }
}
