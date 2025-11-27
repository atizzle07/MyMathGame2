
// Console.Clear();
Console.Write("Welcome to the Math Game. Please enter your name: ");
string? userName = Console.ReadLine();

Console.WriteLine($"Thanks for playing, {userName}!\n");

// Helper Variables
bool gameActive = true;
string? userInput;
int num1;
int num2;
Random random = new();
int answer;
int userScore = 0;

do // Main Game loop
{
    Console.WriteLine("Please make a selection:\n\n" +
                "[1]- Addition\n" +
                "[2] - Subtraction\n" +
                "[3] - Multiplication\n" +
                "[4] - Division\n" +
                "[Q] - Quit the game");
    userInput = Console.ReadLine();

    switch (userInput.ToLower())
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
        case "q":
            Console.WriteLine("Exiting program... Press any key to proceed.");
            Console.ReadKey();
            gameActive = false;
            break;
        default:
            Console.WriteLine("That is not a valid selection. Please try again...");
            break;
    }

} while (gameActive == true);

void AdditionGame()
{
    Console.Clear();
    int[] numbers = GetNumbers();
    answer = numbers[0] + numbers[1];

    Console.WriteLine($"What is {numbers[0]} + {numbers[1]}?");
    userInput = Console.ReadLine();
    int.TryParse(userInput, out int userCheck);

    //TODO - Need to introduce null or invalid error handling
    //UPGRADE - Need to refactor this code into a single method shared between each game
    if (userCheck == answer)
    {
        Console.WriteLine("That is correct!");
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            userScore--;
        }
    }
    
}

void SubtractGame()
{
    Console.Clear();
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
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            userScore--;
        }
    }
}

void MultiplyGame()
{
    Console.Clear();
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
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            userScore--;
        }
    }
}

void DivisionGame()
{
    Console.Clear();
    int[] numbers = GetNumbers(1,11);
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
        userScore++;
    }
    else
    {
        Console.WriteLine("Sorry, that answer is incorrect.");
        if (userScore > 0) // Do not decrease score if it is already 0, which is the lowest valid score
        {
            userScore--;
        }
    }
}

int[] GetNumbers(int minValue, int maxValue)
{
    num1 = random.Next(minValue, maxValue);
    num2 = random.Next(minValue, maxValue);

    return [num1, num2];
}