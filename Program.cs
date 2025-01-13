public class CometDodger
{
    public static void Main(string[] args)
    {
        int cometSpeed = 15;

        if (args.Length > 0)
        {
            string? difficulty = args[0]?.ToLower();
            switch (difficulty)
            {
                case "easy":
                    cometSpeed = 25;
                    break;
                case "medium":
                    cometSpeed = 15;
                    break;
                case "hard":
                    cometSpeed = 7;
                    break;
                default:
                    Console.WriteLine("Invalid difficulty, using default medium");
                    break;
            }
        }
        Console.WriteLine($"Starting with difficulty {cometSpeed} ms comet speed");
        Thread.Sleep(1000);


        bool playAgain = true;
        int highScore = 0;

        while (playAgain)
        {
            string comet = "o";
            string planet = "O";

            int planetPos = 2;
            Random random = new Random();


            Console.CursorVisible = false;
            int currentScore = 0;


            while (true)
            {
                int cometLine = random.Next(3);
                int cometPos = 0;
                bool collision = false;

                while (cometPos <= 35)
                {
                    Console.Clear();

                    // Move planet
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.UpArrow && planetPos > 0) planetPos--;
                        if (key == ConsoleKey.W && planetPos > 0) planetPos--;
                        if (key == ConsoleKey.DownArrow && planetPos < 3) planetPos++;
                        if (key == ConsoleKey.S && planetPos < 3) planetPos++;
                    }

                    // Draw comet
                    Console.SetCursorPosition(cometPos, cometLine);
                    Console.Write(comet);
                    // Draw planet
                    Console.SetCursorPosition(25, planetPos);
                    Console.Write(planet);

                    // Collision check
                    if (cometPos == 25 && planetPos == cometLine)
                    {
                        collision = true;
                        break;
                    }

                    currentScore++;

                    Thread.Sleep(cometSpeed);
                    cometPos++;
                }

                if (collision)
                {
                    //animation explo
                    for (int i = 1; i <= 5; i++)
                    {
                        if (currentScore > highScore)
                        {
                            highScore = currentScore;
                        }

                        //Expanding explo
                        Console.SetCursorPosition(25 - i, planetPos);
                        Console.WriteLine(new string('*', i * 2 + planet.Length));

                        Thread.Sleep(200);
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(@"                     Game Over");
                    Console.WriteLine(@"                     Play agian?");
                    Console.WriteLine(@"                     Press 1 or 2");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(@$"                     Current score: {currentScore}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(@$"                     High score: {highScore}");
                    Console.ResetColor();

                    string? userChoice = Console.ReadLine();
                    if (userChoice == "1" || userChoice?.ToLower() == "yes")
                    {
                        playAgain = true;
                        break;
                    }
                    else if (userChoice == "2" || userChoice?.ToLower() == "no")
                    {
                        playAgain = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Press 1 or 2");
                    }
                }
            }
        }
    }
}