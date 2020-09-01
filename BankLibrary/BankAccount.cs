using System;
using System.Collections.Generic;
using System.Text;
/*This class is the model of the bank account in the program
 *every bank account created is an instance of this
 *the concrete methods are deposit, withdrawal, and account history of transactions made
 *each modify methods is referenced by the transaction class, wich instance is added in a collection list
 */
namespace BankLibrary
{
    class BankAccount
    {
        public string Number { get; set; }
        public string Owner { get; set; }
        public decimal Balance
        {
            //inputs on balance the amount of each transaction
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    /*for each transaction item submited by the user, the balance will be negatively 
                     * or positively increase the amount in transaction*/
                    balance = balance + item.Amount;
                }
                return balance;
            }
            set { }
        }
        private static int accNumStart = 1234567890;

        //list of all account transactions of the Transaction.Class type, modifying the balance atribute
        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string initName, decimal initBalance)
        {
            this.Owner = initName;
            this.Number = accNumStart.ToString();
            accNumStart++;
            this.Balance = initBalance;
        }

        public void makeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The Amount of deposit must be positive!");
            }
            /*the var deposit recives value of a transaction submited 
             * with amount that will be added to the balance*/
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void makeWithdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The Amount of deposit must be positive!");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not suficient funds for this withdrawal!");
            }
            /*the var deposit recives value of a transaction submited 
            * with amount that will be negatively added(or subtracted) to the balance*/
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        //function wich returns the accont all transactions history reported
        public string GetAccHistory()
        {
            //transactions report header
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                //report rows
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.AmountHumanized}\t{item.Notes}");
            }
            return report.ToString();
        }


    }

}