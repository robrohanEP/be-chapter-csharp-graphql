using System.Linq;
using HotChocolate;
// using ConferencePlanner.GraphQL.Data;

namespace dnet
{
  /// We have a nice and simple model that we can use to build our GraphQL schema. 
  /// We now need to define a query root type. The query root type exposes all the 
  /// possible queries that a user can drill into. A query root type can be defined 
  /// in the same way we defined our models.
  public class Query
  {
    private IAuthorRepository _author;

    public IQueryable<Author> GetAuthors([Service] ApplicationDbContext context) =>
                context.Authors;

    public Author GetAuthorById(
      string id,
      [Service] ApplicationDbContext context) =>
                context.Authors.Find(id);


    public Query(IAuthorRepository author)
    {
      _author = author;
    }

    public Book GetBook() =>
        new Book
        {
          Title = "C# in depth.",
          Author = new Author
          {
            Name = "Jon Skeet"
          }
        };

    public Author GetAuthor() =>
      _author.Find("1");

    // public Author GetAuthorById(string id) =>
    //   _author.Find(id);
  }
}