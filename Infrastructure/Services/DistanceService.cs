using Infrastructure.Models.Addresses;
using Infrastructure.Models.Distances;
using Infrastructure.Models.Person;

namespace Infrastructure.Services
{
    public class DistanceService : IDistanceService
    {
        public async Task AddDistanceAsync(IDistance distance)
        {
            IList<IDistance> list = GetAllDistances() ?? new List<IDistance> { };
            list.Add(distance);
            await DBHelper.WriteToDB(list, DBHelper.DistancePath);
        }

        public IList<IDistance>? GetAllDistances()
        {
            var list = JsonConvert.DeserializeObject<IList<IDistance>>
                (File.ReadAllText(DBHelper.DistancePath));

            return list;
        }

        public IDistance? GetDistanceById(Guid distanceId)
        {
            IList<IDistance> list = GetAllDistances() ?? new List<IDistance> { };

            return list.FirstOrDefault(distance => distance.Id == distanceId);
        }

        public async Task<bool> DeleteDistanceByIdAsync(Guid distanceId)
        {
            IList<IDistance> list = GetAllDistances() ?? new List<IDistance>() { };

            IDistance? dis = list.FirstOrDefault(@distance => @distance.Id == distance.Id);

            if (dis == null) return false;

            return list.Remove(dis);
            
        }

        public async Task<bool> UpdateDistanceAsync(IDistance distance)
        {
            IList<IDistance> list = GetAllDistances() ?? new List<IDistance>() { };

            IDistance? dis = list.FirstOrDefault(@distance => @distance.Id == distance.Id);

            if (dis == null) return false;

            int index = list.IndexOf(dis);

            list[index] = dis;

            return true;
        }
    }
}
