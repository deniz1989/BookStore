using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public bool IsValidISBN { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Format { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Version { get; set; }
        public string Preface { get; set; }
        public int QuantityLeft { get; set; }
        public int WarehouseLocation { get; set; }
        public DateTime NextStockDate { get; set; }

    }
}
