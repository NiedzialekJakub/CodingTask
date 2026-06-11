using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingTask
{
    /// <summary>
    /// This object have a output string with replaced words and the number of coincidences
    /// </summary>
    public class FizzBuzzResult
    {
        public required string OutputString { get; set; }
        public int Count { get; set; }
    }



    /// <summary>
    /// Application logic for processings string based on word position
    /// </summary>
    public class FizzBuzzDetector
    {
        /// <summary>
        /// replaces every 3rd word for Fizz, 5th for Buzz and 15th with FizzBuzz
        /// </summary>
        /// <param name="input">this string need to be processed</param>
        /// <returns>FizzBuzzResult with the modified text and count of replacements</returns>
        /// <exception cref="ArgumentNullException">second contstrain: input string cannot be null</exception>
        /// <exception cref="ArithmeticException">first constrain: Length of the input string: 7 ≤ |s| ≤ 100</exception>

        public FizzBuzzResult getOverlappings(string input)
        {
            // validations
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null");
            }

            if (input.Length < 7 || input.Length > 100)
            {
                throw new ArgumentException("input length must be beetwen 7 and 100");
            }

            // split word where there is spaces and punctuation marks
            string[] tokens = Regex.Split(input, @"(\W+)");

            StringBuilder outputBuilder = new StringBuilder(); // output string
            int wordCount = 0;
            int coincidences = 0;

            foreach(string token in tokens)
            {
                if(string.IsNullOrEmpty(token))
                {
                    continue;
                }

                if (Regex.IsMatch(token, @"^[a-zA-Z0-9]+$")) // is this a word with letters or numbers?
                {
                    wordCount++;
                    if (wordCount % 3 == 0 && wordCount % 5 == 0)
                    {
                        outputBuilder.Append("FizzBuzz");
                        coincidences++;
                    }
                    else if (wordCount % 3 == 0)
                    {
                        outputBuilder.Append("Fizz");
                        coincidences++;
                    }
                    else if (wordCount % 5 == 0)
                    {
                        outputBuilder.Append("Buzz");
                        coincidences++;
                    }
                    else
                    {
                        outputBuilder.Append(token);
                    }
                }
                else
                {
                    outputBuilder.Append(token); //Keep whitespace and punctuation marks
                }
            }

            return new FizzBuzzResult
            {
                OutputString = outputBuilder.ToString(),
                Count = coincidences
            };
        }
    }
}
