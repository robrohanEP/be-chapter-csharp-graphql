using System;
using System.Collections;
using System.Collections.Generic;

namespace example
{
  public interface IAuthorRepository
  {
    Author Find(string id);

    Microsoft.EntityFrameworkCore.DbSet<Author> GetAll();

    Author Add(Author author);

    Author Update(Author author);

    void Remove(string id);
  }

}