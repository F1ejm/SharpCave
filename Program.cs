using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;

Console.WriteLine("Let's play rock-paper-scissors!");
Console.WriteLine("Do you chave anyone to play witch? (yes/no)");
bool playingWithOtherHuman = (Console.ReadLine()?.ToLower().Trim() == "yes");
Console.WriteLine(playingWithOtherHuman);

string[] availableSigns = { "rock", "paper", "scissors", };
const string EndGameComand = "quit";
int firstPlayerPoints = 0;
int secondPlayerPoints = 0;
int expectedRoundNumber = 3;

bool keepPlayng = true;

while (keepPlayng)
{
    for (int roundNumber = 1; roundNumber <= expectedRoundNumber; roundNumber++)
    {

        Console.WriteLine($"Round: {roundNumber}");

        string? firstPlayerSign = null;
        do
        {
            Console.WriteLine($"Provide sign, first player or write '{EndGameComand}' to end game:");
            firstPlayerSign = Console.ReadLine()?.ToLower().Trim();
        } while (!availableSigns.Contains(firstPlayerSign) && firstPlayerSign != EndGameComand);


        if (firstPlayerSign == EndGameComand)
        {
            keepPlayng = false;
            break;
        }

        string? secondPlayerSign;

        if (playingWithOtherHuman) 
        {
            do
            {
                Console.WriteLine($"Provide sign, second player or write '{EndGameComand}' to end game:");
                secondPlayerSign = Console.ReadLine()?.ToLower().Trim();
            } while (!availableSigns.Contains(secondPlayerSign) && secondPlayerSign != EndGameComand);

            if (secondPlayerSign == EndGameComand)

            {
                keepPlayng = false;
                break;
            }
        }

        else
        {
            Random rng = new Random();
            int randomSignIndex = rng.Next(availableSigns.Length);
            secondPlayerSign = availableSigns[randomSignIndex];

            Console.WriteLine($"Second player provided {secondPlayerSign}");
        }

        int secondPlayerSignIndex = Array.IndexOf(availableSigns, secondPlayerSign);
        int winningWithSecondPlayerIndex = (secondPlayerSignIndex + 1) % availableSigns.Length;
        string winningWithSecondPlayerSign = availableSigns[winningWithSecondPlayerIndex];

        if (firstPlayerSign == secondPlayerSign)

        {
            Console.WriteLine("It is a draw");
        }

        else if (firstPlayerSign == winningWithSecondPlayerSign)
        {
            Console.WriteLine($"First player won! ( first player chose : {firstPlayerSign} and second player chose : {secondPlayerSign})");
            firstPlayerPoints = firstPlayerPoints + 1;
        }

        else
        {
            Console.WriteLine($"Second player won! ( first player chose : {firstPlayerSign} and second player chose : {secondPlayerSign})");
            secondPlayerPoints = secondPlayerPoints + 1;
        }
        Console.WriteLine();
        Console.WriteLine($"First player points {firstPlayerPoints}");
        Console.WriteLine($"First player points {secondPlayerPoints}");
        Console.WriteLine();
    }

    if (firstPlayerPoints > secondPlayerPoints)
    {
        Console.WriteLine($"First player crushed second player   {firstPlayerPoints} to  {secondPlayerPoints}");
    }
    else if (secondPlayerPoints > firstPlayerPoints)
    {
        Console.WriteLine($"Second player cruched first player   {secondPlayerPoints} to {firstPlayerPoints}");
    }
    else if (firstPlayerPoints == secondPlayerPoints)
    {
        Console.WriteLine("It is total draw");
    }
    firstPlayerPoints = 0;
    secondPlayerPoints = 0;
}

Console.WriteLine("Press ENTER to close the game");
Console.ReadLine();
