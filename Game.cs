class Game
{
    string[] availableSigns = { "rock", "paper", "scissors" };
    const string EndGameCommand = "quit";
    int expectedRoundNumber = 3;
    bool keepPlaying = true;
    bool playingWithOtherHuman;
    Player firstPlayer = new Player("First player");
    Player secondPlayer = new Player("Second player");

    public void Run()
    {
        Console.WriteLine("Let's play Rock-Paper-Scissors!");

        Console.WriteLine("Do you have anyone to play with? (yes/no)");
        playingWithOtherHuman = (Console.ReadLine()?.ToLower().Trim() == "yes");

        while (keepPlaying)
        {
            PlayGame();
            DisplayGameSummary();
            ResetGameData();
        }

        Console.WriteLine("Press Enter to close the game...");
        Console.ReadLine();
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
        if (firstPlayer.Points > secondPlayer.Points)
        {
            Console.WriteLine($"== {firstPlayer.Name} crushed {secondPlayer.Name.ToLower()} {firstPlayer.Points} to {secondPlayer.Points}!");
        }
        else if (secondPlayer.Points > firstPlayer.Points)
        {
            Console.WriteLine($"== {secondPlayer.Name} crushed {firstPlayer.Name.ToLower()} {secondPlayer.Points} to {firstPlayer.Points}!");
        }
        else
        {
            Console.WriteLine($"== It's a total draw {firstPlayer.Points} to {secondPlayer.Points}!");
        }
    }
    
    private void ResetGameData()
    {
        firstPlayer.Points = 0;
        secondPlayer.Points = 0;
    }

    private bool PlayRound(int roundNumber)
    {
        Console.WriteLine($"  Round {roundNumber}");

        string? firstPlayerSign = firstPlayer.GetSign(availableSigns, EndGameCommand);

        if (firstPlayerSign == EndGameCommand)
        {
            keepPlaying = false;
            return false;
        }

        string? secondPlayerSign;
        if (playingWithOtherHuman)
        {
            secondPlayerSign = secondPlayer.GetSign(availableSigns, EndGameCommand);

            if (secondPlayerSign == EndGameCommand)
            {
                keepPlaying = false;
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
            Console.WriteLine("It's a draw!");
        }
        else if (firstPlayerSign == winningWithSecondPlayerSign)
        {
            DisplayWinningText(firstPlayer.Name, firstPlayerSign, secondPlayerSign);
            firstPlayer.Points += 1;
        }
        else
        {
            DisplayWinningText(secondPlayer.Name, secondPlayerSign, firstPlayerSign);
            secondPlayer.Points += 1;
        }

        Console.WriteLine($"[Player1] {firstPlayer.Points} : {secondPlayer.Points} [Player2]");

        return true;
    }

    private string GetComputerPlayerSign()
    {
        string? secondPlayerSign;
        Random rng = new Random();
        int randomSignIndex = rng.Next(availableSigns.Length);
        secondPlayerSign = availableSigns[randomSignIndex];
        Console.WriteLine($"{secondPlayer.Name} provided {secondPlayerSign}");
        return secondPlayerSign;
    }

    private string GetSignWinningWith(string? sign)
    {
        int signIndex = Array.IndexOf(availableSigns, sign);
        int winningSignIndex = (signIndex + 1) % availableSigns.Length;
        string winningWithProvidedSign = availableSigns[winningSignIndex];
        return winningWithProvidedSign;
    }
    
    private static void DisplayWinningText(string playerName, string? winningSign, string? losingSign)
    {
        Console.WriteLine($"{playerName} won: {winningSign} beats {losingSign}!");
    }
}