Random random = new();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = ["('-')", "(^-^)", "(X_X)"];
string[] foods = ["@@@@@", "$$$$$", "#####"];
string blankFood = "     ";

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;
int speedFactor = 1;

InitializeGame();
while (!shouldExit)
{
    if (PlayerIsEnergized()) {
        speedFactor = 3;
    }

    Move(true, speedFactor);
    if (TerminalResized()) {
        shouldExit = true;
        Console.Clear();
        Console.WriteLine("Console was resized. Program exiting.");
    }
}

// Returns true if the Terminal was resized
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

void ClearFood() {
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(blankFood);
    Console.SetCursorPosition(playerX, playerY);
}

// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

bool PlayerConsumedFood() {
    // If the leftmost x coordinate of the player equals the leftmost food coordinate,
    // the player is considered to have consumed the entire food item.

    // Make sure we slurp up the food if we fly past it!
    // The absolute distance between player position and food position should be

    if (speedFactor > 1) {
        return ((Math.Abs(playerX - foodX) < speedFactor) && Math.Abs(playerY - foodY) < speedFactor);
    } else {
        return playerX == foodX && playerY == foodY;
    }
    // return ((Math.Abs(playerX - foodX) < speedFactor) && playerY == foodY) || ((Math.Abs(playerY - foodY) < speedFactor) && playerX == foodX);
    // if (speedFactor > 1) {

    //     return Math.Abs(playerX - foodX) < speedFactor && Math.Abs(playerY - foodY) < speedFactor;
    // } else {
    //     return playerX == foodX && playerY == foodY;
    // }
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

bool PlayerIsPoisoned() {
    return player == states[^1];
}

bool PlayerIsEnergized() {
    return player == states[1];
}

// Temporarily stops the player from moving
void FreezePlayer()
{
    Thread.Sleep(1000);
    player = states[0];
}

// Reads directional input from the Console and moves the player
// Args: speed - How many spaces the player should move in each direction for one keypress
// Example: speed = 3 means that the player will move 3 in any direction when key is pressed.
void Move(bool dieOnInvalidInput = false, int speed = 1)
{
    int lastX = playerX;
    int lastY = playerY;

    if (PlayerIsPoisoned()) {
        FreezePlayer();
    }

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            playerY -= speed;
            break;
		case ConsoleKey.DownArrow:
            playerY += speed;
            break;
		case ConsoleKey.LeftArrow:
            playerX -= speed;
            break;
		case ConsoleKey.RightArrow:
            playerX += speed;
            break;
		case ConsoleKey.Escape:
            shouldExit = true;
            break;
        default:
            if (dieOnInvalidInput) {
                shouldExit = true;
                Console.Clear();
                Console.WriteLine("Invalid input detected. Terminating game.");
                return;
            }
            break;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }

    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    if (PlayerConsumedFood()) {
        // Player ate the normal food, so it's back to the old slow player!
        if (player == states[0]) {
            speedFactor = 1;
        }

        if (speedFactor > 1) {
            // We want to erase the food because it was eaten... (duh)
            ClearFood();
        }

        ChangePlayer(); // Update appearance based on food consumed
        ShowFood(); // Needs more food!
    } else {
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
    }
}

// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}