namespace Infrastructure.States
{
    public class DBHelper
    {
        public static readonly string AddressPath = @"..\..\..\..\Application\DataBase\AddressDB.json";
        public static readonly string DistancePath = @"..\..\..\..\Application\DataBase\DistancesDB.json";
        public static readonly string PersonPath = @"..\..\..\..\Application\DataBase\PersonDB.json";

        public static async Task WriteToDB<T>(IList<T> list, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(list as List<T>, Formatting.Indented));
        }
        public static List<T>? ReadFromDB<T>(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }
    }
}
