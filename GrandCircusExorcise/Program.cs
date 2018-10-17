using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GrandCircusExorcise
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //make a string array of size 'n'

                string[] words = new string[GetNumber("How many words would you like to enter?")];




                //prompt user to fill array

                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = GetWords();
                    Console.Clear();
                    Console.WriteLine("Word {0} of {1}", i + 2, words.Length);
                }



                //list the items in the array

                Console.Clear();
                int counter = 0;
                foreach (string word in words)
                {
                    Console.WriteLine("{0} - {1}", counter, word);
                    counter++;
                }



                //prompt user to enter 2 numbers, index in array, index in string

                int wordLocation = GetWord(words);

                char letterGrabber = GetLetter(words[wordLocation]);




                //print the character at that location

                Console.WriteLine("The chosen character is {0}", letterGrabber);



                //ask to go gain or close

                Console.WriteLine("\n\nPress 'y' to go again, anything else to exit!");

                char answer = Console.ReadKey(true).KeyChar;

                if (answer == 'y' || answer == 'Y')
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye!!!");
                    Console.ReadKey();
                    break;
                }



            }



        }

        
        static int GetNumber(string message)
        {
            while (true)
            {
                int number = 0;

                Console.WriteLine(message);

                try
                {
                    number = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please only enter whole numbers\n");
                    continue;
                }

                if (number > 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Please keep numbers positive!");
                }
            }
            
        }


        static string GetWords()
        {
            string word = "";

            while (true)
            {
                
                Console.WriteLine("Please enter a word");

                word = Console.ReadLine();

                if(Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                {
                    return word;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Letters only, please!");
                    continue;
                }


            }
        }


        static int GetWord(string[] words)
        {
            while (true)
            {
                int index = -1;
                string word = "";

                Console.WriteLine("Please enter the location (number) of the word you want to index.");

                try
                {
                    index = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please only enter whole numbers!");
                    continue;
                }

                if (index < 0)
                {
                    Console.WriteLine("Please keep numbers positive!");
                    continue;
                }

                try
                {
                    word = words[index];
                }
                catch
                {
                    Console.WriteLine("Word not found on index, please choose a number between 1 and {0}", words.Length);
                    continue;
                }

                return index;

            }
        }


        static char GetLetter(string word)
        {
            while (true)
            {
                int index = 0;
                char character;

                Console.WriteLine("Please enter the number of the character you would like to return.");

                try
                {
                    index = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please only enter whole numbers!");
                    continue;
                }

                if (index < 0)
                {
                    Console.WriteLine("Please keep numbers positive!");
                    continue;
                }

                try
                {
                    character = word[index - 1];
                }
                catch
                {
                    Console.WriteLine("Letter not found, please choose a number between 1 and {0}", word.Length);
                    continue;
                }

                return character;

            }
        }
        
    }
}
