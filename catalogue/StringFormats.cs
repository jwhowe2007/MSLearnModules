// string paymentId = "769C";
// string payeeName = "Mr. Magnus Howe";
// decimal paymentAmount = 5000.00m;

// var formattedLine = paymentId.PadRight(6, '+');
// formattedLine += payeeName.PadRight(24, '*');
// formattedLine += $"{paymentAmount:C}".PadLeft(10, '!');

// Console.WriteLine("".PadLeft(40, '='));
// Console.WriteLine(formattedLine);

string customerName = "Ms. Barros";
string currentProduct = "Magic Yield";

int currentShares = 2975000;
decimal currentReturn = 0.1275m;
decimal currentProfit = 55000000.0m;

string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
decimal newProfit = 63000000.0m;

Console.WriteLine($"Dear {customerName},\nAs a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n");
Console.WriteLine($"Currently, you own {currentShares:C} shares at a return rate of {currentReturn:P2}.\n");
Console.WriteLine($"Our new product, {newProduct}, offers a return of {newReturn:P2}.\nGiven your current volume, your potential profit would be {newProfit:C}.\n");
Console.WriteLine("Quick comparision: \n");

string comparisonMessage = "";
comparisonMessage += $"{currentProduct}".PadRight(20);
comparisonMessage += $"{currentReturn:P2}".PadRight(10);
comparisonMessage += $"{currentProfit:C}\n";
comparisonMessage += $"{newProduct}".PadRight(20);
comparisonMessage += $"{newReturn:P2}".PadRight(10);
comparisonMessage += $"{newProfit:C}";

Console.WriteLine(comparisonMessage);