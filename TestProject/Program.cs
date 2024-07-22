string[] fraudulentOrderIDs = [
    "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179"
];

Console.WriteLine($"{fraudulentOrderIDs.Length} fraudulent order listing{(fraudulentOrderIDs.Length > 1 ? "s" : "")}:");

// Display only the fraudulent order IDs that start with 'B'.
foreach (string fraudulentOrderID in fraudulentOrderIDs) {
    if (fraudulentOrderID.StartsWith('B')) {
        Console.WriteLine($"Order ID: {fraudulentOrderID}");
    }
}
