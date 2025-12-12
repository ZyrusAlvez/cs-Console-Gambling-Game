using Game;
using Utils;

namespace GameMechanics
{
    enum GameMode {
        reme,
        leme
    }

    class Roulette(GameMode mode, Bank player, Bank hoster)
    {
        public GameMode Mode { get; } =  mode;
        Bank Player { get; } = player;
        Bank Hoster { get; } = hoster;

        private static readonly Dictionary<int, int[]> wheel = new()
        {
            [1] = [1, 10, 29],
            [2] = [2, 11, 20],
            [3] = [3, 12, 21, 30],
            [4] = [4, 13, 22, 31],
            [5] = [5, 14, 23, 32],
            [6] = [6, 15, 24, 33],
            [7] = [7, 16, 25, 34],
            [8] = [8, 17, 26, 35],
            [9] = [9, 18, 27, 36],
            [10] = [0, 19, 28],
        };

        private static readonly Dictionary<ConsoleColor, int[]> color = new()
        {
            [ConsoleColor.Green] = [0],
            [ConsoleColor.DarkRed] = [1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36]
        };

        public static int Spin()
        {
            Random rnd = new();
            int result = rnd.Next(0, 37);

            foreach(KeyValuePair <ConsoleColor, int[]> item in color)
            {
                if (item.Value.Contains(result))
                {
                    Utility.PrintColored(result, item.Key);
                    return result;
                }
            }
            Console.Write(result);
            return result;  
        }

        public static int Value(int score)
        {
            foreach(KeyValuePair<int, int[]> item in wheel)
            {
                if (item.Value.Contains(score))
                {
                    return item.Key;
                }
            }
            return -1;
        }

        public int PlayerWin(int bet, int value)
        {
            int wonAmount;
            if(Mode == GameMode.leme && value == 10)
            {
                wonAmount = bet * 4;
            }
            else if((Mode == GameMode.leme && value == 1) || (Mode == GameMode.reme && value == 10))
            {
                wonAmount = bet * 3;
            }
            else
            {
                wonAmount = bet * 2;
            }
            Hoster.ReduceBalance(wonAmount - bet);
            Player.AddBalance(wonAmount);
            return wonAmount;
        }

        public int HosterWin(int bet)
        {
            Hoster.AddBalance(bet);
            return bet;
        }

        

    }
}