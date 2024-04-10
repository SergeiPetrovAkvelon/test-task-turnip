using System;
using System.Runtime.InteropServices;
using Turnip.Classes;

namespace Turnip
{
    class Program
    {

        static void Main(string[] args)
        {
            Fairytale fairytale = new Fairytale();
            fairytale.Tell();
        }
    }

    class Fairytale
    {
        private Character[] availableCharacters =
        {
            new Human("Grandfather"),
            new Human("Grandmother"),
            new Human("Granddaughter"),
            new Animal("Wolf"),
            new Animal("Fox"),
            new Animal("Bear"),
            new Animal("Rabbit"),
            new Animal("Hare"),
            new Human("Hunter"),
            new Human("Grandson")
        };

        private Plant[] availablePlants =
        {
            new Vegetable("Carrot"),
            new Vegetable("Potato"),
            new Vegetable("Cabbage"),
            new Vegetable("Onion"),
            new Vegetable("Garlic"),
            new Fruit("Apple"),
            new Fruit("Pear"),
            new Fruit("Cherry"),
            new Fruit("Strawberry"),
            new Fruit("Raspberry"),
            new Vegetable("Turnip")
        };

        private Character[] characters = new Character[6];
        private Plant? plant;
        private Human mainCharacter;
        private int activeCharacters=0;

        public Fairytale()
        { }

        private static void DrawMenu<T>(T[] items, int row, int col, int index)
        {
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(items[i].ToString());
                Console.ResetColor();
            }
            Console.WriteLine();
        }


        private T[] ChoosePoints<T>(string title, T[] menuItems)
        {
            Console.WriteLine(title);
            Console.WriteLine();

            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            int i = 0;
            T[] selectedCharacters = new T[5];
            while (true)
            {
                DrawMenu(menuItems, row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine($"Selected point {menuItems[index]}");
                        selectedCharacters[i] = menuItems[index];
                        index++;
                        i++;
                        break;

                }
                if (i == 5)
                {
                    return selectedCharacters;
                }
            }
        }
        private T ChoosePoint<T>(string title, T[] menuItems)
        {
            Console.WriteLine(title);
            Console.WriteLine();

            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            while (true)
            {
                DrawMenu(menuItems, row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine($"Selected point {menuItems[index]}");
                        return menuItems[index];

                }
            }
        }

        public void Tell()
        {
            plant = ChoosePoint<Plant>("Choose plant:", availablePlants);
            Console.Clear();
            mainCharacter = (Human)ChoosePoint<Character>("Choose main character:", Array.FindAll(availableCharacters, c => c.canPlanting));
            Console.Clear();

            Console.WriteLine("You have chosen {0}", mainCharacter);
            Console.WriteLine("You have chosen {0}.", plant);
            characters = ChoosePoints<Character>("Choose characters. Chose 5 characters", Array.FindAll(availableCharacters, c=> c.Name!=mainCharacter.Name));
            Console.Clear();
            WriteFairytaleToConsole();

            Console.ReadLine();
        }

        private void WriteFairytaleToConsole()
        {
            activeCharacters++;
            mainCharacter.ToPlant(plant);
            plant.ToGrow();
            string chainOfCharacters = mainCharacter.ToGrab(plant)+".";
            mainCharacter.ToPull(plant);
            CheckForSuccesfullPull();
            activeCharacters++;
            mainCharacter.ToCall(characters[0]);
            chainOfCharacters = characters[0].ToGrab(mainCharacter) + ", " + chainOfCharacters ;
            WriteChainOfCharacters(chainOfCharacters);
            ToPullAllCharacters();
            CheckForSuccesfullPull();
            for (int i = 0; i < characters.Length - 1; i++)
            {
                activeCharacters++;
                characters[i].ToCall(characters[i + 1]);
                chainOfCharacters= characters[i+1].ToGrab(characters[i]) + ", " + chainOfCharacters;
                WriteChainOfCharacters(chainOfCharacters);
                ToPullAllCharacters();
                CheckForSuccesfullPull();
            }
        }

        private void ToPullAllCharacters() {
            Console.Write("They pull and pull, ");
        }

        private void CheckForSuccesfullPull() {
            if (activeCharacters < 6)
            {
                Console.WriteLine("but could not pull it out.");
            }
            else {
                Console.WriteLine("they pulled out {0}!", plant);
            }
        }

        private void WriteChainOfCharacters(string chain)
        {
            Console.WriteLine(chain);
        }
    }
}