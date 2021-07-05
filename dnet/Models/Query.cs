using System.Linq;
using HotChocolate;
using HotChocolate.Types;
// using ConferencePlanner.GraphQL.Data;

namespace dnet
{
  /// We have a nice and simple model that we can use to build our GraphQL schema. 
  /// We now need to define a query root type. The query root type exposes all the 
  /// possible queries that a user can drill into. A query root type can be defined 
  /// in the same way we defined our models.
  public class Query
  {
    private readonly IAuthorRepository _author;
    private readonly IBookRepository _book;

    public IQueryable<Author> GetAuthors([Service] ApplicationDbContext context) =>
                context.Authors;

    public Author GetAuthorById(
      string id,
      [Service] ApplicationDbContext context) =>
                context.Authors.Find(id);


    public Query(IAuthorRepository author, IBookRepository book)
    {
      _author = author;
      _book = book;
    }

    public IQueryable<Book> Books => (IQueryable<Book>)_book.GetAll();

    public Book GetBook() =>
      _book.Find("1");

    // public Book GetBook() =>
    //     new Book
    //     {
    //       Title = "C# in depth.",
    //       Author = new Author
    //       {
    //         Name = "Jon Skeet"
    //       }
    //     };

    public Author GetAuthor() =>
      _author.Find("1");

    // public Author GetAuthorById(string id) =>
    //   _author.Find(id);
  }
}