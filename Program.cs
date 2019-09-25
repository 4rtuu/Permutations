using System;
using System.Collections.Generic;

namespace Permutation
{
    class Permute
    {
        private static void Permuting(string str, int x, int y, List<string> strings)
        {
            if (x == y)
            {
                foreach (var old in strings)
                {
                    if (old == str)
                    {
                        return;
                    }
                }
                strings.Add(str);
            }
            else
            {
                for (int i = x; i < y; i++)
                {
                    str = Swap(str, x, i);
                    Permuting(str, x + 1, y, strings);
                }
            }
        }

        public static string Swap(string str, int x, int i)
        {
            char temp;
            char[] charArray = str.ToCharArray();

            if (Char.IsUpper(charArray[x]) || Char.IsUpper(charArray[i]))
            {
                return str;
            }
            else
            {
                temp = charArray[x];
                charArray[x] = charArray[i];
                charArray[i] = temp;
                
                return new string(charArray);
            }
        }

        static bool StringIsAlphabetic(string str, int x, int y)
        {
            char[] tmp = str.ToCharArray();

            if (x != y)
            {
                for (int i = x; i < y; i++)
                {
                    if (!Char.IsLetter(tmp[i]))
                    {
                        Console.WriteLine("Non-Alphabetic character provided for the string, please try again!");
                        return false;
                    }
                }
            }
            return true;
        }

        static void Main()
        {
            while (true) // includes break
            {
                Console.WriteLine("Write some string or what ever:");

                string response = Console.ReadLine();

                Console.WriteLine();

                int n = response.Length;

                if (n == 0)
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();

                    break;
                }

                if (StringIsAlphabetic(response, 0, n) == true)
                {
                    List<string> strings = new List<string>();

                    Permuting(response, 0, n, strings);

                    int a = 0;
                    foreach (var str in strings)
                    {
                        Console.WriteLine(++a + " " + str);
                    }

                    Console.WriteLine("You wrote: " + response);
                }
            }
        }
    }
}
