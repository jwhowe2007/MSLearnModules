string newMessage = "(What if) there are (more than) one (set of parentheses)? Uhoh. Thought you had it all figured out, eh? Well, here's a curveball; good luck!\nBet you're not smart enough to solve THIS one...";

while (true) {
    int opening = newMessage.IndexOf('(');
    if (opening == -1) {
        break;
    }

    opening += 1;
    int closing = newMessage.IndexOf(')');
    int length = closing - opening;
    Console.WriteLine(newMessage.Substring(opening, length));

    newMessage = newMessage[(closing + 1)..];
}