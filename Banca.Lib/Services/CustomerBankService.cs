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
                return GetBankAccountDetails(Number);
            string s = "Pin Errato";
            return s;           
        }

        public decimal CheckMyAmount(string Pin, int Number)
        {
            throw new NotImplementedException();
        }

        public string DepositIntoMyAccount(string Pin, int Number, decimal Money)
        {
            throw new NotImplementedException();
        }

        public string WithdrawFromMyAccount(string Pin, int Number, decimal Money)
        {
            throw new NotImplementedException();
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
