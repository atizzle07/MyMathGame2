namespace MathGame;

public class Game
{
    public int ID {get; set;}
    public string? Player { get; set; }
    public int Num1 { get; set; }
    public int Num2 { get; set; }
    public OperationType Operation { get; set; }
    public string? Result { get; set; }
}

public enum OperationType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class GameHistory
{
    public required List<Game> GameItem { get; set; }

    public void AddGameItem(Game game)
    {
        GameItem.Add(game);
    }

    public void ClearHistory()
    {
        GameItem.Clear();
    }

    public void DisplayItems()
    {
        Console.WriteLine("ID\t|\tPlayer\t|\tNum1\t|\tNum2\t|\tOperation\t|\tResult\t|"); //Header info
        Console.WriteLine("----\t|\t----\t|\t----\t|\t----\t|\t----\t|\t----|\t"); //Lines under headers
        foreach (var item in GameItem)
        {
            Console.WriteLine($"{item.ID}\t|\t" +
                              $"{item.Player}\t|\t" +
                              $"{item.Num1}\t|\t" +
                              $"{item.Num2}\t|\t" +
                              $"{item.Operation}\t|\t" +
                              $"{item.Result}\t|");
        }
    }
}