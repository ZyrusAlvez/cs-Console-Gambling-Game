using GameMechanics;
using Utils;

namespace Game
{
    static class Program
    {
        static readonly Bank player = new();
        static readonly Bank hoster = new();
        static Roulette? game;

        static void Main()
        {   
            Console.Clear();
            player.AddBalance(Utility.InputNumber("Enter your desired amount: "));
            hoster.AddBalance(Utility.InputNumber("Enter your opponent's amount: "));

            while(true)
            {
                string inputMode;
                do
                {
                    Console.Write("1. Reme\n2. Leme\nEnter Game Mode: ");
                    inputMode = Console.ReadLine() ?? "";
                    Console.Clear();
                }while(inputMode != "1" && inputMode != "2");

                game = new(
                    inputMode == "1" ? GameMode.reme : GameMode.leme,
                    player,
                    hoster
                );

                PrintInfo();
                Console.WriteLine();

                int bet;
                while (true)
                {
                    bet = Utility.InputNumber("Enter your bet: ");
                    if (bet < 0) Console.WriteLine("You can't bet that\n");
                    else if (bet > player.Balance) Console.WriteLine("You don't have enough balance\n");
                    else break;
                }

                // reduce the player's balance and goes to the bet pot
                player.ReduceBalance(bet);
                Console.Clear();

                PrintInfo();
                Console.WriteLine($"Bet: {bet}\n");

                Console.WriteLine("Press any key to spin the Roulette Wheel...");
                Console.ReadKey(true);   // waits for any key
                Console.Clear();

                PrintInfo();
                Console.WriteLine($"Bet: {bet}\n");

                Console.Write("Player spun the wheel and got ");
                int playerScore = Spin();
                Console.WriteLine();
                Console.Write("Hoster spun the wheel and got ");
                int hosterScore = Spin();
                Console.WriteLine("\n");

                // transforming to their equivalent value
                playerScore = Roulette.Value(playerScore);
                hosterScore = Roulette.Value(hosterScore);

                // Battle (compare score)
                int gained = game.Battle(playerScore, hosterScore, bet);
                if (gained > 0)
                {
                    Console.Write("You won ");
                    Utility.PrintColored(gained, ConsoleColor.Green);
                }
                else
                {
                    Utility.PrintColored("You lost your bet", ConsoleColor.Red);
                }

                if (player.Balance > 0 && hoster.Balance > 0)
                {
                    Console.WriteLine("\nPress any key to continue the gambling!");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }
                else
                {
                    if (player.Balance <= 0) Console.WriteLine("\nYou're Bankrupt\nYou lost the gambling!");
                    else if (hoster.Balance <= 0) Console.WriteLine("\nHoster is now Bankrupt BWHAHAHA\nYou won the gambling!");

                    Console.WriteLine("\n\nPress any key to exit");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                }

            }
        }

        static void PrintInfo()
        {
            Console.WriteLine($"Game Mode: {game?.Mode}\n");
            Console.Write("Your Balance: ");
            Utility.PrintColored(player.Balance, ConsoleColor.Green);
            Console.WriteLine();
            Console.Write("Hoster Balance: ");
            Utility.PrintColored(hoster.Balance, ConsoleColor.DarkRed);
            Console.WriteLine();
        }

        // simulating spin
        static int Spin()
        {
            int result = default;
            int random_count = 2;

            for(int i = 0; i < random_count; i++)
            {
                result = Roulette.Spin();
                Thread.Sleep(200);
                
                
                Console.SetCursorPosition(30, Console.CursorTop);
                
                // at the last spin, this won't be triggered
                if (i != random_count - 1)
                {
                    Console.Write(new string(' ', 2));
                    Console.SetCursorPosition(30, Console.CursorTop);
                }
            }
            return result;
        }

    }
}