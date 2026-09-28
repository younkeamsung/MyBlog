using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Client.Models
{
    public class Category
    {
        [Required]
        public string? CategoryId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
