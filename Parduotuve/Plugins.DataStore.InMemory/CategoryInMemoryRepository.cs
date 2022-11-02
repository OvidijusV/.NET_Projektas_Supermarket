using CoreBusiness;
using System;
using UseCases.DataStorePluginInterfaces;
using System.Collections.Generic;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;
        public CategoryInMemoryRepository()
        {
            // Default data
            categories = new List<Category>()
            {
                new Category {CategoryID = 1, Name = "Beverage", Description = "Beverage"},
                new Category {CategoryID = 2, Name = "Bakery", Description = "Bakery"},
                new Category {CategoryID = 3, Name = "Meat", Description = "Meat"},
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            var maxId = categories.Max(x => x.CategoryID);
            category.CategoryID = maxId + 1;

            categories.Add(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }
    }
}