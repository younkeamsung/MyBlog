using BlazorApp2.Client.Models;

namespace BlazorApp2.Client.Interfaces
{
    public interface ICategoryRepository
    {
        // 상세보기
        // Task<Category?> GetCategoryAsync(string id);
        // 수정
        Task SaveCategoryAsync(string name);
        Task<List<Category?>> GetCategorysAsync();
        // 삭제
        Task DeleteCategoryAsync(string id);
    }
}
