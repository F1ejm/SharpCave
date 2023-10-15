class ComputerPlayer : Player
{
    public ComputerPlayer(string name) : base(name)
    {
    }

    public override string? GetSign(string[] availableSigns, string endGameCommand)
    {
        string? sign;
        Random rng = new Random();
        int randomSignIndex = rng.Next(availableSigns.Length);
        sign = availableSigns[randomSignIndex];
        Console.WriteLine($"{Name} provided {sign}");
        return sign;
    }
}