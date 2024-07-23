string[] rolesAllowed = ["Administrator", "Manager", "User"];
string? input;

Console.WriteLine("Please enter one of the following roles (Ctrl-C to quit):");
int roleIndex = 0;

foreach (string role in rolesAllowed) {
    Console.WriteLine($"{++roleIndex}. {role}");
}

bool invalidRole;

do {
    input = Console.ReadLine();

    if (input == null) {
        break;
    }

    invalidRole = !rolesAllowed.Contains<string>(input);
    if (invalidRole) {
        Console.WriteLine($"The role you entered, {input}, is not a valid role. Please enter one of the roles listed to continue.");
    }
} while (invalidRole);

if (input != null) {
    Console.WriteLine($"You selected the {input} role. Thank you!");
}