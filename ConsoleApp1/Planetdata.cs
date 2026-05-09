using System;
using System.Collections.Generic;

namespace ThePlanets
{
    // LOGIC: Separating data generation from logic
    // WHY: Keeps the Program class focused on user interaction while this class 
    // handles all the raw data, storage and population
    public class PlanetData
    {
        // Populates and returns a list of Planet objects with matching data
        public List<Planet> LoadPlanets()
        {
            // LOGIC: Initiates the list
            // WHY: Using a List<Planet> is better than an Array because 
            // Lists are flexible and allow me to use helpful search tools like .Find().
            return new List<Planet>
            {
                new Planet("Mercury", 0.33, 57.9, new List<string>(), ConsoleColor.Gray),
                new Planet("Venus", 4.87, 108.2, new List<string>(), ConsoleColor.Yellow),
                new Planet("Earth", 5.97, 149.6, new List<string> { "Moon" }, ConsoleColor.Cyan),
                new Planet("Mars", 0.64, 227.9, new List<string> { "Phobos", "Deimos" }, ConsoleColor.Red),
                new Planet("Ceres", 0.0009, 413, new List<string>(), ConsoleColor.Magenta),
                new Planet("Jupiter", 1898, 778.6, new List<string> { "Io", "Europa", "Ganymede" }, ConsoleColor.DarkYellow),
                new Planet("Saturn", 568, 1433, new List<string> { "Titan", "Rhea" }, ConsoleColor.Yellow),
                new Planet("Uranus", 86.8, 2872, new List<string> { "Ariel", "Umbriel" }, ConsoleColor.Cyan),
                new Planet("Neptune", 102, 4495, new List<string> { "Triton" }, ConsoleColor.Blue),
                new Planet("Pluto", 0.013, 5906, new List<string> { "Charon", "Nix", "Styx" }, ConsoleColor.DarkGray)
            };
        }
    }
}