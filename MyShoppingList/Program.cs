using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MyShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Users\...\samples";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            string userDirectory = @$"\\{newDirectory}";
            Console.WriteLine("Enter file name:");
            string userFileName = Console.ReadLine();
            string userFile = @$"\\{userFileName}.txt";

            if (Directory.Exists($"{rootDirectory}\\{userDirectory}") && File.Exists($"{rootDirectory}\\{userDirectory}\\{userFile}"))
            {
                Console.WriteLine($"Directory and File exist. Add item to the wish list in the existing file.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{userDirectory}");
                File.Create($"{rootDirectory}\\{userDirectory}\\{userFile}").Close();
            }
            
            string fileLocation = @$"C:\Users\...\samples\\{userDirectory}";

            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{userFile}");
            List<string> myWishList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add a wish? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your wish:");
                    string userWish = Console.ReadLine();
                    myWishList.Add(userWish);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Take care!");
                }
            }

            Console.Clear();

            foreach (string wish in myWishList)
            {
                Console.WriteLine($"Your wish: {wish}");
            }

            File.WriteAllLines($"{fileLocation}{userFile}", myWishList);

        }
    }
}
