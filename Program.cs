Console.WriteLine("Let's play rock-paper-scissors!");

string[] availableSigns = { "rock", "paper",  "scissors" };

while (true)
{
    string? firstPlayerSign = null;
    do
    {
        Console.WriteLine("Provide sign, first player or write 'quit' to end game:");
        firstPlayerSign = Console.ReadLine();
    } while (!availableSigns.Contains(firstPlayerSign) && firstPlayerSign != "quit");
    
    // } while (firstPlayerSign != "rock" && firstPlayerSign != "scissors" && firstPlayerSign != "paper" && firstPlayerSign != "quit");
    
    if (firstPlayerSign == "quit")
    {
        break;
    }
    
    string?secondPlayerSign = null; 
   
    do
    {   
        Console.WriteLine("Provide sign, second player or write 'quit' to end game:");
        secondPlayerSign = Console.ReadLine();
    } while (!availableSigns.Contains(secondPlayerSign) && secondPlayerSign != "quit");
    
    if (secondPlayerSign == "quit")
    
    {
        break;
    }
   
    if (firstPlayerSign == secondPlayerSign)
   
    {
        Console.WriteLine("It is a draw");
    }
   
    else if ((firstPlayerSign == "rock" && secondPlayerSign == "scissors")
            || (firstPlayerSign == "scissors" && secondPlayerSign == "paper")
            || (firstPlayerSign == "paper" && secondPlayerSign == "rock"))
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
