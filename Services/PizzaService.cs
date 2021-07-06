using System.Collections.Generic;
using System.Linq;
using ContoPizza.Models;
using Microsoft.Extensions.Logging;

namespace ContoPizza.Services
{
    public class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        public static int NextId = 3;

        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new() {Id = 1, Name = "Classic Italian", IsGlutenFree = false},
                new() {Id = 2, Name = "Veggie", IsGlutenFree = true}
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza Get(int id) => Pizzas.FirstOrDefault(pizza => pizza.Id == id);

        public static void AddPizza(Pizza pizza)
        {
            pizza.Id = NextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;
            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;
            Pizzas[index] = pizza;
        }
    }
}