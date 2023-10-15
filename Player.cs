abstract class Player 
{
    public int Points { get; set; }
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public abstract string? GetSign(string[] availableSigns, string endGameCommand);
}