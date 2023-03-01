namespace Domain.Interfaces
{
    public interface IDistance
    {
        public Guid Id { get; set; }
        double WalkDistanceInKm { get; set; }
        double WalkSpeed { get; set; }
        double WalkTime { get; set; }
    }
}
