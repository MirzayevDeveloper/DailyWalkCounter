namespace Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        public async Task AddPersonAsync(IPerson person)
        {
            IList<IPerson> list = GetAllPerson() ?? new List<IPerson> { };
            list.Add(person);

            await DBHelper.WriteToDB(list, DBHelper.PersonPath);
        }

        public async Task<bool> DeletePersonById(Guid personId)
        {
            IList<IPerson> list = GetAllPerson() ?? new List<IPerson>() { };

            IPerson? person = list.FirstOrDefault(person => person.Id == personId);

            if (person == null) return false;

            return list.Remove(person);
        }

        public  IList<IPerson>? GetAllPerson()
        {
            IList<IPerson>? list = JsonConvert.DeserializeObject<IList<IPerson>>
                (File.ReadAllText(DBHelper.PersonPath));

            return list;
        }

        public IPerson? GetPersonById(Guid personId)
        {
            IList<IPerson> list = GetAllPerson() ?? new List<IPerson>() { };

            return list.FirstOrDefault(person => person.Id == personId);
        }

        public async Task<bool> UpdatePersonAsync(IPerson person)
        {
            IList<IPerson> list = GetAllPerson() ?? new List<IPerson>() { };

            IPerson? per = list.FirstOrDefault(p => p.Id == person.Id);

            if (per == null) return false;

            int index = list.IndexOf(per);

            list[index] = person;

            return true;
        }

        public static List<IPerson> GetFiveTopPeople()
        {
            IList<IPerson>? people = JsonConvert.DeserializeObject<IList<IPerson>>
                (File.ReadAllText(DBHelper.PersonPath));

            var list3 = (from obj in people
                        orderby obj.OverallWalkDistance descending
                        select obj).Take(5).ToList();
            return list3;
        }

        public static List<IPerson> GetPeopleDistanceDescending()
        {
            IList<IPerson>? people = JsonConvert.DeserializeObject<IList<IPerson>>
                (File.ReadAllText(DBHelper.PersonPath));

            var list3 = (from obj in people
                         orderby obj.OverallWalkDistance descending
                         select obj).ToList();
            return list3;
        }

        public static List<IGrouping<string, IPerson>> GetPeopleByAddress()
        {
            IList<IPerson>? people = JsonConvert.DeserializeObject<IList<IPerson>>
                (File.ReadAllText(DBHelper.PersonPath));

            var address = (from obj in people
                          group obj by obj.Address.AddressName
                          into g
                          select g).ToList();

            return address;
        }

    }
}
