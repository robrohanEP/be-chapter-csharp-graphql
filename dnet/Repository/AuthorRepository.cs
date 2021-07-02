using System;
using System.Collections;
using System.Collections.Generic;

namespace dnet
{
  public class AuthorRepository : IAuthorRepository
  {

    private readonly ApplicationDbContext _db;

    public AuthorRepository(ApplicationDbContext db)
    {
      _db = db;
    }

    public Author Find(string id)
    {
      return null;
    }

    public List<Author> GetAll()
    {
      return null;
    }

    public Author Add(Author author)
    {
      return null;
    }

    public Author Update(Author author)
    {
      return null;
    }

    public void Remove(string id) { }
  }
}