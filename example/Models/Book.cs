using System.ComponentModel.DataAnnotations;

namespace example
{
  public class Book
  {
    [Key]
    public string Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    public decimal Price { get; set; }
  }
}