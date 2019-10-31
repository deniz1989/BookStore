
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;
        private IISBNCheckService _iSBNCheckService;

        public BookManager(IBookDal bookDal, IISBNCheckService iSBNCheckService)
        {
            _bookDal = bookDal;
            _iSBNCheckService = iSBNCheckService;
        }

        public IResult AddBookToStock(Book book)
        {
            if (_iSBNCheckService.IsValidISBN(book.ISBN))
            {
                _bookDal.Add(book);
                return new SuccessResult("Kitap stoğa eklendi");
            }
            return new ErrorResult("Geçersiz ISBN!");
        }

        public IDataResult<Book> CheckStock(string isbn)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.ISBN == isbn));
        }

        public IDataResult<List<Book>> CheckStock(List<string> isbnList)
        {
            List<Book> isbns = new List<Book>();

            foreach (var isbn in isbnList)
            {
                if (!string.IsNullOrEmpty(isbn))
                {
                    var result = _bookDal.Get(b => b.ISBN == isbn);
                    if (result != null)
                    {
                        isbns.Add(_bookDal.Get(b => b.ISBN == isbn));
                    }
                }
            }
            return new SuccessDataResult<List<Book>>(isbns);
        }

        public IDataResult<List<Book>> GetAuthorBooks(Author author)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetList(b => b.AuthorId == author.Id).ToList());
        }

        public IDataResult<List<Book>> GetPublisherBooks(Publisher publisher)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetList(b => b.PublisherId == publisher.Id).ToList());
        }
    }
}
