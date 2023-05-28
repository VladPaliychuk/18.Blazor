using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlazingPizza
{
    /// <summary>
    /// Represents a customized pizza as part of an order
    /// </summary>
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public int Id { get; set; }

        [Required(ErrorMessage = "You must set a name for your pizza.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [EmailAddress(ErrorMessage = "You must set a valid email address for the chef responsible for the pizza recipe.")]
        public string ChefEmail { get; set; }

        [Required]
        [Range(10.00, 25.00, ErrorMessage = "You must set a price between $10 and $25.")]
        public decimal Price { get; set; }

        public int OrderId { get; set; }

        public PizzaSpecial Special { get; set; }

        public int SpecialId { get; set; }

        public int Size { get; set; }

        public List<PizzaTopping> Toppings { get; set; }

        public decimal GetBasePrice()
        {
            return ((decimal)Size / (decimal)DefaultSize) * Special.BasePrice;
        }

        public decimal GetTotalPrice()
        {
            return GetBasePrice();
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}
