using System.ComponentModel.DataAnnotations;

namespace Weather.Api.Entities;
public class Customer
{
    [Key]
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Address? DefaultBillingAddress { get; set; }
    public Address? DefaultShippingAddress { get; set; }

    public ICollection<Order>? RecentOrders { get; set; }
}
