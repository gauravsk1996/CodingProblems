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
            new TowerProblems();
            
            stopwatch.Stop();
            Console.WriteLine($"Time Elapsed in Executing Code is : {stopwatch.ElapsedMilliseconds} Miliseconds");
            //Done
            Console.ReadLine();
        }
    }
}
