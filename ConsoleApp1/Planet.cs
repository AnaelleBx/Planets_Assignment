using System;
using System.Collections.Generic;

namespace ThePlanets
{
    // LOGIC: Creating a dedicated Planet class
    // WHY: contains and brings together all required data such as Name, Mass, Distance, Moons into a 
    // single object for easier management much cleaner organisation and better code readability. This also allows me to easily create a collection of Planet objects and
    // perform operations on them without needing to manage multiple separate lists for each attribute.
    public class Planet
    {
        // Properties defined with appropriate data types
        public string Name { get; set; }           // Planet name
        public double Mass { get; set; }           // Mass in 10^24 kg. Double allows for decimal accuracy
        public double DistanceFromSun { get; set; } // Distance in million km
        public List<string> Moons { get; set; }    // List holds variable amount of moon names
        public ConsoleColor NameColor { get; set; } // Stores visual styling data for the console

        // Constructor: Ensures a planet cannot be created without it having its  essential data
        public Planet(string name, double mass, double distanceFromSun, List<string> moons, ConsoleColor nameColor)
        {
            Name = name;
            Mass = mass;
            DistanceFromSun = distanceFromSun;
            Moons = moons;
            NameColor = nameColor;
        }

        // LOGIC: Expression bodied method (=>).
        // WHY: A concise and efficeint way to return the count of the moons list for querying purposes
        public int GetMoonCount() => Moons.Count;
    }
}
