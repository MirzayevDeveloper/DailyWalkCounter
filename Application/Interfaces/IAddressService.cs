using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IAddressService
    {
        Task AddAddressAsync(IAddress address);
        Task<bool> DeleteAddressByIdAsync(Guid addressId);
        Task<bool> UpdateAddressAsync(IAddress address);
        IAddress GetAddressById(Guid addressId);
        List<IAddress> GetAllAddresses(); 
    }
}
