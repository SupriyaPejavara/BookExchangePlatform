﻿using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Categories.Commands
{
     public class CreateCategoryCommand : IRequest<Category>
     {
          public string Label { get; set; }
     }
}
