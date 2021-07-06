using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ContoPizza.Models
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {
            LoadDefaultPizzas();
        }

        public List<Pizza> getPizzas() => Pizzas.Local.ToList<Pizza>();
        

        private void LoadDefaultPizzas()
        {
            Pizzas.Add(new Pizza {Id = 1, Name = "Classic Italian", IsGlutenFree = false});
            Pizzas.Add(new Pizza {Id = 2, Name = "Veggie", IsGlutenFree = true});
        }
    }
}