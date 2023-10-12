Console.WriteLine("Let's play rock-paper-scissors!");

Console.WriteLine("Provide sign, first player:");


string? firstPlayerSign = Console.ReadLine();

Console.WriteLine("Provide sign, second player:");
 
string? secondPlayerSign = Console.ReadLine();

if (firstPlayerSign == secondPlayerSign)  
{
    Console.WriteLine("It is a draw");
}

else if (firstPlayerSign == "rock" && secondPlayerSign == "scissors"  )
{
    Console.WriteLine("First player won");
}
else if (firstPlayerSign == "scissors" && secondPlayerSign == "paper"  )
{
    Console.WriteLine("First player won");
}
else if (firstPlayerSign == "paper" && secondPlayerSign == "rock"  )
{
    Console.WriteLine("First player won");
}
 
else 
{
    Console.WriteLine("Second player won");
}
Console.WriteLine("Press ENTER to close the game");
Console.ReadLine();
