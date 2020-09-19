using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;
/*this class registers the transaction made on program calling the BankAccount transaction methods
 *each transaction made calls up an object instance of this class
 *each instance called is puted in an collections list on BankAccount class called my "allTransactions"
 */

namespace BankLibrary
<<<<<<< HEAD
{
    class Transaction
    {
        public decimal Amount { get; }
        public string AmountHumanized
        {
=======
 {
    class Transaction
    {
        public decimal Amount { get;}        
        public string AmountHumanized {
>>>>>>> develop
            //this string atribute returns the amount value in natural human language
            get
            {
                //cast the decimal amount to Int
                int AmountToWords = decimal.ToInt32(Amount);
                return AmountToWords.ToWords();
            }
<<<<<<< HEAD
        }
=======
                }
>>>>>>> develop
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }




    }
<<<<<<< HEAD
}
=======
}
>>>>>>> develop
