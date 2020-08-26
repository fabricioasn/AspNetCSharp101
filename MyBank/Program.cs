using System;

namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var abstractAccount = new BankAccount("John",1000);
            Console.WriteLine($"Account {abstractAccount.Number} was created for {abstractAccount.Owner} with {abstractAccount.Balance}.");


        }
    }
}
