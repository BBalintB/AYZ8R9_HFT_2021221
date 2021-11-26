using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Client
{
    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string headline)
        {
            Console.WriteLine($"**\t{headline}\t**");

            foreach (var item in query)
                Console.WriteLine($"* \t{item}\t *");
            
        }
    }
}
