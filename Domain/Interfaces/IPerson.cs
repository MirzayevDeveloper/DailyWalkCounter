using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IPerson
    {
        Guid Id { get; set; }
        string FullName { get; set; }
        int Age { get; set; }
        double Weight { get; set; }
        string PassportId { get; set; }
        Gender Gender { get; set; }
        IAddress Address { get; set; }
        IList<Guid> WalkDistances { get; set; }
        double OverallWalkDistance { get; set; }
    }
}
