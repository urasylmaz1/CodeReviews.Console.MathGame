var gameHistory = new List<string>();
Random random = new Random();
int score = 0;

while (true)
{
    Console.WriteLine("Welcome to the Math Game!");
    Console.WriteLine("Choose a math operation: ");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. View game history");
    Console.WriteLine("6. Exit");
    int choice = ReadInt();

    switch (choice)
    {
        case 1:
            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);
            char operation = '+';
            int result = num1 + num2;
            DisplayQuestion($"{num1} + {num2}");
            AddToHistory(operation.ToString(), num1, num2, result);
            int userAnswer = ReadInt();
            score = CheckAnswer(userAnswer, result, score);
            DisplayScore(score);
            break;
        case 2:
            num1 = random.Next(1, 100);
            num2 = random.Next(1, 100);
            operation = '-';
            result = num1 - num2;
            DisplayQuestion($"{num1} - {num2}");
            AddToHistory(operation.ToString(), num1, num2, result);
            userAnswer = ReadInt();
            score = CheckAnswer(userAnswer, result, score);
            DisplayScore(score);
            break;
        case 3:
            num1 = random.Next(1, 100);
            num2 = random.Next(1, 100);
            operation = '*';
            result = num1 * num2;
            DisplayQuestion($"{num1} * {num2}");
            AddToHistory(operation.ToString(), num1, num2, result);
            userAnswer = ReadInt();
            score = CheckAnswer(userAnswer, result, score);
            DisplayScore(score);
            break;
        case 4:
            num1 = random.Next(1, 100);
            num2 = random.Next(1, 100);
            operation = '/';
            result = num2 != 0 ? num1 / num2 : 0; // Avoid division by zero
            DisplayQuestion($"{num1} / {num2}");
            AddToHistory(operation.ToString(), num1, num2, result);
            userAnswer = ReadInt();
            score = CheckAnswer(userAnswer, result, score);
            DisplayScore(score);
            break;
        case 5:
            Console.WriteLine("Game History:");
            foreach (var entry in gameHistory)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(entry);
                Console.WriteLine("-------------------");
            }
            break;
        case 6:
            Console.WriteLine("Thanks for playing!");
            DisplayScore(score);
            return;
    }
}

int ReadInt()
{
    while (true)
    {
        string? line = Console.ReadLine();
        if (line == null)
        {
            Console.WriteLine("No input received. Please enter a valid integer:");
            continue;
        }
        if (int.TryParse(line, out int value))
            return value;
        Console.WriteLine("Invalid input. Please enter a valid integer:");
    }
}

void AddToHistory(string operation, int num1, int num2, int result)
{
    gameHistory.Add($"{num1} {operation} {num2} = {result}");
}





int CheckAnswer(int userAnswer, int correctAnswer, int score)
{
    if (userAnswer == correctAnswer)
    {
        Console.WriteLine("Correct!");
        score += 1;
    }
    else
    {
        Console.WriteLine($"Wrong! The correct answer is {correctAnswer}");
    }
    return score;
}

void DisplayScore(int score)
{
    Console.WriteLine($"Your current score is: {score}");

}

void DisplayQuestion(string question)
{
    Console.WriteLine(question);
    Console.WriteLine("Your answer: ");
}