using System.ComponentModel.DataAnnotations;

namespace dnet
{
  public class Book
  {

    [Key]
    public string Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    public Author Author { get; set; }
  }
}