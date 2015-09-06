using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var comp1 = new Computer("admin", "bla", new CPU("Intel", 3000), new HDD("IBM", 500), new RAM("IBM", 1000));
            var comp2 = new Computer("admin2", "bla", new CPU("IBM", 3000), new HDD("IBM", 750), new RAM("IBM", 2000));

            Console.WriteLine("COMPUTERS:");
            Console.WriteLine(comp1.ToString());
            Console.WriteLine(comp2.ToString());

            Console.WriteLine("\nAttempt to add computers");
            try
            {
                var comp3 = comp1 + comp2;
            }
            catch(ComputersCompatibilityException e)
            {
                Console.WriteLine(e.Message);
            }

            Computer clonedComp1 = comp1.DeepClone();
            Computer superComp = clonedComp1 + comp1;

            Console.WriteLine("\nSumming the comp1 and its copy");
            Console.WriteLine(superComp.ToString());
            
            Console.ReadKey();
        }
    }
}
