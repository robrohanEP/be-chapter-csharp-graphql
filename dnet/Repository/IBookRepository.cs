using System;
using System.Collections;
using System.Collections.Generic;

namespace dnet
{
  public interface IBookRepository
  {
    Book Find(string id);

    List<Book> GetAll();

    Book Add(Book book);

    Book Update(Book book);

    void Remove(string id);
  }

}