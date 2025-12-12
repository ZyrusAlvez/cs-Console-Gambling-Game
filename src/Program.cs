using GameMechanics;
using Utils;

namespace Game
{
    static class Program
    {
        static void Main()
        {   
            Console.Clear();

            Bank player = new();
            Bank hoster = new();

            player.AddBalance(Utility.InputNumber("Enter your desired amount: "));
            hoster.AddBalance(Utility.InputNumber("Enter your opponent's amount: "));

            while(player.Balance > 0 && hoster.Balance > 0)
            {
                string inputMode;
                do
                {
                    Console.Write("1. Reme\n2. Leme\nEnter Game Mode: ");
                    inputMode = Console.ReadLine() ?? "";
                    Console.Clear();
                }while(inputMode != "1" && inputMode != "2");

                Roulette game = new(
                    inputMode == "1" ? GameMode.reme : GameMode.leme,
                    player,
                    hoster
                );

                int bet = Utility.InputNumber("Enter your bet: ");
            }
            
        }

    }
}