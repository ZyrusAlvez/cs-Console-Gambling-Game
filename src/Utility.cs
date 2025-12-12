namespace Utils //namespace and class name shouldn't be the same
{
    static class Utility
    {
        public static int InputNumber(string message)
        {   
            int inputNumber = default;
            bool success = false;
            while (!success)
            {
                Console.Write(message);
                string playerInput = Console.ReadLine() ?? "";
                success = int.TryParse(playerInput, out inputNumber);

                if (!success) PrintColored("Invalid input. Please enter a valid number.\n\n", ConsoleColor.DarkRed);
                if (success && inputNumber <= 0)
                {
                    PrintColored("Invalid input. Please enter a valid amount.\n\n", ConsoleColor.DarkRed);
                    success = false;
                }
            }
            Console.Clear();
            return inputNumber;
        }
        
        public static void PrintColored(object text, ConsoleColor color)
        {
            Console.ForegroundColor = color;   // set text color
            Console.Write($"{text}");               // print
            Console.ResetColor();              // reset to default
        }


    }
}