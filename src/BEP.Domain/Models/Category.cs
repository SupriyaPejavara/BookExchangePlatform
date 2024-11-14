using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEP.Domain.Models
{
     public class Category : BaseEntity
     {
          public string Label;

          public List<Book> Books;
     }
}
