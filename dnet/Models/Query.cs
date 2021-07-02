namespace dnet
{
  /// We have a nice and simple model that we can use to build our GraphQL schema. 
  /// We now need to define a query root type. The query root type exposes all the 
  /// possible queries that a user can drill into. A query root type can be defined 
  /// in the same way we defined our models.
  public class Query
  {
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
      new Author
      {
        Name = "Rob"
      };
  }
}