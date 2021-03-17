using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            var bankValut = new BankVault();

            var item = new Item("dg", "fr");

            bankValut.AddItem("A1", item);

            Assert.AreEqual(12, bankValut.VaultCells.Count);
        }

        [Test]
        public void TestAddExceptionNoCell()
        {
            var bankValut = new BankVault();

            var item = new Item("dg", "fr");

            Assert.Throws<ArgumentException>(() =>
            {
                bankValut.AddItem("A7", item);
            });
        }


        [Test]
        public void TestTakkenCellException()
        {
            var bankValut = new BankVault();

            var item = new Item("dg", "fr");

            bankValut.AddItem("A1", item);
            var item1 = new Item("dtg", "frt");

            Assert.Throws<ArgumentException>(() =>
            {
                bankValut.AddItem("A1", item1);
            });

        }

        [Test]
        public void TestAddException()
        {
            var bankValut = new BankVault();
            var item = new Item("dg", "fr");
            bankValut.AddItem("A1", item);
         //   var item1 = new Item("dgd", "fr");

            Assert.Throws<InvalidOperationException>(() =>
            {
                bankValut.AddItem("A2", item);
            });
        }

        [Test]
        public void TestRemoveWorks()
        {
            var bankValut = new BankVault();
            var item = new Item("dg", "fr");
            bankValut.AddItem("A1", item);
            bankValut.RemoveItem("A1", item);


            Assert.AreEqual(null, bankValut.VaultCells["A1"]);
        }

        [Test]
        public void TestRemoveExceptionExistCell()
        {
            var bankValut = new BankVault();
            var item = new Item("dg", "fr");

            Assert.Throws<ArgumentException>(() =>
            {
                bankValut.RemoveItem("A5", item);
            });
        }

        [Test]
        public void TestRemoveExceptionExistCellItemExist()
        {
            var bankValut = new BankVault();
            var item = new Item("dg", "fr");
            var item1 = new Item("dgf", "frff");
            bankValut.AddItem("A1", item);
           
            Assert.Throws<ArgumentException>(() =>
            {
                bankValut.RemoveItem("A1", item1);
            });
        }
    }
}