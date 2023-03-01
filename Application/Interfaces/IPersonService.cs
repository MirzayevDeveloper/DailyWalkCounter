using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Task AddPersonAsync(IPerson person);
        Task<bool> DeletePersonById(Guid personId);
        Task<bool> UpdatePersonAsync(IPerson person);
        IPerson GetPersonById(Guid personId);
        IList<IPerson> GetAllPerson();
    }
}
