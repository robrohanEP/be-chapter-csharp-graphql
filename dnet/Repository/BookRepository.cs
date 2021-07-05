using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dnet
{
  public class BookRepository : IBookRepository
  {

    private readonly ApplicationDbContext _db;

    public BookRepository(ApplicationDbContext db)
    {
      _db = db;
    }

    public Book Find(string id)
    {
      var a = _db.Find<Book>(id);
      return a;
    }

    public List<Book> GetAll()
    {
      return null;
    }

    public Book Add(Book book)
    {
      return null;
    }

    public Book Update(Book book)
    {
      return null;
    }

    public void Remove(string id) { }
  }
}