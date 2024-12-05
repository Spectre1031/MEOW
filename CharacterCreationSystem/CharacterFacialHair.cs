using System;

namespace CharacterCreationSystem
{
    public class CharacterFacialHair
    {
        public string GetFacialHair()
        {
            Console.WriteLine("=== Character Facial Hair ===");
            Console.WriteLine("\nChoose your character's facial hair:");
            Console.WriteLine("(a) Stubble");
            Console.WriteLine("(b) Full Beard");
            Console.WriteLine("(c) Goatee");
            Console.WriteLine("(d) Mustache");
            Console.WriteLine("(e) Clean-Shaven");
            Console.WriteLine("(f) None");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "a":
                    return "Stubble";
                case "b":
                    return "Full Beard";
                case "c":
                    return "Goatee";
                case "d":
                    return "Mustache";
                case "e":
                    return "Clean-Shaven";
                case "f":
                    return "None";
                default:
                    Console.WriteLine("Invalid choice");
                    return GetFacialHair();
            }
        }
    }
}
