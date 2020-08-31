using System;
using System.Collections.Generic;
using System.Text;
/*this class registers the transaction made on program calling the BankAccount transaction methods
 *each transaction made calls up an object instance of this class
 *each instance called is puted in an collections list on BankAccount class called my "allTransactions"
 */
namespace MyBank
{
    class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get;}
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }




    }
}
