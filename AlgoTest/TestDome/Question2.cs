using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.TestDome
{
    [TestClass]
    public class Tester
    {
        private double epsilon = 1e-6;

        //[Test]
        //public void AccountCannotHaveNegativeOverdraftLimit()
        //{
        //    Account account = new Account(-20);

        //    Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        //}

        //[TestCase(-1)]
        //[TestCase(-2)]
        //[TestCase(-232323)]
        //public void Deposit_NegativeNumberPassed_NotAllowed(int negativeDepositValue) {
        //    Account account = new Account(-20);

        //    Assert.IsFalse(account.Deposit(negativeDepositValue));
        //}

        //[TestCase(-1)]
        //[TestCase(-2)]
        //[TestCase(-232323)]
        //public void Withdraw_NegativeNumberPassed_NotAllowed(int negativeDepositValue)
        //{
        //    Account account = new Account(-20);

        //    Assert.IsFalse(account.Withdraw(negativeDepositValue));
        //}


        [TestMethod]
        //[TestCase(2)]
        //[TestCase(232323)]
        public void Deposit_ValidValue_Success()
        {
            Account account = new Account(20);

            Assert.IsTrue(account.Deposit(1));
            Assert.AreEqual(1, account.Balance);
        }
        [TestMethod]
        public void Withdraw_ValidValue_Success()
        {
            Account account = new Account(20);

            Assert.IsTrue(account.Deposit(2));
            Assert.IsTrue(account.Withdraw(1));
            Assert.AreEqual(1, account.Balance);
        }

        [TestMethod]
        public void Account_ValidValue_Success()
        {
            Account account = new Account(0);

            Assert.IsTrue(account.Deposit(4));
            Assert.IsFalse(account.Withdraw(5));
        }
    }

    class Account {
        public double Balance{ get; set; }
        public double OverdraftLimit{ get; set; }

        public Account(double overdraftLimit)
        {
            this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
            this.Balance = 0;
        }

        public bool Deposit(double amount) {
            if (amount >= 0) {

                this.Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(double amount) {
            if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0) {

                this.Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
