public class NewGameRequest
{
    public int NumberOfPlayers { get; private set; }

    public NewGameRequest (int numberOfPlayers)
    {
        NumberOfPlayers = numberOfPlayers;
    }
}