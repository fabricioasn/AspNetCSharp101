using System;
using System.Collections.Generic;
using System.Text;

namespace BankLib
{
    class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }




    }

    public class BankAccount
    {
        private string v1;
        private int v2;

        public BankAccount(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
