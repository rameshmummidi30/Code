using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using static System.Console;
namespace ConvertNumberToWord
{
    class Program
    {
        static void Main(string[] args)
        {

            int intUserInput = 0;
            bool validUserInput = false;
            string Word = null;
            while (validUserInput == false)
            {
                try
                {
                    Write("Input Number: ");
                    intUserInput = int.Parse(Console.ReadLine()); //try to parse the user input to an int variable
                }
                catch (Exception) { } //catch exception for invalid input.

                if (intUserInput >= 1) //check to see that the user entered int >= 1
                {
                    validUserInput = true;
                    Word = NumberToWord(intUserInput);
                }
                else { WriteLine("Invalid input. "); }

            }//end while

            WriteLine("output Word :" + Word);
            WriteLine("Press any key to exit ");
            ReadKey();
        }


        static string NumberToWord(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWord(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWord(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWord(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWord(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

    }
}
