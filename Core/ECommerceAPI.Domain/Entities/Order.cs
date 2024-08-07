using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public class Order : BaseEntity
{
    public string Description { get; set; }
    public string Address { get; set; }
    
    public Guid CustomerId { get; set; }
    
    //Relations
    public ICollection<Product> Products { get; set; }
    public Customer Customer { get; set; }
   
    
    
}