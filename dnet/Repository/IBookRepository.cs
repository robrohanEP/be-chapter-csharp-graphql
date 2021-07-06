using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dnet
{
  public interface IBookRepository
  {
    Book Find(string id);

    Microsoft.EntityFrameworkCore.DbSet<Book> GetAll();

    Book Add(Book book);

    Book Update(Book book);

    void Remove(string id);
  }

}