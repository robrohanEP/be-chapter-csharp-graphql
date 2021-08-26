using System.Threading.Tasks;
using HotChocolate;

namespace example
{
  /// For mutations we are using the "relay mutation pattern" which is
  // /// commonly used in GraphQL.
  // public class AddAuthorPayload
  // {
  //   public AddAuthorPayload(Author author)
  //   {
  //     Author = author;
  //   }
  //   public Author Author { get; }
  // }

  ///
  public class Mutation
  {
    public async Task<Author> AddAuthor(
        Author input,
        [Service] ApplicationDbContext context)
    {
      var author = new Author
      {
        Id = input.Id,
        Name = input.Name
      };

      context.Authors.Add(author);
      await context.SaveChangesAsync();

      return author; // new AddAuthorPayload(author);
    }
  }
}