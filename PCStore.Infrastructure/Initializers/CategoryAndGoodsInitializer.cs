using Microsoft.EntityFrameworkCore;
using PCStore.Core.Entities.SIte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Infrastructure.Initializers
{
    internal static class CategoryAndGoodsInitializer
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category() { Id = 1, Name = "Processor"},
                new Category() { Id = 2, Name = "Graphics card"},
                new Category() { Id = 3, Name = "Motherboard"},
                new Category() { Id = 4, Name = "RAM"},
                new Category() { Id = 5, Name = "Cooling"},
                new Category() { Id = 6, Name = "Memory card"},
                new Category() { Id = 7, Name = "Power supply"},
                new Category() { Id = 8, Name = "Case"},
                new Category() { Id = 9, Name = "Monitor"},
                new Category() { Id = 10, Name = "Mouse"},
                new Category() { Id = 11, Name = "Keyboard"},
                new Category() { Id = 12, Name = "Headphone"},
                new Category() { Id = 13, Name = "Microphone"},
                new Category() { Id = 14, Name = "Laptop"},
            });
        }
    }
}
