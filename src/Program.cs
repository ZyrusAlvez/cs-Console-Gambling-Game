namespace Game
{
    class Progam
    {
        static void Main()
        {   
            Console.Clear();

            Bank player = new();
            Bank hoster = new();

            player.AddBalance(InputNumber("Enter your desired amount: "));
            hoster.AddBalance(InputNumber("Enter your opponent's amount: "));
    
        }

        static int InputNumber(string message)
        {   
            int inputNumber = default;
            bool success = false;
            while (!success)
            {
                Console.Write(message);
                string playerInput = Console.ReadLine() ?? "";
                success = int.TryParse(playerInput, out inputNumber);

                if (!success) Console.WriteLine("Invalid input. Please enter a valid number.");
                if (success && inputNumber <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid amount.");
                    success = false;
                }

                Console.Clear();
            }
            return inputNumber;
        }
    }
}