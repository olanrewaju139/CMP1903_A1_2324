
using DiceGames;

namespace DiceGames;

class Program
{
    static void Main(string[] args)
    {

        var stats = Statistics.InitializeFromSaveFile() ?? new Statistics();

        DisplayMainGameMenu();

        void DisplayMainGameMenu()
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"======= Dice Games =======
Choose an option:
1 - Sevens Out (Single Player)
2 - Sevens Out (Two Player)
3 - Three or More (Single Player)
4 - Three or More Two Player  (Two Player)
5 - View Statistics
6 - Perform Tests
7 - Exit
");
                try
                {
                    Player player1;
                    Player player2;
                    Game game;
                    var input = int.Parse(Console.ReadLine()!);
                    if (input >= 1 & input <= 4)
                    {
                        switch (input)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Enter your name: ");
                                player1 = new HumanPlayer(Console.ReadLine()!);
                                player2 = new ComputerPlayer();
                                game = new SevensOut(player1, player2);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Player 1, enter your name: ");
                                player1 = new HumanPlayer(Console.ReadLine()!);
                                Console.WriteLine("Player 2, enter your name: ");
                                player2 = new HumanPlayer(Console.ReadLine()!);
                                game = new SevensOut(player1, player2);
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Enter your name: ");
                                player1 = new HumanPlayer(Console.ReadLine()!);
                                player2 = new ComputerPlayer();
                                game = new ThreeOrMore(player1, player2);
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Player 1, enter your name: ");
                                player1 = new HumanPlayer(Console.ReadLine()!);
                                Console.WriteLine("Player 2, enter your name: ");
                                player2 = new HumanPlayer(Console.ReadLine()!);
                                game = new ThreeOrMore(player1, player2);
                                break;
                        }
                        game.Run();
                        stats.RecordGame(game);

                        Console.Write("\nPress enter key to return to the main menu");
                        Console.Read();
                    }
                    else if (input >= 5 & input <= 7)
                    {
                        switch (input)
                        {
                            case 5:
                                stats.Display();
                                break;
                            case 6:
                                PerformTests();
                                break;
                            case 7:
                                stats.SaveToFile();
                                Environment.Exit(0);
                                break;
                        }
                        Console.Write("\nPress enter key to return to the main menu");
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again");

                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }


        void PerformTests()
        {
            var testing = new Testing();

            testing.PerformAllTests();
        }
    }
}
