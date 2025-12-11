namespace Game
{
    class Bank(int Balance = default)
    {
        public int Balance { get; private set; } = Balance;
        
        public bool AddBalance(int amount)
        {
            if(amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public bool ReduceBalance(int amount)
        {
            if(amount > 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}