// Standard RPG dice types (thanks D&D!)
Random d4 = new();
Random d6 = new();
Random d8 = new();
Random d10 = new();
Random d12 = new();
Random d20 = new();

int heroHP = 10;
int mobHP = 10;

bool heroesTurn = true;
bool mobsTurn = false;

bool heroDead = false;
bool mobDead = false;

while (!heroDead && !mobDead) {
    int heroAttack, mobAttack;
    int mobArmorClass = 1;
    int heroArmorClass = 1;

    int mobDefense = mobArmorClass;
    int heroDefense = heroArmorClass;

    if (heroesTurn) {
        // Hero gets to attack
        // Attack die is 1d10
        heroAttack = d10.Next(1,11);

        // Mob rolls for defense (1d4)
        mobDefense += d4.Next(1,5);

        // Mob's HP are only subtracted if the hero's attack is greater than the mob's defense, and any remaining attack points go against the mob's health.
        if (heroAttack > mobDefense) {
            mobHP -= heroAttack - mobDefense;
            Console.WriteLine($"Hero hits MOB for {heroAttack - mobDefense}!");
        } else {
            Console.WriteLine("Hero misses MOB by a hair's breadth!");
        }

        heroesTurn = false;
        mobsTurn = true;

        mobDead = mobHP <= 0;
    }

    if (mobsTurn) {
        // Mob gets to attack
        // Mob rolls attack (1d10)
        mobAttack = d10.Next(1,11);

        // Mob rolls for defense (1d4)
        heroDefense += d4.Next(1,5);

        // Mob's HP are only subtracted if the hero's attack is greater than the mob's defense, and any remaining attack points go against the mob's health.
        if (mobAttack > heroDefense) {
            heroHP -= mobAttack - heroDefense;
            Console.WriteLine($"Mob hits hero for {mobAttack - heroDefense}!");
        } else {
            Console.WriteLine("MOB misses hero by a hair's breadth!");
        }

        mobsTurn = false;
        heroesTurn = true;

        heroDead = heroHP <= 0;
    }

    Console.WriteLine($"\n\nHero has {heroHP} HP.");
    Console.WriteLine($"MOB has {mobHP} HP.\n\n");
}

if (mobDead && !heroDead) {
    Console.WriteLine("MOB is dead. Hero wins!");
}

if (heroDead && !mobDead) {
    Console.WriteLine("Hero is dead. Mob wins!");
}

if (heroDead && mobDead) {
    Console.WriteLine("Hero and MOB killed each other. Nobody wins.");
}

