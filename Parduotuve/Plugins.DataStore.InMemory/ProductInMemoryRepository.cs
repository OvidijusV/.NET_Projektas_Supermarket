using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Beer", Quantity = 200, Price = 1.99 },
                new Product { ProductId = 3, CategoryId = 2, Name = "Cookie", Quantity = 150, Price = 2.49 },
                new Product { ProductId = 4, CategoryId = 2, Name = "Bread", Quantity = 100, Price = 2.19 },
                new Product { ProductId = 5, CategoryId = 3, Name = "Chicken", Quantity = 50, Price = 5.79 },
                new Product { ProductId = 6, CategoryId = 3, Name = "Beef", Quantity = 30, Price = 10.00 },


            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
