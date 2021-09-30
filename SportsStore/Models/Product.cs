using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Пожалуйста введите наименование товара")]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите описание товара")]
        [DisplayName("Описание товара")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Пожалуйста, введите положительное значение")]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите категорию")]
        [DisplayName("Категория")]
        public string Category { get; set; }
        //323
    }
}
