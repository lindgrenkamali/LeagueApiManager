using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal class Input
    {
        internal static async Task<string> Key()
        {
            Console.WriteLine("Input your API-key");

            string apiKey = "";

            bool validKey = false;

            while (validKey == false)
            {
                apiKey = Console.ReadLine();
                validKey = await ApiKey.Verify(apiKey);
            }

            return apiKey;
        }

        internal static int Loop(int min, int max)
        {
            int intKey = -1;

            while (intKey > max || intKey < min)
            {
                int.TryParse(Console.ReadLine(), out intKey);
            }

            return intKey;
        }
    }
}
