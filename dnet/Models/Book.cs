using System.ComponentModel.DataAnnotations;

namespace dnet
{
  public class Book
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    public decimal Price { get; set; }
  }
}