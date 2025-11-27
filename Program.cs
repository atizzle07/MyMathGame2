using System.Net.WebSockets;

Console.Clear();
System.Console.Write("Welcome to the Math Game. Please enter your name: ");
string? userName = Console.ReadLine();

System.Console.WriteLine($"Thanks for playing, {userName}! Please select an option from the menu:");

// Helper Variables
bool gameActive = true;
string? userInput;
int num1;
int num2;
Random random = new();
int answer;
int userScore;

do // Main Game loop
{
    System.Console.WriteLine("Please make a selection:\n\n" +
                "[1]- Addition\n" +
                "[2] - Subtraction\n" +
                "[3] - Multiplication\n" +
                "[4] - Division\n" +
                "[Q] - Quit the game");
    userInput = Console.ReadKey().ToString();

    switch (userInput)
    {
        case "1":
            AdditionGame();
            break;
        case "2":
            SubtractGame();
            break;
        case "3":
            MultiplyGame();
            break;
        case "4":
            DivisionGame();
            break;
        case "Q":
            System.Console.WriteLine("Exiting program... Press any key to proceed.");
            Console.ReadKey();
            gameActive = false;
            break;
        default:
            System.Console.WriteLine("That is not a valid selection. Please try again...");
            break;
    }

} while (gameActive == true);

void AdditionGame()
{
    Console.Clear();
    int[] numbers = GetNumbers();
    answer = numbers[0] + numbers[1];

    System.Console.WriteLine($"What is {numbers[0]} + {numbers[1]}?");
    userInput = Console.ReadLine();
    int.TryParse(userInput, out int userCheck);

    if (userCheck == answer)
    {
        System.Console.WriteLine("That is correct!");
        userScore++;
    }
    else
    {
        System.Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            userScore--;
        }
    }
    //TODO - Need to introduce null or invalid error handling
}

void SubtractGame()
{

}

void MultiplyGame()
{

}

void DivisionGame()
{

}

int[] GetNumbers()
{
    num1 = random.Next(1, 10);
    num2 = random.Next(1, 10);

    return [num1, num2];
}