using NUnit.Framework;
using System;
using System.Linq;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            var product = new Product("Pesho", 5, 5.5m);
            var store = new StoreManager();

            store.AddProduct(product);

            Assert.AreEqual(1, store.Count);
        }

        [Test]
        public void TestAddNullException()
        {
            var store = new StoreManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                store.AddProduct(null);
            });
        }

        [Test]
        public void TestAddNegativeQuantityException()
        {
            var product = new Product("Pesho", -5, 5.5m);
            var store = new StoreManager();

            Assert.Throws<ArgumentException>(() =>
            {
                store.AddProduct(product);
            });
        }

        [Test]
        public void TestAsReadOnly()
        {
            var product = new Product("Pesho", 5, 5.5m);
            var store = new StoreManager();

            store.AddProduct(product);

            Assert.AreEqual(1, store.Products.Count);
        }

        [Test]
        public void TestBuyProduct()
        {
            var product = new Product("Pesho", 10, 2m);
            var store = new StoreManager();
            store.AddProduct(product);

            store.BuyProduct("Pesho", 2);

            Assert.AreEqual(8, product.Quantity);
        }

     
        [Test]
        public void TestBuyProductNullException()
        {
            var product = new Product("Pesho", 5, 5.5m);
            var store = new StoreManager();

            store.AddProduct(product);

            Assert.Throws<ArgumentNullException>(() =>
            {
                store.BuyProduct("Gosho", 3);
            });
        }

        [Test]
        public void TestBuyProductQuantityException()
        {
            var product = new Product("Pesho", 5, 5.5m);
            var store = new StoreManager();

            store.AddProduct(product);

            Assert.Throws<ArgumentException>(() =>
            {
                store.BuyProduct("Pesho", 30);
            });
        }


        [Test]
        public void TestLastMethod()
        {
            var product = new Product("Pesho", 5, 15.5m);
            var product1 = new Product("Gosho", 5, 5.5m);
           
            var store = new StoreManager();

            store.AddProduct(product);
            store.AddProduct(product1);
         
            var producto = store.Products.OrderByDescending(p => p.Price).First();

            Assert.AreEqual(producto, store.GetTheMostExpensiveProduct());
        }
    }
}