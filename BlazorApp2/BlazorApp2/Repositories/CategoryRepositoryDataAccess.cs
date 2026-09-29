using BlazorApp2.Client.Interfaces;
using BlazorApp2.Client.Models;
using BlazorApp2.Database;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Repositories
{
    public class CategoryRepositoryDataAccess(
    IDbContextFactory<BlogDbContext> factory) : ICategoryRepository
    {
        public async Task DeleteCategoryAsync(string id)
        {
            using var context = factory.CreateDbContext();
            if (int.TryParse(id, out int intid))
            {
                var item = await context.Categorys.FindAsync(intid);
                if (item != null)
                {
                    context.Categorys.Remove(item);
                    await context.SaveChangesAsync();
                }
            }
        }
        
        public async Task<Category?> GetCategoryAsync(string id)
        {
            using var context = factory.CreateDbContext();
            if (int.TryParse(id, out int intid))
            {
                var item = await context.Categorys.FirstOrDefaultAsync
                    (p => p.CategoryId == intid);
                if (item != null)
                {
                    return ConvertCategoryToDto(item);
                }
            }
            return null;
        }
        
        public async Task<List<Category?>> GetCategorysAsync()
        {
            using var context = factory.CreateDbContext();

            return await context.Categorys
                .OrderBy(p => p.CategoryId)
                .Take(5)
                .Select(p => ConvertCategoryToDto(p))
                .ToListAsync();
        }

        public async Task SaveCategoryAsync(string categoryName)
        {
            // 추가
            using var context = factory.CreateDbContext();
            if (await context.Categorys.CountAsync() < 5)
            {
                var newitem = new BlazorApp2.Database.Entities.Category()
                {
                    Name = categoryName
                };
                context.Add(newitem);
                await context.SaveChangesAsync();
            }
        }

        private static Category ConvertCategoryToDto(
        BlazorApp2.Database.Entities.Category item)
        {
            return new Category()
            {
                CategoryId = item.CategoryId.ToString(),
                Name = item.Name
            };
        }
    }
}
