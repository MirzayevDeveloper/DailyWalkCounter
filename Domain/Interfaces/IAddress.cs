using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IAddress
    {
        Guid AddressId { get; set; }
        Region Region { get; set; }
        string AddressName { get; set; }
    }
}
