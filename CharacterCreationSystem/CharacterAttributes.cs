using CharacterCustomization;
using System;

namespace CharacterCreationSystem
{
    public class CharacterAttributes
    {
        public interface IShowOptions
        {
            void ShowPositiveEffect();
            void ShowNegativeEffect();
            void ShowTools();
            void ShowAccessories();
            void ShowClothes();
        }
    
        public class Attribute
        {
            public string PositiveEffect { get; set; }
            public string NegativeEffect { get; set; }
            public string Tools { get; set; }
            public string Accessories { get; set; }
            public string Clothes { get; set; }

            public int Strength { get; set; }
            public int Luck { get; set; }
            public int Speed { get; set; }
            public int Endurance { get; set; }
            public int Dexterity { get; set; }
            public int Intelligence { get; set; }

            public Attribute(string positiveEffect, string negativeEffect, string tools, string accessories, string clothes, int strength, int luck, int speed, int endurance, int dexterity, int intelligence)
            {
                this.PositiveEffect = positiveEffect;
                this.NegativeEffect = negativeEffect;
                this.Tools = tools;
                this.Accessories = accessories;
                this.Clothes = clothes;

                this.Strength = strength;
                this.Luck = luck;
                this.Speed = speed;
                this.Endurance = endurance;
                this.Dexterity = dexterity;
                this.Intelligence = intelligence;
            }
        }

        public class CustomAttributes : CheckForErrors, IShowOptions
        {
            private Attribute attribute;

            public CustomAttributes()
            {
                attribute = new Attribute("", "", "", "", "", 1, 1, 1, 1, 1, 1);

                bool isRunning = true;
                Console.WriteLine("\n=== Character Attributes ===");
                while (isRunning) 
                {
                    try 
                    {
                        AllocateCharacterStats();

                        if (string.IsNullOrEmpty(attribute.PositiveEffect)) 
                        {
                            Console.WriteLine("\n=== Character Postive Effect ===");
                            Console.WriteLine("Choose a Positive Effect: ");
                            ShowPositiveEffect();
                            Console.Write("Input: ");
                            string input = Console.ReadLine();
                            attribute.PositiveEffect = CheckInput(input, new[] { 
                                "Energy Boost - Increases stamina by 20%", 
                                "Speed Increase - Performs tasks 20% faster" ,
                                "Enhanced Harvest - Increases yield by 20% ", 
                                "Luck Boost - Raises chance of rare events", 
                                "Pest Resistance - Reduces crop failure by 25%",
                                "Soil Fertility Boost - Speeds up crop growth by 20%",  
                                "Animal Productivity - Animals produce 20% more goods"});
                        }

                        if (string.IsNullOrEmpty(attribute.NegativeEffect))
                        {
                            Console.WriteLine("\n=== Character Negative Effect ===");
                            Console.WriteLine("Choose a Negative Effect: ");
                            ShowNegativeEffect();
                            Console.Write("Input: ");
                            string input = Console.ReadLine();
                            attribute.NegativeEffect = CheckInput(input, new[] { 
                                "Fatigue - Reduces stamina recovery", 
                                "Sickness - Affects daily tasks" ,
                                "Crop Damage - Lowers crop yield", 
                                "Animal Stress - Lowers animal productivity", 
                                "Soil Degradation - Reduces soil fertility",
                                "Stress Build-Up - Affects character's overall performance"});
                        }

                        if (string.IsNullOrEmpty(attribute.Tools))
                        {
                            Console.WriteLine("\n=== Character Tools ===");
                            Console.WriteLine("Choose a Tools: ");
                            ShowTools();
                            Console.Write("Input: ");
                            string input = Console.ReadLine();
                            attribute.Tools = CheckInput(input, new[] { 
                                "Basic Tools: Hoe, Shovel, Watering Can, Rake, Spade", 
                                "Advanced Tools: Scythe, Axe, Pickaxe, Sickle, Power Tiller" ,
                                "Specialized Tools: Fertilizer Spreader, Bug Net, Pruning Shears, Sprinkler System, Soil Tester", 
                                "Seasonal Tools: Snow Shovel, Winter Coat, Shade Net, Ice Pick, Storm Shelter Equipment"});
                        }

                        if (string.IsNullOrEmpty(attribute.Accessories))
                        {
                            Console.WriteLine("\n=== Character Accessories ===");
                            Console.WriteLine("Choose a Accessories: ");
                            ShowAccessories();
                            Console.Write("Input: ");
                            string input = Console.ReadLine();
                            attribute.Accessories = CheckInput(input, new[] { 
                                "Storage Expansion Backpack", 
                                "Lucky Hoe" , 
                                "Harvest Gloves",
                                "Crop Analyzer", 
                                "Mechanical Shovel"});
                        }

                        if (string.IsNullOrEmpty(attribute.Clothes))
                        {
                            Console.WriteLine("\n=== Character Clothes ===");
                            Console.WriteLine("Choose a Clothes: ");
                            ShowClothes();
                            Console.Write("Input: ");
                            string input = Console.ReadLine();
                            attribute.Clothes = CheckInput(input, new[] {
                                "Classic Overalls",
                                "Flannel Shirt and Jeans" ,
                                "Wide-Brimmed hat and Boots",
                                "Straw Hat and Apron",
                                "Farmer's Vest"});
                        }
                        break;
                    }
                    catch (OnlyOneCharacter ex) { Console.WriteLine("Error: " + ex.Message); }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }

            public int Strength => attribute.Strength;
            public int Luck => attribute.Luck;
            public int Speed => attribute.Speed;
            public int Endurance => attribute.Endurance;
            public int Dexterity => attribute.Dexterity;
            public int Intelligence => attribute.Intelligence;
            public string PositiveEffect => attribute.PositiveEffect;
            public string NegativeEffect => attribute.NegativeEffect;
            public string Tools => attribute.Tools;
            public string Accessories => attribute.Accessories;
            public string Clothes => attribute.Clothes;

            public void AllocateCharacterStats()
            {
                int pointsRemaining = 7;

                Console.WriteLine("\n=== Character Stats ===");

                attribute.Strength = AllocatePoints("Strength", pointsRemaining);
                pointsRemaining -= attribute.Strength;

                attribute.Luck = AllocatePoints("Luck", pointsRemaining);
                pointsRemaining -= attribute.Luck;

                attribute.Speed = AllocatePoints("Speed", pointsRemaining);
                pointsRemaining -= attribute.Speed;

                attribute.Endurance = AllocatePoints("Endurance", pointsRemaining);
                pointsRemaining -= attribute.Endurance;

                attribute.Dexterity = AllocatePoints("Dexterity", pointsRemaining);
                pointsRemaining -= attribute.Dexterity;

                attribute.Intelligence = AllocatePoints("Intelligence", pointsRemaining);
                pointsRemaining -= attribute.Intelligence;
            }

            private int AllocatePoints(string attributeName, int pointsRemaining)
            {
                while (true)
                {
                    Console.WriteLine($"You have {pointsRemaining} points remaining.");
                    Console.Write($"How many points do you want to allocate to {attributeName} (Max 3): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int allocatedPoints) && allocatedPoints <= 3 && allocatedPoints <= pointsRemaining && allocatedPoints >= 0)
                    {
                        return allocatedPoints;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid number of points.");
                }
            }

            public void ShowPositiveEffect()
            {
                Console.WriteLine("(a) Energy Boost - Increases stamina by 20%");
                Console.WriteLine("(b) Speed Increase - Performs tasks 20% faster");
                Console.WriteLine("(c) Enhanced Harvest - Increases yield by 20%");
                Console.WriteLine("(d) Luck Boost - Raises chance of rare events");
                Console.WriteLine("(e) Pest Resistance - Reduces crop failure by 25%");
                Console.WriteLine("(f) Soil Fertility Boost - Speeds up crop growth by 20%");
                Console.WriteLine("(g) Animal Productivity - Animals produce 20% more goods");
            }

            public void ShowNegativeEffect()
            {
                Console.WriteLine("(a) Fatigue - Reduces stamina recovery");
                Console.WriteLine("(b) Sickness - Affects daily tasks");
                Console.WriteLine("(c) Crop Damage - Lowers crop yield");
                Console.WriteLine("(d) Animal Stress - Lowers animal productivity");
                Console.WriteLine("(e) Soil Degradation - Reduces soil fertility");
                Console.WriteLine("(f) Stress Build-Up - Affects character's overall performance");
            }

            public void ShowTools()
            {
                Console.WriteLine("(a) Basic Tools: Hoe, Shovel, Watering Can, Rake, Spade");
                Console.WriteLine("(b) Advanced Tools: Scythe, Axe, Pickaxe, Sickle, Power Tiller");
                Console.WriteLine("(c) Specialized Tools: Fertilizer Spreader, Bug Net, Pruning Shears, Sprinkler System, Soil Tester");
                Console.WriteLine("(d) Seasonal Tools: Snow Shovel, Winter Coat, Shade Net, Ice Pick, Storm Shelter Equipment");
            }

            public void ShowAccessories()
            {
                Console.WriteLine("(a) Storage Expansion Backpack");
                Console.WriteLine("(b) Lucky Hoe");
                Console.WriteLine("(c) Harvest Gloves");
                Console.WriteLine("(d) Crop Analyzer");
                Console.WriteLine("(e) Mechanical Shovel");
            }

            public void ShowClothes()
            {
                Console.WriteLine("(a) Classic Overalls");
                Console.WriteLine("(b) Flannel Shirt and Jeans");
                Console.WriteLine("(c) Wide-Brimmed Hat and Boots");
                Console.WriteLine("(d) Straw Hat and Apron");
                Console.WriteLine("(e) Farmer's Vest");
            }
        }

        public class CheckForErrors
        {
            public static string CheckInput(string input, string[] options)
            {
                if (input.Length == 1)
                {
                    return ChooseOption(input.ToLower()[0], options);
                }
                throw new OnlyOneCharacter("Input must be a single character.");
            }

            public static string ChooseOption(char letter, string[] options)
            {
                if (letter >= 'a' && letter < 'a' + options.Length)
                {
                    return options[letter - 'a'];
                }
                throw new IndexOutOfRangeException("Invalid option selected.");
            }
        }

        public class OnlyOneCharacter : Exception
        {
            public OnlyOneCharacter(string message) : base(message) { }
        }
    }
}
