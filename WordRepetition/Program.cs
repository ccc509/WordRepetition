using System;
using System.Diagnostics;

namespace WordRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            IWordRepeatitionFinder finder = new BruteForceFinder();
            var testString = FileReader.ReadFileAsString();
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            //--Brute force--
            stopWatch.Start();
            for (var i=0;i<20;i++)
            {
                var result = finder.FindRepetition(testString);
            }
            
            stopWatch.Stop();
            
            ts = stopWatch.Elapsed;
            Console.WriteLine("Brute force runTime " + ts.TotalMilliseconds);
            stopWatch.Reset();
            finder = new MimicaRepeatitionFinder();
            stopWatch.Start();
            for (var i = 0; i < 20; i++)
            {
                var result2 = finder.FindRepetition(testString);
            }
               
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("New method runTime " + ts.TotalMilliseconds);
            
            Console.ReadLine();
        }
    }
}
