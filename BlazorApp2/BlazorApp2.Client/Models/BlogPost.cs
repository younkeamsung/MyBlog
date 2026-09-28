using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Client.Models;

public class BlogPost
{
    // 블로그 id
    public string? Id { get; set; }
    // 블로그 제목
    [Required]
    [MinLength(5)]
    public string Title { get; set; } = string.Empty;   // string은 null값이못들어가는데 이러면 null일때 빈값이 들어감
    // 블로그 글 내용
    [Required]
    public string Text { get; set; } = string.Empty;
    // 블로그 발행일
    public DateTime PublishDate { get; set; }

    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public Category Category { get; set; }
}
