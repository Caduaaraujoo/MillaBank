

using MillaBank.ContextBank;

class Program
{
    public Program() : base()
    {

    }
    static void Main()
    {
        Menu();
    }


    static void Menu()
    {

        Console.WriteLine("Seja bem vindo(a) ao banco Milla Bank");
        Console.WriteLine("Como podemos te ajudar?");
        Console.WriteLine("1 - Abrir uma conta");
        Console.WriteLine("2 - Consultar Saldo");
        Console.WriteLine("3 - Fazer um deposito");
        Console.WriteLine("4 - Fazer um saque");
        Console.WriteLine("0 - Sair");
        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 0: System.Environment.Exit(0); break;
            case 1: OpenAccount(); break;
            case 2:; break;
            case 3:; break;
            case 4:
                {
                    Console.WriteLine("Digite o numero da sua conta");
                    int numberAccount = int.Parse(Console.ReadLine());
                    break;
                }
        }
    }

    static void OpenAccount()
    {
        Console.WriteLine("Digite seu nome completo");
        string name = Console.ReadLine();
        Console.WriteLine("Qual sua idade?");
        int age = int.Parse(Console.ReadLine());

        if (age < 18)
        {
            Console.WriteLine("Infelizmente você não possui idade para abrir sua conta. Você pode abrir uma conta com a autorização do seu resposável legal, por favor se dirija a unida mais próxima. A MillaBank agradece seu interesse.");
            System.Environment.Exit(0);
        }

        TypeAccount(name, age);

    }

    static void TypeAccount(string name, int age)
    {

        Console.WriteLine($"{name} que tipo de conta gostaria de abrir conosco?");
        Console.WriteLine("1 - Conta Corrente");
        Console.WriteLine("2 - Conta Poupança");
        Console.WriteLine("3 - Voltar para o menu inicial");
        short optionAccount = short.Parse(Console.ReadLine());

        switch (optionAccount)
        {
            case 1: OpenAccountCurrent(name, age); break;
            case 2: OpenAccountSavings(name, age); break;
            case 3: Menu(); break;
        }
    }


    static void OpenAccountCurrent(string name, int age)
    {
        var openAccountCurrent = new CurrentAccount();
        var client = new Client(name, age, openAccountCurrent);
        var newAccountBank = new Bank();
        newAccountBank.Clients.Add(client);
        Console.WriteLine($"Parabéns sua conta Corrente foi aberta com sucesso, um dos beneficios da conta corrente é a disponibilidade de um cartão de crédito, aqui no sistema você tem um valor pré-aprovado, {name} Gostaria de seguir adianta?");
        Console.WriteLine("1 - Aderir o cartão de crédito");
        Console.WriteLine("2 - Deixar para uma próxima oportunidade");
        short optionCredit = short.Parse(Console.ReadLine());

        switch (optionCredit)
        {
            case 1:
                {
                    Console.WriteLine($"Seu limite aprovado é de R${openAccountCurrent.ExtraLimit}, parabéns!");
                    ActionsClientBank(client, newAccountBank);
                    break;
                }
            case 2: ActionsClientBank(client, newAccountBank); break;
        }
    }

    static void OpenAccountSavings(string name, int age)
    {
        var openAccountSaving = new SavingAccount();
        var client = new Client(name, age, openAccountSaving);
        var newAccountBank = new Bank();
        newAccountBank.Clients.Add(client);
        Console.WriteLine($"Parabéns sua conta Poupança foi aberta com sucesso. Seja bem-vindo(a) {name} ao mundo azul e roxo <3");
        ActionsClientBank(client, newAccountBank);
    }

    static void ActionsClientBank(Client client, Bank bank)
    {
        Console.WriteLine("Qual operação desejar realizar?");
        Console.WriteLine("1 - Saque");
        Console.WriteLine("2 - Deposito");
        Console.WriteLine("3 - Voltar ao menu inicial");
        short optionActionsClient = short.Parse(Console.ReadLine());

        switch (optionActionsClient)
        {
            case 1:
                {
                    var response = bank.BelongsBank(client);
                    if (response == true)
                    {
                        Console.WriteLine("Qual valor você desejar sacar?");
                        int value = int.Parse(Console.ReadLine());
                        client.MyAccount.Withdraw(value);
                        Menu();
                    }
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Qual valor do deposito ?");
                    int valueDeposit = int.Parse(Console.ReadLine());
                    client.MyAccount.AccountCredit = valueDeposit;
                    Console.WriteLine($"Parabéns você depositou {valueDeposit}");
                    Console.WriteLine($"Seu saldo atual é de {client.MyAccount.AccountCredit}");
                    Menu();
                    break;
                };
            case 3: Menu(); break;
        }

    }
}