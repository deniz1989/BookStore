using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IISBNCheckService
    {
        bool IsValidISBN(string isbn);
    }
}
