// #1 the ourAnimals array will store the following:
using System.Runtime.Versioning;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string animalSuggestedDonation = "";

// #2 variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// #3 array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// #4 create sample data ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            animalSuggestedDonation = "5.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            animalSuggestedDonation = "15.00";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Snowball III";
            animalSuggestedDonation = "25.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "3";
            animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
            animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
            animalNickname = "Lion";
            animalSuggestedDonation = "10.00";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            animalSuggestedDonation = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    // Try parsing the suggested donation into a decimal
    if (!decimal.TryParse(animalSuggestedDonation, out decimal suggestedDonation))
    {
        suggestedDonation = 45.00m;
    }
    ourAnimals[i, 6] = $"Suggested Donation: {suggestedDonation:C2}";
}

// #5 display the top-level menu options
do
{
    // NOTE: the Console.Clear method is throwing an exception in debug sessions
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // use switch-case to process the selected menu option
    switch (menuSelection)
    {
        case "1":
            // list all pet info
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    for (int j = 0; j < (int)(ourAnimals.Length / maxPets); j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
            // Display all dogs with a specified characteristic
            Console.Write("Please enter the search term to look up by characteristic keyword: ");
            string? searchTerm = Console.ReadLine();

            for (int animalIndex = 0; animalIndex < maxPets; animalIndex++) {
                string species = ourAnimals[animalIndex, 1];

                if (species.Equals("species: dog", StringComparison.CurrentCultureIgnoreCase)) {
                    string physicalDesc = ourAnimals[animalIndex, 4];
                    string personality = ourAnimals[animalIndex, 5];
                    string physicalDescData = physicalDesc.Split("Physical description: ")[1];
                    string personalityData = personality.Split("Personality: ")[1];

                    string searchTarget = physicalDescData + " " + personalityData;

                    if (searchTerm != null && searchTarget.Contains(searchTerm)) {
                        for (int j = 0; j < (int)ourAnimals.Length / maxPets; j++) {
                            Console.WriteLine(ourAnimals[animalIndex, j]);
                        }
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");
