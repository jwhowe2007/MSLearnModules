string baseEString = "2.71828";
double baseE;

if (double.TryParse(baseEString, out baseE)) {
    Console.WriteLine($"The base of the natural logarithm is e: {baseE}.\nThis is also known as 'Euler's Number'.");
} else {
    Console.WriteLine("Failed to parse constant value.");
}

// Compute the hyperbolic sine of an angle (in radians)
double angle = 2*Math.PI;

// cosh = (x^e - x^(-e)) / 2
double cosh = (Math.Pow(baseE, angle) + Math.Pow(baseE, -angle)) / 2.0d;

Console.WriteLine($"cosh(pi / 3) = {cosh}");
