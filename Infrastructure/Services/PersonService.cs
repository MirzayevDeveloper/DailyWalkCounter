namespace Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        public async Task AddPersonAsync(IPerson person)
        {
            var mutex = new Mutex();

            List<IPerson> list = GetAllPerson() ?? new List<IPerson> { };
            list.Add(person);

            mutex.WaitOne();

            await DBHelper.WriteToDB(list, DBHelper.PersonPath);

            mutex.ReleaseMutex();
        }

        public async Task<bool> DeletePersonById(Guid personId)
        {
            List<IPerson> list = GetAllPerson() ?? new List<IPerson>() { };

            IPerson? person = list.FirstOrDefault(person => person.Id == personId);

            if (person == null) return false;

            return list.Remove(person);
        }

        public List<IPerson>? GetAllPerson()
        {
            List<IPerson>? list =  DBHelper.ReadFromDB<IPerson>(DBHelper.PersonPath);

            return list;
        }

        public IPerson? GetPersonById(Guid personId)
        {
            List<IPerson> list = GetAllPerson() ?? new List<IPerson>() { };

            return list.FirstOrDefault(person => person.Id == personId);
        }

        public async Task<bool> UpdatePersonAsync(IPerson person)
        {
            List<IPerson> list = GetAllPerson() ?? new List<IPerson>() { };

            IPerson? per = list.FirstOrDefault(p => p.Id == person.Id);

            if (per == null) return false;

            int index = list.IndexOf(per);

            list[index] = person;

            return true;
        }

        public static List<IPerson> GetFiveTopPeople()
        {
            List<IPerson>? people = JsonConvert.DeserializeObject<List<IPerson>>
                (File.ReadAllText(DBHelper.PersonPath));

            var list3 = (from obj in people
                        orderby obj.OverallWalkDistance descending
                        select obj).Take(5).ToList();
            return list3;
        }

        public static List<IPerson> GetPeopleDistanceDescending()
        {
            List<IPerson>? people = JsonConvert.DeserializeObject<List<IPerson>>
                (File.ReadAllText(DBHelper.PersonPath));

            var list3 = (from obj in people
                         orderby obj.OverallWalkDistance descending
                         select obj).ToList();
            return list3;
        }

        public static List<IGrouping<string, IPerson>> GetPeopleByAddress()
        {
            List<IPerson>? people = JsonConvert.DeserializeObject<List<IPerson>>
                (File.ReadAllText(DBHelper.PersonPath));

            var address = (from obj in people
                          group obj by obj.Address.AddressName
                          into g
                          select g).ToList();

            return address;
        }

    }
}
