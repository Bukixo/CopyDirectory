using CopyDirectory.calculation;
using System;

namespace CopyDirectory
{
    class Program
    {


        static void Main(string[] args)
        {
            var calculation = new CalculationMethod();
          
                Console.WriteLine("Please enter your source location");
                string sourcePath = Console.ReadLine();
                Console.WriteLine("Please enter the target location");
                string targetPath = Console.ReadLine();
                calculation.CreateNewDirectory(sourcePath, targetPath);
        }
    }
}
