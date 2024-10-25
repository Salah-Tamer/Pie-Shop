namespace PieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryId = 1, CategoryName = "Fruit Pies", Description = "All-Fruity Pies" },
                    new Category {CategoryId = 2, CategoryName = "Cheese Cake", Description = "Cheesy all the way"},
                    new Category {CategoryId = 3, CategoryName = "Seasonal Pie", Description = "Get in the Mood for seasonal pie"}
                };
            }
        }
        
    }
}
