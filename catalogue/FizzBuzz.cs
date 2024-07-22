Console.WriteLine("FizzBuzz Time!");
string fizzBuzz;
int max = 100;

for (int i = 1; i <= max; i++) {
    fizzBuzz = "";

    if (i % 3 == 0) {
        fizzBuzz += "Fizz";
    }

    if (i % 5 == 0) {
        fizzBuzz += "Buzz";
    }

    Console.WriteLine($"{i} {(fizzBuzz != "" ? "-" : "")} {fizzBuzz}");
}

Console.WriteLine("FizzBuzz Stats:");
Console.WriteLine($"Fizzes: {max / 3}\tBuzzes: {max / 5}\tFizzBuzzes: {max / 15}");