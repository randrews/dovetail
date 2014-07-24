using FubuValidation;

namespace PizzaWeb.Data
{
    public class PickupOrder : Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Store Store { get; set; }
        [Required]
        public PizzaType PizzaType { get; set; }
    }
}