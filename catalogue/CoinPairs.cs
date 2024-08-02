const int targetValue = 80;
int[] coins = [5, 5, 50, 25, 25, 10, 5];

static int[,] TwoCoins(int[] coins, int target = 150) {
    int total;
    int pairsMax = coins.Length * coins.Length;

    int[,] coinPairs = new int[pairsMax, 2];
    int i = 0, j = 0, pair = 0;

    // Process all unique tuples of coins within the coins array
    do {
        total = coins[i] + coins[j];

        if (total == target) {
            Console.WriteLine($"Matching coins indices: [{i}, {j}]");
            // Add the coins to the pairs array
            coinPairs[pair,0] = coins[i];
            coinPairs[pair,1] = coins[j];
            pair++;
        }

        if (++j == coins.Length) {
            i++;
            j = i;
        }
    } while (i < coins.Length);

    return coinPairs;
}

int[,] resultCoins = TwoCoins(coins, targetValue);
int pairsFound = 0;

Console.WriteLine($"Pairs of coins totalling the target value {targetValue}:");

for (int index = 0; index < coins.Length / coins.Rank; index++) {
    int[] pair = [resultCoins[index,0], resultCoins[index,1]];

    if (pair[0] != 0 || pair[1] != 0) {
        pairsFound++;
        Console.WriteLine($"[{pair[0]}c, {pair[1]}c]");
    }
}

if (pairsFound == 0) {
    Console.WriteLine("No two coins make change.");
}
