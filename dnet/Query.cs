namespace dnet
{
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