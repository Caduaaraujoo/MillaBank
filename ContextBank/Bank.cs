namespace MillaBank.ContextBank
{
    public class Bank
    {
        public Bank()
        {
            Clients = new List<Client>();
            AgencyBank = "001";
        }
        public IList<Client> Clients { get; private set; }

        public string AgencyBank { get; set; }

        public bool BelongsBank(Client client)
        {
            if (client.MyAccount.Agency == AgencyBank)
            {
                var response = Clients.Any(clientList => clientList.MyAccount.AccountNumber == client.MyAccount.AccountNumber);
                if (response == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

                return false;
            }

        }
    }
}