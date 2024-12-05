using System;
using CharacterCustomization;
using static CharacterCreationSystem.CharacterInfo;

namespace CharacterCreationSystem
{
    public class NewGame
    {
        public void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("=== NEW GAME: Create Your Character ===");

            CustomCharacterInfo characterInfo = new CustomCharacterInfo();
            CharacterAttributes.CustomAttributes customAttributes = new CharacterAttributes.CustomAttributes();
            CustomAppearance customAppearance = new CustomAppearance();

            characterInfo.CharacterCreation();
            customAttributes.AllocateCharacterStats();          

            string name = characterInfo.GetName();
            string age = characterInfo.GetAge();
            string gender = characterInfo.GetGender();
            string race = characterInfo.GetRace();
            string farmerType = characterInfo.GetFarmerType();
            string positiveEffect = customAttributes.PositiveEffect;
            string negativeEffect = customAttributes.NegativeEffect;
            string tools = customAttributes.Tools;
            string accessories = customAttributes.Accessories;
            string clothes = customAttributes.Clothes;

            customAppearance.CustomizeAppearance();

            string facialHair = new CharacterFacialHair().GetFacialHair();
            string bodyType = new CharacterBodyTypes().GetBodyType();
            string skinTone = new CharacterSkinTone().GetSkinTone();
            string emotionalStateResult = new CharacterEmotionalState().GetEmotionalState();
            string title = new CharacterTitle().GetTitle();

            Console.WriteLine("\n=== Character Summary ===");
            Console.WriteLine($"{"Name:",-20} {name}");
            Console.WriteLine($"{"Age:",-20} {age}");
            Console.WriteLine($"{"Gender:",-20} {gender}");
            Console.WriteLine($"{"Race:",-20} {race}");
            Console.WriteLine($"{"Farmer Type:",-20} {farmerType}");
            Console.WriteLine($"{"Strength:",-20} {customAttributes.Strength}");
            Console.WriteLine($"{"Luck:",-20} {customAttributes.Luck}");
            Console.WriteLine($"{"Speed:",-20} {customAttributes.Speed}");
            Console.WriteLine($"{"Endurance:",-20} {customAttributes.Endurance}");
            Console.WriteLine($"{"Dexterity:",-20} {customAttributes.Dexterity}");
            Console.WriteLine($"{"Intelligence:",-20} {customAttributes.Intelligence}");
            Console.WriteLine($"{"Positive Effect:",-20} {positiveEffect}");
            Console.WriteLine($"{"Negative Effect:",-20} {negativeEffect}");
            Console.WriteLine($"{"Tools:",-20} {tools}");
            Console.WriteLine($"{"Emotional State:",-20} {emotionalStateResult}");
            Console.WriteLine($"{"Character Title:",-20} {title}");

            Console.WriteLine("\n=== Appearance Details ===");
            customAppearance.showDetailAppearance();
            Console.WriteLine($"{"Facial Hair:",-20} {facialHair}");
            Console.WriteLine($"{"Body Type:",-20} {bodyType}");
            Console.WriteLine($"{"Skin Tone:",-20} {skinTone}");
            Console.WriteLine($"{"Accessories:",-20} {accessories}");
            Console.WriteLine($"{"Clothes:",-20} {clothes}");

            Console.WriteLine("\nCharacter creation complete! Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
