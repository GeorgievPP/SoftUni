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
            var bank = new BankVault();
            var item = new Item("Pesho", "kk");

            bank.AddItem("C1", item);

            Assert.AreEqual(12, bank.VaultCells.Count);

        }

        [Test]
        public void TestAddItemCellNotWxistException()
        {
            var bank = new BankVault();
            var item = new Item("Pesho", "kk");

            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("p2", item);
            });

        }

        [Test]
        public void TestAddItemTakenCellException()
        {
            var bank = new BankVault();
            var item = new Item("Pesho", "kk");
            var item2 = new Item("Peshoooo", "kggk");

            bank.AddItem("C1", item);

            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("C1", item2);
            });

        }

        [Test]
        public void TestRemoveItem()
        {
            var bank = new BankVault();
            var item = new Item("Pesho", "kk");

            bank.AddItem("C1", item);

            bank.RemoveItem("C1", item);

        }

        [Test]
        public void TestRemoveItemException()
        {
            var bank = new BankVault();
            var item = new Item("Pesho", "kk");
            var item2 = new Item("Pesggho", "krrk");

            bank.AddItem("C1", item);

            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("C1", item2);
            });

        }

        [Test]
        public void TestRemoveItemNotExistCellException()
        {
            var bank = new BankVault();
            var item = new Item("Pesho", "kk");
            var item2 = new Item("Pesggho", "krrk");

            bank.AddItem("C1", item);

            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("P1", item);
            });

        }
    }
}