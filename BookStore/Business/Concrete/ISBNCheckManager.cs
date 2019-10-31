using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ISBNCheckManager : IISBNCheckService
    {
        public bool IsValidISBN(string isbn)
        {
            return new Random().Next(100) % 2 == 0;
        }
    }
}
