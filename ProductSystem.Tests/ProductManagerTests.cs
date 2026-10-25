using System;
using NUnit.Framework;
using ProductSystem;

namespace ProductSystem.Tests
{
    [TestFixture]
    public class ProductManagerTests
    {
        private ProductManager _manager = null!;

        [SetUp]
        public void SetUp()
        {
            _manager = new ProductManager();
        }

        [Test]
        public void AddProduct_ValidProduct_AddsToList()
        {
            // 2. Incorporación de productos a la lista interna
            var product = new Product(10, "Monitor", 25000m, "Electrónica");

            _manager.AddProduct(product);

            Assert.That(_manager.Products, Does.Contain(product));
            Assert.That(_manager.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public void FindProductByName_ExistingProducts_ReturnsCorrectProduct()
        {
            // 3. Búsqueda de productos agregados
            var prod1 = new Product(1, "Notebook", 80000m, "Electrónica");
            var prod2 = new Product(2, "Arroz", 1200m, "Alimentos");
            var prod3 = new Product(3, "Auriculares", 9500m, "Electrónica");

            _manager.AddProduct(prod1);
            _manager.AddProduct(prod2);
            _manager.AddProduct(prod3);

            var found1 = _manager.FindProductByName("Notebook");
            var found2 = _manager.FindProductByName("Arroz");

            Assert.Multiple(() =>
            {
                Assert.That(found1, Is.Not.Null);
                Assert.That(found1!.Id, Is.EqualTo(1));
                Assert.That(found2, Is.Not.Null);
                Assert.That(found2!.Id, Is.EqualTo(2));
            });
        }

        [Test]
        public void FindProductByName_NonExistingProduct_ReturnsNull()
        {
            // 4. Búsqueda de producto inexistente
            var prod = new Product(1, "Fideos", 800m, "Alimentos");
            _manager.AddProduct(prod);

            var result = _manager.FindProductByName("Leche");

            Assert.That(result, Is.Null);
        }

        [TestCase(1000, 1100)]
        [TestCase(500, 550)]
        [TestCase(0, 0)]
        public void CalculateTotalPrice_ElectronicCategory_AppliesTenPercentTax(decimal basePrice, decimal expectedTotal)
        {
            // 5. Cálculo para Electrónica (10 %)
            var product = new Product(1, "Mouse", basePrice, "Electrónica");

            var total = _manager.CalculateTotalPrice(product);

            Assert.That(total, Is.EqualTo(expectedTotal));
        }

        [TestCase(1000, 1050)]
        [TestCase(200, 210)]
        [TestCase(0, 0)]
        public void CalculateTotalPrice_FoodCategory_AppliesFivePercentTax(decimal basePrice, decimal expectedTotal)
        {
            // 6. Cálculo para Alimentos (5 %)
            var product = new Product(2, "Pan", basePrice, "Alimentos");

            var total = _manager.CalculateTotalPrice(product);

            Assert.That(total, Is.EqualTo(expectedTotal));
        }
    }
}