using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Models.Entities
{
    public class Customer
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DefaultAddress? DefaultBillingAddress { get; set; }
        public DefaultAddress? DefaultShippingAddress { get; set; }

        public ICollection<Order>? RecentOrders { get; set; }
    }
}
