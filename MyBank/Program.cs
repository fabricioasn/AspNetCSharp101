using System;
//Standart complete bank system with the main/average operation options

namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //enters the acc owner's name to the Acc constructor
            Console.WriteLine("What's your Name? ");
            string name = Console.ReadLine();

            //abstract Account builder for test
            var abstractAccount = new BankAccount(name, 10000);
            Console.WriteLine($"Account {abstractAccount.Number} was created for {abstractAccount.Owner} with {abstractAccount.Balance}.");
            Boolean test = true;

            //test to verify withdrawal above current balance
            try
            {
                //test to verify transactions with negative values
                try
                {


                    do
                    {
                        Console.WriteLine("Type a Number for the operation do you want to choose:");
                        Console.WriteLine($"\t1 - Make Deposit \t\t2 - Make Withdrawal\t" +
                            $"\t 3 - Acc History \t Other - Exit ");
                        var operation = Console.ReadLine();
                        if (operation == "1")
                        {
                            Console.WriteLine("Type a non negative numeric value: ");
                            decimal deposit = decimal.Parse(Console.ReadLine());
                            abstractAccount.makeDeposit(deposit, DateTime.Now, "NewDeposit");
                            Console.WriteLine($"New deposit confirmed with {deposit} value!");

                        }
                        else if (operation == "2")
                        {
                            Console.WriteLine("Type a non negative numeric value lesser than your acc balance: ");
                            decimal withdrawal = decimal.Parse(Console.ReadLine());
                            abstractAccount.makeWithdrawl(withdrawal, DateTime.Now, "NewWithdrawal");
                            Console.WriteLine($"New withdrawal confirmed with {withdrawal} value!");
                        }
                        else if (operation == "3")
                        {
                            Console.WriteLine(abstractAccount.GetAccHistory());

                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        Console.WriteLine($"Current Balance is: {abstractAccount.Balance}");

                        Console.WriteLine("Do you wish to proced with another operation?Type 'Y' for yes:");
                        var proceeds = Console.ReadLine();
                        if (proceeds == "y")
                        {
                            test = true;
                        }
                        else
                        {
                            test = false;
                        }
                    } while (test == true);

                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance.");
                    Console.WriteLine(e.ToString());
                }


            }
            catch (InvalidOperationException e)
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