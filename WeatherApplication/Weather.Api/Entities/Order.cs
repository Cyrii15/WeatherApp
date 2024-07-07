using System.ComponentModel.DataAnnotations;

namespace Weather.Api.Entities;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid TrackingNumber { get; set; }

    public DefaultAddress ShipToAddress { get; set; }
}
