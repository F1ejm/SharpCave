class Game
{
    string[] availableSigns = { "rock", "paper", "scissors", };
    const string EndGameComand = "quit";
    int firstPlayerPoints = 0;
    int secondPlayerPoints = 0;
    int expectedRoundNumber = 3;
    bool keepPlayng = true;
    bool playingWithOtherHuman;

    bool PlayRound(int roundNumber)
    {
        Console.WriteLine($"Round: {roundNumber}");

        string? firstPlayerSign = GetPlayerSign("first");

        if (firstPlayerSign == EndGameComand)
        {
            keepPlayng = false;
            return false;
        }

        string? secondPlayerSign;

        if (playingWithOtherHuman)
        {
            secondPlayerSign = GetPlayerSign("second");

            if (secondPlayerSign == EndGameComand)

            {
                keepPlayng = false;
                return false;
            }
        }

        else
        {
            secondPlayerSign = GetComputerPlayerSign();
        }

        string winningWithSecondPlayerSign = GetSignWinningWith(secondPlayerSign);

        if (firstPlayerSign == secondPlayerSign)

        {
            Console.WriteLine("It is a draw");
        }

        else if (firstPlayerSign == winningWithSecondPlayerSign)
        {
            DisplayWinningText("First player", firstPlayerSign, secondPlayerSign);
            firstPlayerPoints = firstPlayerPoints + 1;
        }

        else
        {
            DisplayWinningText("Second player", secondPlayerSign, firstPlayerSign);
            secondPlayerPoints = secondPlayerPoints + 1;
        }
        Console.WriteLine();
        Console.WriteLine($"First player points {firstPlayerPoints}");
        Console.WriteLine($"Second player points {secondPlayerPoints}");
        Console.WriteLine();

        return true;
    }

    private static void DisplayWinningText(string playerName, string? WinningSign, string? losingSign)
    {
        Console.WriteLine($"{playerName} won! ( first player chose : {WinningSign} and second player chose : {losingSign})");
    }

    private string? GetPlayerSign(string playerName)
    {
        string? firstPlayerSign = null;
        do
        {
            Console.WriteLine($"Provide sign, {playerName} player or write '{EndGameComand}' to end game:");
            firstPlayerSign = Console.ReadLine()?.ToLower().Trim();
        } while (!availableSigns.Contains(firstPlayerSign) && firstPlayerSign != EndGameComand);
        return firstPlayerSign;
    }

    private string GetSignWinningWith(string? sign)
    {
        int SignIndex = Array.IndexOf(availableSigns, sign);
        int winningSignIndex = (SignIndex + 1) % availableSigns.Length;
        string winningWithProvidedSign = availableSigns[winningSignIndex];
        return winningWithProvidedSign;
    }

    private string GetComputerPlayerSign()
    {
        string? secondPlayerSign;
        Random rng = new Random();
        int randomSignIndex = rng.Next(availableSigns.Length);
        secondPlayerSign = availableSigns[randomSignIndex];

        Console.WriteLine($"Second player provided {secondPlayerSign}");
        return secondPlayerSign;
    }

    public void Run()
    {
        Console.WriteLine("Let's play rock-paper-scissors!");

        Console.WriteLine("Do you chave anyone to play witch? (yes/no)");
        playingWithOtherHuman = (Console.ReadLine()?.ToLower().Trim() == "yes");
        Console.WriteLine(playingWithOtherHuman);

        while (keepPlayng)
        {
            PlayGame();
            DisplayGameSummary();

            ResetGameData();
        }

        Console.WriteLine("Press ENTER to close the game");
        Console.ReadLine();

    }

    private void ResetGameData()
    {
        firstPlayerPoints = 0;
        secondPlayerPoints = 0;
    }

    private void PlayGame()
    {
        for (int roundNumber = 1; roundNumber <= expectedRoundNumber; roundNumber++)
        {
            bool continueGame = PlayRound(roundNumber);
            if (!continueGame)
            {
                break;
            }
        }
    }

    private void DisplayGameSummary()
    {
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
    }
}