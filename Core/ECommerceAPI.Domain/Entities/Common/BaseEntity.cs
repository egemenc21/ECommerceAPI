namespace ECommerceAPI.Domain.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
}