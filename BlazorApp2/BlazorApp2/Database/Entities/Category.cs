using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp2.Database.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>(); 
    }
}
