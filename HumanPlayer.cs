class HumanPlayer : Player
{
    public HumanPlayer(string name) : base(name)
    {
    }

    public override string? GetSign(string[] availableSigns, string endGameCommand)
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