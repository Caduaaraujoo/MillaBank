namespace MillaBank.ContextBank
{
    public abstract class Account
    {
        Random numberRandom = new Random();
        protected Account()
        {
            Agency = "001";
            AccountNumber = 2020;
            AccountCredit = 0;
        }

        private int deposit;
        public string Agency { get; private set; }
        public int AccountNumber { get; private set; }
        public int AccountCredit
        {
            get => deposit;
            set
            {
                deposit += value;
            }
        }

        public virtual void Withdraw(int value)
        {

        }
    }
}