using System;

namespace CharacterCreationSystem
{
    public class CharacterInfo
    {
        public interface IShowOptions
        {
            void ShowNameOptions();
            void ShowAgeOptions();
            void ShowGenderOptions();
            void ShowRaceOptions();
            void ShowFarmerTypeOptions();
        }

        public class Information
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string Race { get; set; }
            public string FarmerType { get; set; }

            public Information(string name, string age, string gender, string race, string farmerType)
            {
                Name = name;
                Age = age;
                Gender = gender;
                Race = race;
                FarmerType = farmerType;
            }
        }

        public class CustomCharacterInfo : IShowOptions
        {
            private Information information;

            public CustomCharacterInfo()
            {
                information = new Information("", "", "", "", "");
            }

            public void CharacterCreation()
            {
                bool isRunning = true;
                Console.WriteLine("\n === Character Creation ===");

                while (isRunning)
                {
                    try
                    {
                        while (string.IsNullOrEmpty(information.Name)) 
                        { 
                            Console.WriteLine("\n=== Character Name ==="); 
                            ShowNameOptions(); string name = Console.ReadLine(); 
                            if (!string.IsNullOrWhiteSpace(name) && name.Length >= 3 && name.Length <= 16) 
                            { 
                                information.Name = name; 
                            } 
                            else 
                            { 
                                Console.WriteLine("Invalid input. Name must be 3-16 characters long."); 
                            } 
                        }

                        while (string.IsNullOrEmpty(information.Age))
                        {
                            Console.WriteLine("\n=== Character Age ===");
                            ShowAgeOptions();
                            string input = Console.ReadLine();
                            information.Age = CheckForErrors.CheckInput(input, new[] {
                                "Young Adult (18-24)",
                                "Adult (25-31)",
                                "Middle-Aged (32-38)",
                                "Mature Adult (39-45)",
                                "Experienced (46-52)" });
                        }

                        while (string.IsNullOrEmpty(information.Gender))
                        {
                            Console.WriteLine("\n=== Character Gender ===");
                            ShowGenderOptions();
                            string input = Console.ReadLine();
                            information.Gender = CheckForErrors.CheckInput(input, new[] {
                                "Male", "Female", "Non-Binary", "Other" });
                        }

                        while (string.IsNullOrEmpty(information.Race))
                        {
                            Console.WriteLine("\n=== Character Race ===");
                            ShowRaceOptions();
                            string input = Console.ReadLine();
                            information.Race = CheckForErrors.CheckInput(input, new[] {
                                "Western European", "Asian", "Native American", "Australian", "Middle Eastern" });
                        }

                        while (string.IsNullOrEmpty(information.FarmerType))
                        {
                            Console.WriteLine("\n=== Character Farmer Type ===");
                            ShowFarmerTypeOptions();
                            string input = Console.ReadLine();
                            information.FarmerType = CheckForErrors.CheckInput(input, new[] {
                                "Crop Farmer", "Livestock Farmer", "Mixed Farmer", "Organic Farmer", "Aquaculture Farmer" });
                        }

                        while (!string.IsNullOrEmpty(information.Name) &&
                            !string.IsNullOrEmpty(information.Age) &&
                            !string.IsNullOrEmpty(information.Gender) && 
                            !string.IsNullOrEmpty(information.Race) && 
                            !string.IsNullOrEmpty(information.FarmerType))
                        {
                            isRunning = false;
                        }
                    }
                    catch (OnlyOneCharacter ex) { Console.WriteLine("Error: " + ex.Message); }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }

            public string GetName() => information.Name;
            public string GetAge() => information.Age;
            public string GetGender() => information.Gender;
            public string GetRace() => information.Race;
            public string GetFarmerType() => information.FarmerType;

            public void ShowNameOptions()
            {
                Console.WriteLine("Name must be between 3 and 16 characters.");
            }

            public void ShowAgeOptions()
            {
                Console.WriteLine("(a) Young Adult (18-24)");
                Console.WriteLine("(b) Adult (25-31)");
                Console.WriteLine("(c) Middle-Aged (32-38)");
                Console.WriteLine("(d) Mature Adult (39-45)");
                Console.WriteLine("(e) Experienced (46-52)");
            }

            public void ShowGenderOptions()
            {
                Console.WriteLine("(a) Male");
                Console.WriteLine("(b) Female");
                Console.WriteLine("(c) Non-Binary");
                Console.WriteLine("(d) Other");
            }

            public void ShowRaceOptions()
            {
                Console.WriteLine("(a) Western European");
                Console.WriteLine("(b) Asian");
                Console.WriteLine("(c) Native American");
                Console.WriteLine("(d) Australian");
                Console.WriteLine("(e) Middle Eastern");
            }

            public void ShowFarmerTypeOptions()
            {
                Console.WriteLine("(a) Crop Farmer");
                Console.WriteLine("(b) Livestock Farmer");
                Console.WriteLine("(c) Mixed Farmer");
                Console.WriteLine("(d) Organic Farmer");
                Console.WriteLine("(e) Aquaculture Farmer");
            }

            public class CheckForErrors
            {
                public static string CheckInput(string input, string[] choose)
                {
                    if (input.Length == 1)
                    {
                        return ChosenOps(Char.Parse(input.ToLower()), choose);
                    }
                    else { throw new OnlyOneCharacter("Must be one character only"); }
                }

                public static string ChosenOps(char letter, string[] choose)
                {
                    switch (letter)
                    {
                        case 'a': return choose[0];
                        case 'b': return choose[1];
                        case 'c': return choose[2];
                        case 'd': return choose[3];
                        case 'e': return choose[4];
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }

            public class OnlyOneCharacter : Exception
            {
                public OnlyOneCharacter(string message) : base(message) { }
            }
        }
    }
}
