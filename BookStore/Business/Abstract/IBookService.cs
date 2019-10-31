using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<Book> CheckStock(string isbn);
        IDataResult<List<Book>> CheckStock(List<string> isbnList);
        IDataResult<List<Book>> GetAuthorBooks(Author author);
        IDataResult<List<Book>> GetPublisherBooks(Publisher publisher);
        IResult AddBookToStock(Book book);
    }
}
