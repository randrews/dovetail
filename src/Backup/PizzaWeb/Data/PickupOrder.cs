using FubuValidation;

namespace PizzaWeb.Data
{
    public class PickupOrder : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Store Store { get; set; }
        [Required]
        public PizzaType PizzaType { get; set; }
    }
}