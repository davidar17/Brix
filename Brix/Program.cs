using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
     
     /* There is a text file with 1M lines of 5 characters long alphanumerical strings.
        Write a console app which asks the user for an input of a 5 characters long
        alphanumerical string, searches it in the file (or any preloaded in-memory data
        structure).
        The equality ignores characters order but takes characters appearances count
        into consideration.
        For example:
        ABCDD and DCDAB should be considered equal, but ABCDD and ABCCD are not
        because in the first string D appears twice and in the second string C appears
        twice.
        The app should display the result of the search on the screen (the input and
        the match). The search algorithm should run as fast as possible (initial load
        time can as be as long as needed) most efficient Time complexity- please state
        what it is*/

namespace Brix
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "DummyDictionary.txt";
            
            // Step 1 - create 1M strings menu 
            var file = DataStructureCreation(fileName);
            
            // Step 2 - search Menu
            SearchMenu(file);
        }

        private static EfficientDataStructure DataStructureCreation(string fileName)
        {
            EfficientDataStructure file = null;
            string menu;
            do
            {
                DataStructureCreationMenu();
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1": 
                        var strings = CreateDummyStrings();
                        FileHandler.Write(fileName, strings);
                        strings = FileHandler.Read(fileName);
                        file = new EfficientDataStructure(strings);
                        menu = "3";
                        break;
                    case "2": 
                        strings = CreateDummyStrings();
                        file = new EfficientDataStructure(strings);
                        menu = "3";
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input");
                        break;
                }
            } while (menu != "3");

            return file;
        }

        private static void SearchMenu(EfficientDataStructure file)
        {
            string word;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Search Menu");
                Console.WriteLine("Insert 5 characters long alphanumerical strings.To exit insert \"exit\"");

                word = Console.ReadLine();

                if (word == "exit")
                    return;

                var isValid = ValidateInput(word);

                if (isValid == false)
                {
                    Console.WriteLine("\nInvalid Input");
                    Console.ReadKey(); // wait to user response
                    continue;
                }

                var result = file.Search(word);

                if (result == null)
                {
                    Console.WriteLine("No results\n");
                }
                else
                {
                    Console.WriteLine($"\nYour input : {word}");
                    Console.WriteLine("Search result : \n");
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }

                Console.ReadKey(); // wait to user response
            }
        }


        private static bool ValidateInput(string strToSearch)
        {
            if (strToSearch.Length == 5 && strToSearch.All(char.IsLetter))
            {
                return true;
            }

            return false;
        }

        private static void DataStructureCreationMenu()
        {

            Console.WriteLine("********************");
            Console.WriteLine("*        Menu      *");
            Console.WriteLine("********************");
            Console.WriteLine("1 - Create 1M 5 characters long alphanumerical strings File and load it file to internal memory");
            Console.WriteLine("2 - Create 1M 5 characters long alphanumerical strings and load it to internal memory (without file creation)");
            
        }

        private static IEnumerable<string> CreateDummyStrings()
        {
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();// "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            var strings = new List<string>();

            var rand = new Random();

            for (var i = 0; i < 1000000; i++)
            {
                var str = "";
                for (var t = 0; t < 5; t++)
                {
                    var index = rand.Next(0, letters.Length - 1);
                    str += letters[index];
                }
                strings.Add(str);
            }

            return strings;
        }

    }
}
