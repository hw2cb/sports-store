using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository /*: IProductRepository*/
    {
        public IQueryable<Product> Products => new List<Product> {
            new Product{Name = "Футбольный мяч", Price = 2000},
            new Product{Name = "Доска для серфинга", Price = 8000},
            new Product{Name = "Обувь для бега", Price = 4000},
        }.AsQueryable<Product>();
    }
}
