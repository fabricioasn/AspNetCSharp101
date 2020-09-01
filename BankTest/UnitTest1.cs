using System;
using Xunit;
using BankLibrary;

namespace BankTest
{
    public class BankTests
    {
        [Fact]
        public void TestAssertsTrueIsTrue()
        {
            Assert.True(true);

        }
        [Fact]
        public void TestsCatchMoreThanBalance()
        {
            //test for negative balance;
            var account = new BankAccount("Alice", 1000);
            //test for amount value greater than balance
            Assert.Throws<InvalidOperationException>(
                () => account.makeWithdrawl(60000, DateTime.Now, "Attempt to Overdraw")
                );
        }
        [Fact]
        public void TestsSubmitNegativValue()
        {
            //test that asserts that the initial balance must be positive

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BankAccount("invalid", -100)
                );                      

        }


    }
}
