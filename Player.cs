class Player 
{
    public int Points { get; set; }
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public string? GetSign(string[] availableSigns, string endGameCommand)
    {
        string? sign;
        do
        {
            Console.WriteLine($"Provide sign, {Name.ToLower()} (or write '{endGameCommand}' to end game):");
            sign = Console.ReadLine()?.ToLower().Trim();
        } while (!availableSigns.Contains(sign) && sign != endGameCommand);
        return sign;
    }
}