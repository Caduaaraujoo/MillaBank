namespace MillaBank.ContextBank
{
    class CurrentAccount : Account
    {
        public CurrentAccount() : base()
        {
        }

        private int creditApproved = new Random().Next(100, 1000);

        public int ExtraLimit
        {
            get => creditApproved;
            set
            {
                creditApproved = value;
            }
        }

        public override void Withdraw(int value)
        {
            base.AccountCredit = -value;
            Console.WriteLine($"Você sacou {value}, seu saldo agora é de R$ {base.AccountCredit}");
        }
    }
}