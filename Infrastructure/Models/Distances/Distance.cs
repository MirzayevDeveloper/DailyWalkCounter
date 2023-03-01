namespace Infrastructure.Models.Distances
{
    public class Distance : IDistance
    {
        [JsonRequired]
        public Guid Id { get; set; }

        [JsonProperty("Distance km")]
        public double WalkDistanceInKm { get ; set ; }

        [JsonProperty("Speed")]
        public double WalkSpeed { get ; set ; }

        [JsonProperty("Time")]
        public double WalkTime { get ; set ; }
    }
}
