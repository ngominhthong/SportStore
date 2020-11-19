using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Product { get;  }
    }
}
