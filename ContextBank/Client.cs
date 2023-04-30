namespace MillaBank.ContextBank
{
    public class Client : Person
    {
        public Client(string name, int age, Account myAccount) : base(name, age)
        {
            MyAccount = myAccount;
        }

        public Account MyAccount { get; set; }

    }
}