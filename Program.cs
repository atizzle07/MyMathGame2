
// // Console.Clear();
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using MathGame;

Console.Write("Welcome to the Math Game. Please enter your name: ");
string? userName = Console.ReadLine();

decimal winningScore = 10;

Console.WriteLine($"Thanks for playing, {userName}!\n\n You need {winningScore} points to win.\n");

// Helper Variables
string? userInput;
int num1;
int num2;
Random random = new();
int answer;
int userScore = 0;
bool gameWon = false;
List<Game> gameHistory = new(); //TODO - Create this as a new class with games as the property. Then create methods for CRUD operations within this class.

do // Main Game loop
{
    Console.WriteLine("Please make a selection:\n\n" +
                "[1] - Addition\n" +
                "[2] - Subtraction\n" +
                "[3] - Multiplication\n" +
                "[4] - Division\n" +
                "[Q] - Quit the game");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            AdditionGame();
            saveGame();
            Console.WriteLine($"Score: {userScore}");
            break;
        case "2":
            SubtractGame();
            saveGame();
            Console.WriteLine($"Score: {userScore}");
            break;
        case "3":
            MultiplyGame();
            saveGame();
            Console.WriteLine($"Score: {userScore}");
            break;
        case "4":
            DivisionGame();
            saveGame();
            Console.WriteLine($"Score: {userScore}");
            break;
        case "q":
            Console.WriteLine($"Score: {userScore}");
            Console.WriteLine("Exiting program... Press any key to proceed.");
            Console.ReadLine();
            userScore = (int)winningScore + 1;
            break;
        default:
            Console.WriteLine("That is not a valid selection. Please try again...");
            break;
    }

} while (userScore < winningScore);

void AdditionGame()
{
    // Console.Clear();
    int[] numbers = GetNumbers(1,11);
    answer = numbers[0] + numbers[1];

    Console.WriteLine($"What is {numbers[0]} + {numbers[1]}?");
    userInput = Console.ReadLine();
    int.TryParse(userInput, out int userCheck);

    //TODO - Need to introduce null or invalid error handling
    //UPGRADE - Need to refactor this code into a single method shared between each game
    if (userCheck == answer)
    {
        Console.WriteLine("That is correct!");
        gameWon = true;
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            gameWon = false;
            userScore--;
        }
    }
    
}

void SubtractGame()
{
    // Console.Clear();
    int[] numbers = GetNumbers(1,11);
    answer = numbers[0] - numbers[1];

    Console.WriteLine($"What is {numbers[0]} - {numbers[1]}?");
    userInput = Console.ReadLine();
    int.TryParse(userInput, out int userCheck);

    //TODO - Need to introduce null or invalid error handling
    //UPGRADE - Need to refactor this code into a single method shared between each game

    if (userCheck == answer)
    {
        Console.WriteLine("That is correct!");
        gameWon = true;
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            gameWon = false;
            userScore--;
        }
    }
}

void MultiplyGame()
{
    // Console.Clear();
    int[] numbers = GetNumbers(1,11);
    answer = numbers[0] * numbers[1];

    Console.WriteLine($"What is {numbers[0]} x {numbers[1]}?");
    userInput = Console.ReadLine();
    int.TryParse(userInput, out int userCheck);

    //TODO - Need to introduce null or invalid error handling
    //UPGRADE - Need to refactor this code into a single method shared between each game
    if (userCheck == answer)
    {
        Console.WriteLine("That is correct!");
        gameWon = true;
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            gameWon = false;
            userScore--;
        }
    }
}

void DivisionGame()
{
    // Console.Clear();
    int[] numbers = GetNumbers(1,100);
    bool validSelection = false;
    do // Return 
    {
        if (numbers[0] % numbers[1] == 0)
        {
            validSelection = true;
        } else
        {
            numbers = GetNumbers(1,100);
        }
  
    } while (!validSelection);
    
    
    
    // TODO - Add logic to only proceed with the division game if the numbers produce an answer that is a whole number (int)
    answer = numbers[0] / numbers[1];

    Console.WriteLine($"What is {numbers[0]} / {numbers[1]}?");
    userInput = Console.ReadLine();
    int.TryParse(userInput, out int userCheck);

    //TODO - Need to introduce null or invalid error handling
    //UPGRADE - Need to refactor this code into a single method shared between each game
    if (userCheck == answer)
    {
        Console.WriteLine("That is correct!");
        gameWon = true;
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            gameWon = false;
            userScore--;
        }
    }
}

int[] GetNumbers(int minValue, int maxValue)
{
    /// returns two random numbers inclusive of minValue and inclusive of maxValue
    num1 = random.Next(minValue, maxValue+1);
    num2 = random.Next(minValue, maxValue+1);

    return [num1, num2];
}

void saveGame()
{
    System.Console.WriteLine("Game saved!");
    Game game = new();
    game.ID = gameHistory.Count+1;
    game.Player = userName;
    game.Num1 = num1;
    game.Num2 = num2;
    game.Result = gameWon ? "Win" : "Loss";
    switch (userInput) // Saves operation type
    {
        case "1":
            game.Operation = OperationType.Addition;
            break;
        case "2":
            game.Operation = OperationType.Subtraction;
            break;
        case "3":
            game.Operation = OperationType.Multiplication;
            break;
        case "4":
            game.Operation = OperationType.Division;
            break;
        default:
            System.Console.WriteLine("Error, an operation type must be declared to save a game.");
            break;
    }
    gameHistory.Add(game);
}

