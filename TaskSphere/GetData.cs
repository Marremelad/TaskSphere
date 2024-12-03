using TaskSphere.Data;

namespace TaskSphere;

public static class GetData
{
    public static void DisplayCategories()
    {
        using (var context = new TaskSphereContext())
        {
            var categories = context.Categories
                .Select(s => s)
                .ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"Id: {category.CategoryId}\nName: {category.CategoryName}\nDescription: {category.CategoryDescription}\n");
            }
        }
    }
}