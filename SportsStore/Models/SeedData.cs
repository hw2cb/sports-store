using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Каяк", Description = "Каяк одноместный", Category = "Снаряжение для водного вида спорта", Price = 3000},
                    new Product { Name = "Спасательный жилет", Description = "Жилет для защиты на воде", Category = "Снаряжение для водного вида спорта", Price = 1500 },
                    new Product { Name = "Футбольный мяч", Description = "Мяч 5-ти слойный", Category = "Футбол", Price = 2000 },
                    new Product { Name = "Бутцы", Description = "Обувь с шипами", Category = "Футбол", Price = 4000 },
                    new Product { Name = "Теннисная ракетка", Description = "Легкая, маневренная и мощная", Category = "Теннис", Price = 13000 },
                    new Product { Name = "Мяч для тенниса", Description = "Пойдет для игры на любом покрытии", Category = "Теннис", Price = 79 },
                    new Product { Name = "Корзина для сбора мячей", Description = "Стальная корзина, ручки опускаются", Category = "Теннис", Price = 2000 },
                    new Product { Name = "Мешок набивной", Description = "Кожаный, 60 кг", Category = "Единоборства", Price = 19000 },
                    new Product { Name = "Перчатки", Description = "Перчатки боксерские, из синтетической кожи премиум-класса", Category = "Единоборства", Price = 4000 },
                    new Product { Name = "Лапа", Description = "Прочная лапа из качественной искусственной кожи", Category = "Единоборства", Price = 1300 },
                    new Product { Name = "Шапочка", Description = "Шапочка для плавания на тканевой основе Speedo", Category = "Плавание", Price = 1200 },
                    new Product { Name = "Очки для плавания", Description = "Легкая маска, подходит для открытой воды", Category = "Плавание", Price = 2700 },
                    new Product { Name = "Шорты", Description = "Шорты плавательные, мужские", Category = "Плавание", Price = 1000 }
                    );
                context.SaveChanges();
            }
        }
    }
}
