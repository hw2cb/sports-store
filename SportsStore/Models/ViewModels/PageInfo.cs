using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalItems { get; set; } //количество товара всего
        public int ItemsPerPage { get; set; } //количество товара на странице
        public int CurrentPage { get; set; } //кол-во страниц
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
