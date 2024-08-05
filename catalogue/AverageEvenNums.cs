Console.Write("Enter the lower bound: ");
int lowerBound = int.Parse(Console.ReadLine());

Console.Write("Enter the upper bound: ");
int upperBound = int.Parse(Console.ReadLine());

bool success = false;

do {
    try {
        decimal averageValue = AverageOfEvenNumbers(lowerBound, upperBound);

        Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is: {averageValue}.");
        Console.ReadLine();

        success = true;
    } catch (ArgumentOutOfRangeException argOutOfRange) {
        Console.WriteLine($"Invalid input. {argOutOfRange.Message}\n{argOutOfRange.StackTrace}");
        Console.WriteLine($"Please enter an upper bound that is greater than {lowerBound}.");
        upperBound = int.Parse(Console.ReadLine());
    }
} while (!success);

static decimal AverageOfEvenNumbers(int lowerBound, int upperBound) {
    int sum = 0;

    ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(lowerBound, upperBound);

    for (int i = lowerBound; i <= upperBound; i++) {
        sum += i % 2 == 0 ? i : 0;
    }

    // Don't need a counter variable - the number of evens between a lower bound and upper bound
    // will always be the difference of the two divided in half, plus 1 to include the upper bound.
    return (decimal)(sum / (int)(((upperBound - lowerBound) / 2) + 1));
}

