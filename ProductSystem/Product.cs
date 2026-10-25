using System;
using System.Collections.Generic;

namespace ProductSystem
{
    public class Product
    {
        private static readonly HashSet<string> AllowedCategories = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Electrónica",
            "Alimentos"
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, decimal price, string category)
        {
            if (price < 0)
            {
                throw new ArgumentException("El precio base no puede ser negativo.", nameof(price));
            }

            if (string.IsNullOrWhiteSpace(category) || !AllowedCategories.Contains(category))
            {
                throw new ArgumentException($"Categoría inválida. Solo se admiten: {string.Join(", ", AllowedCategories)}.", nameof(category));
            }

            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }
    }
}