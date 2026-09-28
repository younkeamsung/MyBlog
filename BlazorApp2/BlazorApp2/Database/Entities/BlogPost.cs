using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp2.Database.Entities;

public class BlogPost
{
    // 블로그 id
    // SQLserver는 Id라고 이름을 적어놓으면 자동적으로 프라이머키가 된다
    // 자동증가 컬럼으로 컬럼에 직접 값을 집어넣지않아도 생성될때마다 1씩 ++해서 생성됨
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    // 블로그 제목
    public string Title { get; set; } = string.Empty;   // string은 null값이못들어가는데 이러면 null일때 빈값이 들어감
    // 블로그 카테고리
    public int? CategoryId { get; set; }
    // 블로그 글 내용
    public string Text { get; set; } = string.Empty;
    // 블로그 발행일
    public DateTime PublishDate { get; set; }

    // [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
}
