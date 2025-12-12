namespace Game
{
    class Bank(int Balance = default)
    {
        public int Balance { get; private set; } = Balance;
        
        public int AddBalance(int amount)
        {
            Balance += amount;
            return Balance;
        }

        public int ReduceBalance(int amount)
        {
            Balance -= amount;
            return Balance; 
        }
    }
}