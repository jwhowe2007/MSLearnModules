string[] pettingZoo = [
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
];

void RandomizePettingZoo() {
    Random rand = new();

    for (int i = 0; i < pettingZoo.Length; i++) {
        int randIndex = rand.Next(i, pettingZoo.Length);

        (pettingZoo[randIndex], pettingZoo[i]) = (pettingZoo[i], pettingZoo[randIndex]);
    }
}

void DisplayPettingZoo() {
    foreach (string animal in pettingZoo) {
        Console.WriteLine(animal);
    }
    Console.WriteLine();
}

string[,] AssignGroup(int groups = 6) {
    int groupSize = pettingZoo.Length / groups;
    string[,] assignedGroups = new string[groups, groupSize];

    int animal = 0;

    for (int i = 0; i < groups; i++) {
        for (int j = 0; j < groupSize; j++) {
            assignedGroups[i, j] = pettingZoo[animal++];
        }
    }

    return assignedGroups;
}

void PrintGroup(string[,] group) {
    int groupSize = group.GetLength(group.Rank - 1);

    for (int i = 0; i < group.Length / groupSize; i++) {
        Console.Write($"Group {i + 1}: [");

        for (int j = 0; j < groupSize; j++) {
            Console.Write($"{group[i,j]}");

            if (j < groupSize - 1) {
                Console.Write(", ");
            }
        }

        Console.WriteLine("]");
    }
    Console.WriteLine();
}

DisplayPettingZoo();

void PlanSchoolVisit(string schoolName, int groups = 6) {
    RandomizePettingZoo();
    DisplayPettingZoo();

    Console.WriteLine(schoolName);
    PrintGroup(AssignGroup(groups));
}

PlanSchoolVisit("School A");
PlanSchoolVisit("School B", 3);
PlanSchoolVisit("School C", 2);


