using System;

namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //abstract Account builder for test
            var abstractAccount = new BankAccount("John",10000);
            Console.WriteLine($"Account {abstractAccount.Number} was created for {abstractAccount.Owner} with {abstractAccount.Balance}.");
            
            //test to verify withdrawal above current balance
            try
            {
                //test to verify transactions with negative values
                try
                {
                    Boolean test=true;
                    do
                    {
                        Console.WriteLine("Type a Number for the operation do you want to choose:");
                        Console.WriteLine($"\t1 - Make Deposit \t\t2 - Make Withdrawal\t");
                        var operation = Console.ReadLine();
                        if (operation == "1")
                        {
                            Console.WriteLine("Type a non negative numeric value: ");
                            var deposit = Console.Read();
                            abstractAccount.makeDeposit(deposit, DateTime.Now, "NewDeposit");
                            Console.WriteLine($"New deposit confirmed with {deposit} value!");

                        }
                        else if (operation == "2")
                        {
                            Console.WriteLine("Type a non negative numeric value lesser than your acc balance: ");
                            var withdrawal = Console.Read();
                            abstractAccount.makeWithdrawl(withdrawal, DateTime.Now, "NewWithdrawal");
                            Console.WriteLine($"New withdrawal confirmed with {withdrawal} value!");
                        }
                        else
                        {
                            Console.WriteLine(abstractAccount.GetAccHistory());
                            
                        }
                        Console.WriteLine($"Current Balance is: {abstractAccount.Balance}");

                        Console.WriteLine("Do you wish to proced with another operation?Type 'Y' for yes:");
                        var proceeds = Console.ReadLine();                        
                        if (proceeds == "Y")
                        {
                            test = true;
                        }
                        else
                        {
                            test = false;
                        }
                    } while (test==true);                                                     

                }
                catch(ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance.");
                    Console.WriteLine(e.ToString());
                }


            }catch(InvalidOperationException e)
            {
                Console.WriteLine("Except caught trying to overdraw balance.");
                Console.WriteLine(e.ToString());
            }
            finally
            {
                //account balance
                Console.WriteLine(abstractAccount.Balance);
                //shows the account history reports
                Console.WriteLine(abstractAccount.GetAccHistory());
                Environment.Exit(0);
            }




        }
    }
}
