int targetNum, player1Num;
int round;
const int rounds = 5;

bool player1Won;

bool playAgain() {
    Console.Write("Play another round? (y[es] or n[o]): ");
    string? answer = Console.ReadLine();

    return answer != null && answer.ToLower().StartsWith('y');
}

void playGame() {
    Random die = new();
    targetNum = die.Next(1, 6);
    round = 1;

    do {
        Random playerDie = new();
        Console.Clear();

        player1Num = playerDie.Next(1, 7);
        player1Won = player1Num >= targetNum;
        round++;

        if (!player1Won) {
            Console.WriteLine($"You rolled a {player1Num}, but the target is {targetNum}.");

            if (!playAgain()) {
                break;
            }
        }
    } while(round <= rounds && !player1Won);

    if (player1Won) {
        Console.WriteLine($"Congratulations, you've won!! You rolled a {targetNum}.");
    } else {
        Console.WriteLine($"Sorry, but no dice. Thanks for playing!");
    }
}

do {
    playGame();
} while (playAgain());