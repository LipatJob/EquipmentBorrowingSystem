﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLib
{
    /// <summary>
    /// Author: Job Lipat
    /// Date Updated: August 26, 2020
    /// 
    /// Functions that are commonly used are placed here to allow reuse.
    /// </summary>
    class JHelper
    {
        public static int InputInt(string prompt = "", string parseErrorMessage = "> Please enter a valid value", Func<int, bool> validator = null)
        {
            int value = Int32.MinValue;
            // While the input is invalid, loop
            while (true)
            {
                // Display prompt and ask for input
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out value))
                {
                    // Will continue loop if input is invalid
                    if (validator != null && !validator(value))
                    {
                        continue;
                    }
                    // Will break if the input is parsed and is validated 
                    break;
                }
                else
                {
                    // Display parse error message
                    Console.WriteLine(parseErrorMessage);
                }
            }
            // If loop breaks, then the value is parsed and valid and can now be returned
            return value;
        }

        public static double InputDouble(string prompt = "", string parseErrorMessage = "> Please enter a valid value", Func<double, bool> validator = null)
        {
            double value = double.MinValue;
            // While the input is invalid, loop
            while (true)
            {
                // Display prompt and ask for input
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out value))
                {
                    // Will continue loop if input is invalid
                    if (validator != null && !validator(value))
                    {
                        continue;
                    }
                    // Will break if the input is parsed and is validated 
                    break;
                }
                else
                {
                    // Display parse error message
                    Console.WriteLine(parseErrorMessage);
                }
            }
            // If loop breaks, then the value is parsed and valid and can now be returned
            return value;
        }


        public static float InputFloat(string prompt = "", string parseErrorMessage = "> Please enter a valid value", Func<float, bool> validator = null)
        {
            float value = float.MinValue;
            // While the input is invalid, loop
            while (true)
            {
                // Display prompt and ask for input
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (float.TryParse(input, out value))
                {
                    // Will continue loop if input is invalid
                    if (validator != null && !validator(value))
                    {
                        continue;
                    }
                    // Will break if the input is parsed and is validated 
                    break;
                }
                else
                {
                    // Display parse error message
                    Console.WriteLine(parseErrorMessage);
                }
            }
            // If loop breaks, then the value is parsed and valid and can now be returned
            return value;
        }

        public static short InputShort(string prompt = "", string parseErrorMessage = "> Please enter a valid value", Func<short, bool> validator = null)
        {
            short value = short.MinValue;
            // While the input is invalid, loop
            while (true)
            {
                // Display prompt and ask for input
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (short.TryParse(input, out value))
                {
                    // Will continue loop if input is invalid
                    if (validator != null && !validator(value))
                    {
                        continue;
                    }
                    // Will break if the input is parsed and is validated 
                    break;
                }
                else
                {
                    // Display parse error message
                    Console.WriteLine(parseErrorMessage);
                }
            }
            // If loop breaks, then the value is parsed and valid and can now be returned
            return value;
        }


        public static decimal InputDecimal(string prompt = "", string parseErrorMessage = "> Please enter a valid value", Func<decimal, bool> validator = null)
        {
            decimal value = decimal.MinValue;
            // While the input is invalid, loop
            while (true)
            {
                // Display prompt and ask for input
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out value))
                {
                    // Will continue loop if input is invalid
                    if (validator != null && !validator(value))
                    {
                        continue;
                    }
                    // Will break if the input is parsed and is validated 
                    break;
                }
                else
                {
                    // Display parse error message
                    Console.WriteLine(parseErrorMessage);
                }
            }
            // If loop breaks, then the value is parsed and valid and can now be returned
            return value;
        }

        public static string InputString(string prompt = "", string parseErrorMessage = "> Please enter a valid value", Func<string, bool> validator = null)
        {
            string value = "";
            // While the input is invalid, loop
            while (true)
            {
                // Display prompt and ask for input
                Console.Write(prompt);
                value = Console.ReadLine();
                // Will continue loop if input is invalid
                if (validator != null && !validator(value))
                {
                    continue;
                }
                // Will break if the input is parsed and is validated 
                break;
            }
            // If loop breaks, then the value is parsed and valid and can now be returned
            return value;
        }

        public static char InputChar(string prompt = "", string parseErrorMessage = "> Please enter a valid value", Func<char, bool> validator = null)
        {
            char value = char.MinValue;
            // While the input is invalid, loop
            while (true)
            {
                // Display prompt and ask for input
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (char.TryParse(input, out value))
                {
                    // Will continue loop if input is invalid
                    if (validator != null && !validator(value))
                    {
                        continue;
                    }
                    // Will break if the input is parsed and is validated 
                    break;
                }
                else
                {
                    // Display parse error message
                    Console.WriteLine(parseErrorMessage);
                }
            }
            // If loop breaks, then the value is parsed and valid and can now be returned
            return value;
        }


        public static void ExitPrompt()
        {
            Console.Write("\nPress Return Key to Exit...");
            Console.Read();
        }

        public static bool In<T>(T obj, params T[] args)
        {
            return args.Contains(obj);
        }

    }
}
