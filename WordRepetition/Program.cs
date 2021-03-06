﻿using System;
using System.Diagnostics;

namespace WordRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            IWordRepetitionFinder finder = new BruteForceFinder();
            var testString = FileReader.ReadFileAsString();
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            //--Brute force --
            stopWatch.Start();
            var result = finder.FindRepetition(testString);

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("Brute force runTime " + ts.TotalMilliseconds);
            //stopWatch.Reset();

            //-- New method --
            finder = new MimicaRepetitionFinder();
            stopWatch.Start();
            var result2 = finder.FindRepetition(testString);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            //Console.WriteLine("New method runTime " + ts.TotalMilliseconds);
            
            Console.ReadLine();
        }
    }
}
