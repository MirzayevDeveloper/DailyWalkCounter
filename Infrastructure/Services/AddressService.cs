
namespace Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        public async Task AddAddressAsync(IAddress address)
        {
            IList<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };
            list.Add(address);
            await DBHelper.WriteToDB(list, DBHelper.AddressPath);
        }

        public async Task<bool> DeleteAddressByIdAsync(Guid addressId)
        {
            IList<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };

            IAddress? add = list.FirstOrDefault(address => address.AddressId == address.AddressId);

            if (add == null) return false;

            return list.Remove(add);
        }

        public IAddress? GetAddressById(Guid addressId)
        {
            IList<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };

            return list.FirstOrDefault(address => address.AddressId == addressId);
        }

        public IList<IAddress>? GetAllAddresses()
        {
            IList<IAddress>? addresses = JsonConvert.DeserializeObject<IList<IAddress>>
                (File.ReadAllText(DBHelper.AddressPath));

            return addresses;
        }

        public async Task<bool> UpdateAddressAsync(IAddress address)
        {
            IList<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };

            IAddress? add = list.FirstOrDefault(address => address.AddressId == address.AddressId);

            if (add == null) return false;

            int index = list.IndexOf(address);

            list[index] = address;

            return true;
        }
    }
}
