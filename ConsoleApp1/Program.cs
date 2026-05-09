using System;
using System.Collections.Generic;
using ThePlanets;

// This internal class serves as the main entry point for the application
internal class Program
{
    static void Main(string[] args)
    {
        // LOGIC: This initiates the console UI environment with a specific background color and clears any existing text
        // WHY: Setting a black background and clearing the screen ensures 
        // that the colorful planet data is easily readable and fits the theme of space they way I intend it to making the expereince visually pleasing for the user
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        // Instantiates the PlanetData class to load the planetary collection into memory
        PlanetData planetData = new PlanetData();
        List<Planet> planets = planetData.LoadPlanets();

        // Launch the interactive menu loop
        ShowMenu(planets);
    }

    // Displays the main user interface and handles choice navigation
    static void ShowMenu(List<Planet> planets)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();

            // Draw my headers with the stars using colours I want to fit to fit the theme of space and make it visually pleasing for the user
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" THE PLANETS - SOLAR SYSTEM ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*****************************");
            Console.ResetColor();

            // LOGIC: Display menu options using a helper method
            // WHY: Follows the DRY (Don't Repeat Yourself) principle, which centralises the formatting and allows for easy updates to the menu style in one place.
            // This also keeps the main menu code cleaner and more focused on logic rather than presentation details keeping it in the same space
            
            WriteMenuOption("1", "Show all planets");
            WriteMenuOption("2", "Search for a planet by name");
            WriteMenuOption("3", "How many moons does a planet have?");
            WriteMenuOption("4", "Is a planet in our solar system?");
            WriteMenuOption("Q", "Quit");

            Console.Write("\n Enter your choice: ");
            string input = Console.ReadLine();

            // LOGIC: Use .ToUpper() on input for case insensitivity
            // WHY: Enhances usability by allowing users to enter 'q' or 'Q' interchangeably
            switch (input?.ToUpper())
            {
                case "1": ShowAllPlanets(planets); break;
                case "2": SearchByName(planets); break;
                case "3": ShowMoonCount(planets); break;
                case "4": CheckIfPlanetExists(planets); break;
                case "Q": running = false; break;
                default:
                    // LOGIC: Default case for unexpected input
                    // WHY: Part of user input validation to prevent crashes
                    ShowError("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    // Formats menu options with yellow brackets and white text, yellow to keep with the space theme (stars)
    static void WriteMenuOption(string key, string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" [{key}]");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" {text}");
        Console.ResetColor();
    }

    // Displays the full list of planets in a side by side layout, easier to read and fits more data on one screen,
    // also looks better with the colours I have chosen
    static void ShowAllPlanets(List<Planet> planets)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  SOLAR SYSTEM EXPLORER \n");

        // LOGIC: Increment the loop by 2 (i += 2).
        // WHY: Allows us to process planets in pairs to build two columns on one screen to give a more
        // comprehensive and easier view of the data and make it easier to compare planets side by side, also looks better with the colours I have chosen
        for (int i = 0; i < planets.Count; i += 2)
        {
            Planet left = planets[i];
            Planet right = (i + 1 < planets.Count) ? planets[i + 1] : null;

            // LOGIC: .PadRight(40)
            // WHY: Aligns the left column text to exactly 40 characters so the 
            // right column starts at the same spot every time, regardless of name length
            Console.ForegroundColor = left.NameColor;
            Console.Write($" {left.Name.ToUpper()}".PadRight(40));
            if (right != null)
            {
                Console.ForegroundColor = right.NameColor;
                Console.Write($" {right.Name.ToUpper()}");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"  Dist: {left.DistanceFromSun}m km".PadRight(40));
            if (right != null) Console.Write($"  Dist: {right.DistanceFromSun}m km");
            Console.WriteLine();

            Console.Write($"  Moons: {left.GetMoonCount()}".PadRight(40));
            if (right != null) Console.Write($"  Moons: {right.GetMoonCount()}");
            Console.WriteLine("\n");
        }
        Pause();
    }

    // Searches the list for a specific planet and shows all data points
    static void SearchByName(List<Planet> planets)
    {
        Console.Clear();
        Console.Write(" Enter planet name: ");
        string input = Console.ReadLine();

        // LOGIC: .Find() with StringComparison.OrdinalIgnoreCase
        // WHY: Ensures the search is user friendly by finding "Mars" even if typed as "mars"
        Planet p = planets.Find(x => x.Name.Equals(input?.Trim(), StringComparison.OrdinalIgnoreCase));

        if (p != null)
        {
            Console.ForegroundColor = p.NameColor;
            Console.WriteLine($"\n *** {p.Name.ToUpper()} ***");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" Mass: {p.Mass} x 10^24 kg");
            Console.WriteLine($" Distance: {p.DistanceFromSun}m km");
            Console.WriteLine($" Moons: {p.GetMoonCount()}");
        }
        else { ShowError("Not found."); }
        Pause();
    }

    // Specifically shows how many moons a planet has and their names
    static void ShowMoonCount(List<Planet> planets)
    {
        Console.Clear();
        Console.Write(" Enter planet name: ");
        string input = Console.ReadLine();
        Planet p = planets.Find(x => x.Name.Equals(input?.Trim(), StringComparison.OrdinalIgnoreCase));

        if (p != null)
        {
            Console.ForegroundColor = p.NameColor;
            Console.Write($"\n {p.Name}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" has {p.GetMoonCount()} moon(s).");

            // LOGIC: Conditional check on moon count
            // WHY: Only prints names if moons actually exist, keeping the UI nice,
            // clean and neat, also looks better with the colours I have chosen
            if (p.Moons.Count > 0)
            {
                Console.ForegroundColor = p.NameColor;
                Console.WriteLine($"\n Names: {string.Join(", ", p.Moons)}");
            }
            else { Console.WriteLine(); }
        }
        else { ShowError("Not found."); }
        Pause();
    }

    // Checks if a name exists in the planetary list
    static void CheckIfPlanetExists(List<Planet> planets)
    {
        Console.Clear();
        Console.Write(" Check name: ");
        string input = Console.ReadLine();

        // LOGIC: .Exists() method.
        // WHY: Provides a fast, built in way to return a boolean result for search queries
        bool exists = planets.Exists(x => x.Name.Equals(input?.Trim(), StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(exists ? "\n Yes, it is in our system." : "\n No, not found.");
        Pause();
    }

    // Displays error messages in Red for clear visibility
    static void ShowError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n {msg}");
        Console.ResetColor();
    }

    // Pauses the execution so the user can read the output before returning to the menu
    static void Pause()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n Press ENTER to return...");
        Console.ReadLine();
    }
}