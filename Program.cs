using System;
using System.Runtime.InteropServices;

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
        private Character[] availableCharacters = new Character[]
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

        private Plant[] availablePlants = new Plant[]
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

        public Fairytale()
        { }

        private static void DrawMenu(BaseObject[] items, int row, int col, int index)
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


        private BaseObject[] ChoosePoints(string title, Character[] menuItems)
        {
            Console.WriteLine(title);
            Console.WriteLine();

            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            int i = 0;
            Character[] selectedCharacters = new Character[6];
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
                if (i == 6)
                {
                    return selectedCharacters;
                }
            }
        }
        private BaseObject ChoosePoints(string title, Plant[] menuItems)
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
            plant = (Plant)ChoosePoints("Choose plant:", availablePlants);
            Console.Clear();
            Console.WriteLine("You have chosen {0}.", plant);
            characters = (Character[])ChoosePoints("Choose characters. Chose 6 characters", availableCharacters);
            Console.Clear();
            WriteFairytaleToConsole();

            Console.ReadLine();
        }

        private void WriteFairytaleToConsole()
        {
            int currentCharacter = 0;
            Console.WriteLine("{0} planted a {1} and the {1} grew big, very big.", characters[currentCharacter], plant);
            Console.WriteLine("The {0} began to pull the {1} out of the ground: he pulled and pulled, but could not pull it out.", characters[currentCharacter], plant);
            for (int i = 0; i < characters.Length - 1; i++)
            {
                Console.WriteLine("The {0} called the {1} for help.", characters[i], characters[i + 1]);
                Console.WriteLine(writeChainOfCharacters(i));
            }
        }

        private string writeChainOfCharacters(int i)
        {
            string result = "";
            for (int j = i + 1; j > 0; j--)
            {
                result += "" + characters[j] + " for " + characters[j - 1] + ", ";
            }
            result += characters[0] + " for " + plant;
            if (i < 4)
            {
                result += ": they pull and pull, but they can’t pull it out.";

            }
            else
            {
                result += ": they pull and pull - they pulled out " + plant + "!";
            }
            return result;
        }

        class BaseObject
        {
            public string Name { get; set; }
            public BaseObject(string name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        class Character : BaseObject
        {
            public Character(string name) : base(name)
            { }
        }

        class Human : Character
        {
            public Human(string name) : base(name)
            { }
        }

        class Animal : Character
        {
            public Animal(string name) : base(name)
            { }
        }

        class Plant : BaseObject
        {
            public Plant(string name) : base(name)
            { }
        }

        class Vegetable : Plant
        {
            public Vegetable(string name) : base(name)
            {
            }
        }

        class Fruit : Plant
        {
            public Fruit(string name) : base(name)
            {
            }
        }
    }
}