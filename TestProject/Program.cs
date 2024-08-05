string[][] userInputValues = [
    ["1", "2", "3"],
    ["1", "two", "3"],
    ["0", "1", "2"]
];

static void dumpExceptionMessage(string exceptionMessage) {
    Console.WriteLine("Process1 encounted an issue; process aborted.");
    Console.WriteLine(exceptionMessage + "\n");
}

static void Workflow1(string[][] inputArray) {
    foreach (string[] inputVector in inputArray) {
        try {
            Process1(inputVector);
            Console.WriteLine("Process1 completed successfully!\n");
        } catch (FormatException formatEx) {
            dumpExceptionMessage(formatEx.Message);
        } catch (DivideByZeroException divZeroEx) {
            dumpExceptionMessage(divZeroEx.Message);
        }
    }
}

static void Process1(string[] vector) {
    foreach (string datum in vector) {
        if (int.TryParse(datum, out int value)) {
            if (value != 0) {
                checked {
                    int calculatedValue = 4 / value;
                    Console.WriteLine($"Calculated value: {calculatedValue}");
                }
            } else {
                throw new DivideByZeroException($"Invalid datum {{{datum}}}. User input values must be non-zero values.");
            }
        } else {
            throw new FormatException($"Invalid datum {{{datum}}}. User input values must be valid integers.");
        }
    }
}

Workflow1(userInputValues);
