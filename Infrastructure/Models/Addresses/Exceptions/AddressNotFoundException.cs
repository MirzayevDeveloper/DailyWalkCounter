namespace Infrastructure.Models.Addresses.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException(string message = "Address not found, invalid id!")
            :base(message) { }
    }
}
