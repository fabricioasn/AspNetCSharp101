﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    class BankAccount
    {
        public string Number { get; set; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance = balance + item.Amount;
                }return balance;
            }
                
                
                }
        private static int accNumStart = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string initName, decimal initBalance)
        {
            this.Owner = initName;          
            this.Number = accNumStart.ToString();
            accNumStart++;
        }

        public void makeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The Amount of deposit must be positive!");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void makeWithdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The Amount of deposit must be positive!");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not suficient funds for this withdrawal!");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }




    }
    
}
