using System.ComponentModel.DataAnnotations;

namespace example
{
  public class Author
  {
    [Key]
    public string Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }
  }
}

