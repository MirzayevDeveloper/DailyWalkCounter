
namespace Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        public async Task AddAddressAsync(IAddress address)
        {
            var mutex = new Mutex();

            List<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };
            list.Add(address);

            mutex.WaitOne();

            await DBHelper.WriteToDB(list, DBHelper.AddressPath);

            mutex.ReleaseMutex();
        }

        public async Task<bool> DeleteAddressByIdAsync(Guid addressId)
        {
            List<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };

            IAddress? add = list.FirstOrDefault(address => address.AddressId == address.AddressId);

            if (add == null) return false;

            return list.Remove(add);
        }

        public IAddress? GetAddressById(Guid addressId)
        {
            List<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };

            return list.FirstOrDefault(address => address.AddressId == addressId);
        }

        public List<IAddress>? GetAllAddresses()
        {
            List<IAddress>? addresses = JsonConvert.DeserializeObject<List<IAddress>>
                (File.ReadAllText(DBHelper.AddressPath));

            return addresses;
        }

        public async Task<bool> UpdateAddressAsync(IAddress address)
        {
            List<IAddress> list = GetAllAddresses() ?? new List<IAddress>() { };

            IAddress? add = list.FirstOrDefault(address => address.AddressId == address.AddressId);

            if (add == null) return false;

            int index = list.IndexOf(address);

            list[index] = address;

            return true;
        }
    }
}
