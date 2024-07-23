using System.Diagnostics;

void easyShortSolution() {
    string[] testStrings = [
        "     I like pizza. I like roast chicken. I like salad.",
        "   I like all three!"
    ];

    foreach (string pizzaPrefs in testStrings) {
        // For the first string, parse out the sentences.
        string[] subStrings = pizzaPrefs.Split(". ");

        foreach (string substr in subStrings) {
            Console.WriteLine(substr.TrimStart().TrimEnd('.'));
        }
    }
}

void longConvolutedSolution() {
    string[] testStrings = [
        "     I like pizza. I like roast chicken. I like salad.",
        "   I like all three!"
    ];

    int periodLocation;

    foreach (string myString in testStrings) {
        string subSentence, sentenceFragment = myString;

        // Get the next period location
        periodLocation = myString.IndexOf('.');

        while (periodLocation != -1) {
            subSentence = sentenceFragment.Remove(periodLocation).TrimStart();
            sentenceFragment = sentenceFragment[(periodLocation + 1)..];
            periodLocation = sentenceFragment.IndexOf('.');

            Console.WriteLine(subSentence);
        }

        Console.WriteLine(sentenceFragment.Trim());
    }
}

// Profile shorter, more straightforward solution (which is also easier to read)
Stopwatch stopper = Stopwatch.StartNew();

Console.WriteLine("Easy, short pizza menu parsing solution:");
easyShortSolution();

stopper.Stop();
long endTime = stopper.ElapsedMilliseconds;
Console.WriteLine($"Execution time: {endTime}ms.\n");

// Profile longer, more detailed solution
stopper.Restart();
Console.WriteLine("Longer pizza ingredient menu solution:");
longConvolutedSolution();

stopper.Stop();
endTime = stopper.ElapsedMilliseconds;
Console.WriteLine($"Execution time: {endTime}ms.");

