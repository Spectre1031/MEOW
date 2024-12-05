using System;

using System;

namespace CharacterCreationSystem
{
    public class CharacterSkinTone
    {
        public string GetSkinTone()
        {
            Console.WriteLine("=== Character Skin Tone ===");
            Console.WriteLine("\nChoose your character's skin tone:");
            Console.WriteLine("(a) Warm");
            Console.WriteLine("(b) Cool");
            Console.WriteLine("(c) Neutral");
            Console.WriteLine("(d) Olive");
            Console.WriteLine("(e) Deep");

            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "a": return "Warm";
                case "b": return "Cool";
                case "c": return "Neutral";
                case "d": return "Olive";
                case "e": return "Deep";
                default:
                    Console.WriteLine("Invalid choice.");
                    return GetSkinTone();
            }
        }
    }
}
