// Simple Arabic (decimal) to Roman Numerals converter by Silvio Duka
// The name of Arabic numerals is also Hindu-Arabic numerals
// Convert numbers from 1 to 3999 (from I to MMMCMXCIX)
// https://en.wikipedia.org/wiki/Roman_numerals
// Some examples:
// 155 - CLV
// 1823 - MDCCCXXIII
// 2018 - MMXVIII
// 19 - XIX
//
// Last modified date: 2018-01-09
//
// Try to input value: 155

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
    class Converter
    {
        static void Main(string[] args)
        {
            Converter c = new Converter();

            Console.Write("Input a valid Arabic (Integer/Decimal) number: ");

            string input = Console.ReadLine().Trim();

            int n;
            if (Int32.TryParse(input, out n) == true)
            {
                if (n > 0 && n < 4000)
                {
                    c.ConvertToRoman(input);
                }
                else
                {
                    Console.WriteLine("Only numbers between 1-3999 are allowed...");
                }
            }
            else
            {
                Console.WriteLine("Please, enter a valid number...");
            }
        }

        public void ConvertToRoman(string arabic)
        {
            var roman = "";  // Roman numerals result
            var d = 0;       // current digit
            var p = -1;     // current position

            string[,] sy = {{ "I","V","X" },   // define the symbol for 1, 5 and 10
                            { "X","L","C" },   // define the symbol for 10, 50 and 100
                            { "C","D","M" },   // define the symbol for 100, 500 and 1000
                            { "M","", ""  },}; // define the symbol for 1000

            for (var i = arabic.Length - 1; i >= 0; i--)
            {
                d = Int32.Parse(arabic[i].ToString());
                p++;

                if (d == 0) { continue; }
                if (d <= 3) { roman = new String(sy[p, 0][0], d) + roman; continue; }
                if (d == 4) { roman = sy[p, 0] + sy[p, 1] + roman; continue; }
                if (d == 5) { roman = sy[p, 1] + roman; continue; }
                if (d <= 8) { roman = sy[p, 1] + new String(sy[p, 0][0], d - 5) + roman; continue; }
                if (d == 9) { roman = sy[p, 0] + sy[p, 2] + roman; continue; }
            }

            Console.WriteLine("The number " + arabic + " converted in Roman numeral is: " + roman);
        }
    }
}
