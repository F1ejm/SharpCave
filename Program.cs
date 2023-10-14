Console.WriteLine("Let's play rock-paper-scissors!");

string[] availableSigns = { "rock", "paper",  "scissors",};
const string EndGameComand = "quit";

while (true)
{
    string? firstPlayerSign = null;
    do
    {
        Console.WriteLine($"Provide sign, first player or write '{EndGameComand}' to end game:");
        firstPlayerSign = Console.ReadLine();
    } while (!availableSigns.Contains(firstPlayerSign) && firstPlayerSign != EndGameComand);
    
    
    if (firstPlayerSign == EndGameComand)
    {
        break;
    }
    
    string?secondPlayerSign = null; 
   
    do
    {   
        Console.WriteLine($"Provide sign, second player or write '{EndGameComand}' to end game:");
        secondPlayerSign = Console.ReadLine();
    } while (!availableSigns.Contains(secondPlayerSign) && secondPlayerSign != EndGameComand);
    
    if (secondPlayerSign == EndGameComand)
    
    {
        break;
    }

    int secondPlayerSignIndex = Array.IndexOf(availableSigns , secondPlayerSign);
    int winningWithSecondPlayerIndex = (secondPlayerSignIndex + 1 ) % availableSigns.Length;
    string winningWithSecondPlayerSign = availableSigns[winningWithSecondPlayerIndex];

    if (firstPlayerSign == secondPlayerSign)
   
    {
        Console.WriteLine("It is a draw");
    }
   
    else if (firstPlayerSign == winningWithSecondPlayerSign)
    {
        Console.WriteLine("First player won");
    }
   
    else
   
    {
        Console.WriteLine("Second player won");
    }
}
Console.WriteLine("Press ENTER to close the game");
Console.ReadLine();
