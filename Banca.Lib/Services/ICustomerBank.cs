using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Services
{
    public interface ICustomerBank
    {
        /// <summary>
        /// Verifica saldo sul proprio conto c
        /// </summary>
        /// <param name="Pin"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        string CheckMyAmount(string Pin, int Number);

        /// <summary>
        /// Prelievo x dal conto c
        /// </summary>
        /// <param name="Pin"></param>
        /// <param name="Number"></param>
        /// <param name="Money"></param>
        /// <returns></returns>
        string WithdrawFromMyAccount(string Pin, int Number, decimal Money);

        /// <summary>
        /// Versamento x sul conto c
        /// </summary>
        /// <param name="Pin"></param>
        /// <param name="Number"></param>
        /// <param name="Money"></param>
        /// <returns></returns>
        string DepositIntoMyAccount(string Pin, int Number, decimal Money);

        /// <summary>
        /// Estratto conto del conto c (range date)
        /// </summary>
        /// <param name="Pin"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        string BankStatement(string Pin, int Number);
    }
}




