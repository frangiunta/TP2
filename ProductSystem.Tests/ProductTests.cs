using System;
using NUnit.Framework;
using ProductSystem;

namespace ProductSystem.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_ValidParameters_CreatesProductSuccessfully()
        {
            // 1. Creación de productos válida
            var product = new Product(1, "Teclado Mecánico", 1500m, "Electrónica");

            Assert.Multiple(() =>
            {
                Assert.That(product.Id, Is.EqualTo(1));
                Assert.That(product.Name, Is.EqualTo("Teclado Mecánico"));
                Assert.That(product.Price, Is.EqualTo(1500m));
                Assert.That(product.Category, Is.EqualTo("Electrónica"));
            });
        }

        [Test]
        public void Constructor_NegativePrice_ThrowsArgumentException()
        {
            // 7. Validación del precio: rechazo de precio negativo
            Assert.Throws<ArgumentException>(() => new Product(2, "Manzana", -50m, "Alimentos"));
        }

        [TestCase("Ropa")]
        [TestCase("Hogar")]
        [TestCase("")]
        [TestCase(null)]
        public void Constructor_InvalidCategory_ThrowsArgumentException(string? invalidCategory)
        {
            // 8. Validación de categoría: solo "Electrónica" y "Alimentos"
            Assert.Throws<ArgumentException>(() => new Product(3, "Item", 100m, invalidCategory!));
        }
    }
}