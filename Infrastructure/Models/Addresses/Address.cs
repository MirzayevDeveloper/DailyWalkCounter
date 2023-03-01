
namespace Infrastructure.Models.Addresses
{
    public class Address : IAddress
    {
        public Guid AddressId { get; set; }
        public Region Region { get; set; } = Region.Other;

        [JsonProperty("Address name")]
        public required string AddressName { get; set; }
    }
}
