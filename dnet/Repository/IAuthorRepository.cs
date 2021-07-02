using System;
using System.Collections;
using System.Collections.Generic;

namespace dnet
{
  public interface IAuthorRepository
  {
    Author Find(string id);

    List<Author> GetAll();

    Author Add(Author author);

    Author Update(Author author);

    void Remove(string id);
  }

}