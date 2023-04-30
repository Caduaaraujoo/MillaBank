namespace MillaBank.ContextBank
{
    class SavingAccount : Account
    {
        public SavingAccount() : base()
        {
        }

        public override void Withdraw(int value)
        {
            if (base.AccountCredit < value)
            {
                Console.WriteLine("Não é possivel realizar o saque");
            }
            else
            {
                base.AccountCredit = -value;
                Console.WriteLine($"Você sacou {value}, seu saldo agora é de R$ {base.AccountCredit}");
            }

        }
    }
}