using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("checkstock")]
        public IActionResult CheckStock(string isbn)
        {
            var result = _bookService.CheckStock(isbn);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("checkstock")]
        public IActionResult CheckStock(List<string> isbnList)
        {
            var result = _bookService.CheckStock(isbnList);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getauthorbooks")]
        public IActionResult GetAuthorBooks(Author author)
        {
            var result = _bookService.GetAuthorBooks(author);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getpublisherbooks")]
        public IActionResult GetPublisherBooks(Publisher publisher)
        {
            var result = _bookService.GetPublisherBooks(publisher);
            if (result.Success)
            {
                return Ok(result.Data);   
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addbooktostock")]
        public IActionResult AddBookToStock(Book book)
        {
            var result = _bookService.AddBookToStock(book);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}