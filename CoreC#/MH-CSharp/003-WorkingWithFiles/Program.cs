using System;
using System.IO;
using System.Linq;

namespace _003_WorkingWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFileAndDiplayNumberOfWords();
            ReadFileAndDisplayTheLongestWord();
        }

        private static void ReadFileAndDisplayTheLongestWord()
        {
            var path = @"d:\study\test.txt";

            if (File.Exists(path))
            {
                var longestWord = File.ReadAllText(path)
                                .Split(' ')
                                .OrderBy(w => w)
                                .FirstOrDefault();

                Console.WriteLine("The longest word in file: " + longestWord);
            }
            else
            {
                Console.WriteLine("File was not found");
            }
        }

        private static void ReadFileAndDiplayNumberOfWords()
        {
            var path = @"d:\study\test.txt";

            if (File.Exists(path))
            {
                var count = File.ReadAllText(path)
                                .Split(' ')
                                .Count();

                Console.WriteLine("number of words in file: " + count);
            }
            else
            {
                Console.WriteLine("File was not found");
            }
        }
    }
}
