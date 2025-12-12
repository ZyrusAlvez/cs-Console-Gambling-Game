using Game;

namespace GameMechanics
{
    enum GameMode {
        reme,
        leme
    }

    class Roulette(GameMode mode, Bank player, Bank hoster)
    {
        GameMode Mode { get; } =  mode;
        Bank Player { get; } = player;
        Bank Hoster { get; } = hoster;

        private static readonly Dictionary<int, int[]> wheel = new()
        {
            [0] = [0, 19, 28],
            [1] = [1, 10, 29],
            [2] = [2, 11, 20],
            [3] = [3, 12, 21, 30],
            [4] = [4, 13, 22, 31],
            [5] = [5, 14, 23, 32],
            [6] = [6, 15, 24, 33],
            [7] = [7, 16, 25, 34],
            [8] = [8, 17, 26, 35],
            [9] = [9, 18, 27, 36]
        };

        public static int Spin()
        {
            Random rnd = new();
            return rnd.Next(0, 37);
        }

        public static int Value(int score)
        {
            foreach(KeyValuePair<int, int[]> kvp in wheel)
            {
                if (kvp.Value.Contains(score))
                {
                    return kvp.Key;
                }
            }
            return -1;
        }

        public int PlayerWin(int value, int bet)
        {
            int wonAmount;
            if(Mode == GameMode.leme && value == 0)
            {
                wonAmount = bet * 4;
            }
            else if((Mode == GameMode.leme && value == 1) || (Mode == GameMode.reme && value == 0))
            {
                wonAmount = bet * 3;
            }
            else
            {
                wonAmount = bet * 2;
            }
            Console.WriteLine($"You won {wonAmount}!!");
            Hoster.ReduceBalance(wonAmount);
            return Player.AddBalance(wonAmount);
        }

        public int HosterWin(int bet)
        {
            Hoster.AddBalance(bet);
            return Player.ReduceBalance(bet);
        }

        

    }
}