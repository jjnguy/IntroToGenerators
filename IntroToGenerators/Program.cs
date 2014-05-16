using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToGenerators
{
    public class Program
    {
        static void Main(string[] Args)
        {
            try
            {
                var allNumbers = Count();
                foreach (var num in allNumbers)
                {
                    Console.WriteLine(num);
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Lists every positive int
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> Count()
        {
            // what goes here?
            for (var i = 0; i < int.MaxValue; i++)
            {
                yield return i;
            }
        }
    }
}
