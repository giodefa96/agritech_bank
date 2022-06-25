using Banca.Lib.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Services
{
    public class CustomerBankService : ICustomerBank
    {
        private Bank bank;
        public CustomerBankService()
        {
            bank = new Bank();
        }

        public CustomerBankService(Bank bank)
        {
            this.bank = bank;
        }

        
        public string BankStatement(string pin, int Number)
        {
            BankAccount account = GetBankAccountByNumber(Number);
            string pinToCheck = account.Pin;
            if (pinToCheck == pin)
            {
                for(int i = 0; i < account.Transactions.Count; i ++)
                {
                    // Bisognerebbe creare lo script che ogni volta che si fa una transazione
                    // aggiunge la log della stessa... comunque è un to do che farò
                    Console.WriteLine($"{account.Transactions[i].Date}");
                    Console.WriteLine($"{account.Transactions[i].Amount}");
                }
                return null;
            }
            string s = "Pin Errato";
            return s;           
        }

        public string CheckMyAmount(string Pin, int Number)
        {
            BankAccount account = GetBankAccountByNumber(Number);
            string pinToCheck = account.Pin;
            if (pinToCheck == Pin)
                return GetBankAccountDetails(Number);
            string s = "Pin Errato";
            return s;
        }

        public string DepositIntoMyAccount(string Pin, int Number, decimal Money)
        {
            BankAccount account = GetBankAccountByNumber(Number);
            string pinToCheck = account.Pin;
            if (pinToCheck == Pin)
            {
                account.AddMoney(Money);
                Console.WriteLine($"{Money} sono stati aggiunti al tuo conto");
                return BankStatement(Pin, Number);
            }
            string s = "Pin Errato";
            return s;


        }

        public string WithdrawFromMyAccount(string Pin, int Number, decimal Money)
        {
            BankAccount account = GetBankAccountByNumber(Number);
            string pinToCheck = account.Pin;
            if (pinToCheck == Pin)
            {
                account.TakeMoney(Money);
                if(account.Amount < 0)
                {
                    account.AddMoney(Money);
                    string stampa_messaggio = $"{Money}€  non sono stati ritirati perchè sei povero!";
                    return stampa_messaggio;
                }
                Console.WriteLine($"{Money}€ sono stati ritirati dal tuo conto");
                return BankStatement(Pin, Number);
            }
            string s = "Pin Errato";
            return s;
        }

        public BankAccount GetBankAccountByNumber(int number)
        {
            foreach (var ba in bank.BankAccounts)
                if (ba.Number == number)
                    return ba;
            return null;
        }

        public string GetBankAccountDetails(int number)
        {
            //TODO RIVEDERE (String immutabili)
            var bankAccount = GetBankAccountByNumber(number);
            if (bankAccount == null)
                return $"Conto '{number}' non trovato";
            //else sottinteso
            string s = "";
            s = s + $"Numero Conto:{bankAccount.Number}\n";
            s = s + $"Saldo: {bankAccount.Amount}\n";
            s += $"Iban: {bankAccount.Iban}\n";
            s += $"Stato: {bankAccount.Status}\n";

            s += "-------------------\n";

            s += $"Cliente: {bankAccount.Customer.FirstName} {bankAccount.Customer.LastName} ({bankAccount.Customer.Email})\n";

            s += "-------------------\n";
            s += "Operazioni\n";
            foreach (var t in bankAccount.Transactions)
            {
                s += $"{t.Id}\t{t.Amount}\t{t.Date}\t{t.Description}";
            }

            return s;

        }
    }
}
