var rando = new Random();
bool flip = false;

int headsTrials = 0;
int tailsTrials = 0;

do {
    flip = rando.Next(0,2) != 0;
    headsTrials++;
} while (!flip);

do {
    flip = rando.Next(0,2) != 0;
    tailsTrials++;
} while (flip);

Console.WriteLine($"# of trials to get heads: {headsTrials}.");
Console.WriteLine($"# of trials to get tails: {tailsTrials}.");

Console.WriteLine($"Heads or Tails: {(flip ? "Heads" : "Tails")}");