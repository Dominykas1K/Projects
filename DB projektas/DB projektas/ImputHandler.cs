using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_projektas
{
    public static class ImputHandler
    {
        public static string FormatedInput()
        {
            string input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return string.Join(" ", input.Split(' ')
                .Where(word => !string.IsNullOrEmpty(word))
                .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }
    }
}
