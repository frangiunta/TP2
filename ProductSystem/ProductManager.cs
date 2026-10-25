using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSystem
{
    public class ProductManager
    {
        private readonly List<Product> _products = new List<Product>();

        // Propiedad de sólo lectura para inspeccionar la colección en las pruebas
        public IReadOnlyList<Product> Products => _products.AsReadOnly();

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "El producto no puede ser nulo.");
            }

            if (product.Price < 0)
            {
                throw new ArgumentException("El producto tiene un precio negativo.");
            }

            _products.Add(product);
        }

        public decimal CalculateTotalPrice(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            decimal taxRate = 0m;

            if (product.Category.Equals("Electrónica", StringComparison.OrdinalIgnoreCase))
            {
                taxRate = 0.10m;
            }
            else if (product.Category.Equals("Alimentos", StringComparison.OrdinalIgnoreCase))
            {
                taxRate = 0.05m;
            }
            else
            {
                throw new InvalidOperationException("Categoría no admitida para el cálculo de impuestos.");
            }

            return product.Price + (product.Price * taxRate);
        }

        public Product? FindProductByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            return _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}