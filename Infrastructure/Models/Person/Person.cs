namespace Infrastructure.Models.Person
{
    public class Person1 : IPerson
    {
        public Guid Id { get ; set ; }
        public string FullName { get; set; } = "Unknown";
        public int Age { get ; set ; }
        public double Weight { get ; set ; }
        public required string PassportId { get ; set ; }
        public Gender Gender { get ; set ; }
        public IList<Guid> WalkDistances { get ; set ; } = new List<Guid>();

        [JsonProperty("Overall distance")]
        public double OverallWalkDistance { get ; set ; }
        public IAddress Address { get ; set ; }
    }
}
