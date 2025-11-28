namespace MathGame
{
    public class Game
    {
        public int ID {get; set;}
        public string Player { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public OperationType Operation { get; set; }
        public string Result { get; set; }
    }

    public enum OperationType
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }
}