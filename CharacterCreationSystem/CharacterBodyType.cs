using System;

namespace CharacterCreationSystem
{
    public class CharacterBodyTypes
    {
        public string GetBodyType()
        {
            Console.WriteLine("=== Character Body Type ===");
            Console.WriteLine("\nChoose your character's body type:");
            Console.WriteLine("(a) Slim");
            Console.WriteLine("(b) Average");
            Console.WriteLine("(c) Athletic");
            Console.WriteLine("(d) Curvy");
            Console.WriteLine("(e) Bulk");
            Console.WriteLine("(f) Tall");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "a":
                    return "Slim";
                case "b":
                    return "Average";
                case "c":
                    return "Athletic";
                case "d":
                    return "Curvy";
                case "e":
                    return "Bulk";
                case "f":
                    return "Tall";
                default:
                    Console.WriteLine("Invalid choice.");
                    return GetBodyType();
            }
        }
    }
}
