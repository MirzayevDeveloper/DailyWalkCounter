// Welcome

using Bogus;
using Domain.Enums;
using Infrastructure.Models.Person;
using Infrastructure.Services;

Faker faker = new Faker();

bool isActive = true;

while (isActive)
{
    Console.Write("1.Add Person\n2.Update Person\n3.Read Person\n" +
        "4.Delete Person\n5.Top 5 people better distance\n6.GetAll person " +
        "by distance discanding\n7.GetAll person by address\nChoose option: ");

    string choose = Console.ReadLine();
    int choice;
    int.TryParse(choose, out choice);

    switch (choice)
    {
        case 1:
                RandomAdd();
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
            break;
        case 7:
            break;
    }
}


void RandomAdd()
{
    int point = faker.Random.Int(0, 2);
    Gender gender = point == 0 ? Gender.Male : Gender.Female;

    Person1 person = new()
    {
        PassportId = faker.Random.Guid().ToString(),
        FullName = faker.Name.FullName(),
        Weight = faker.Random.Double(40, 200),
        Gender = gender,
        Age = faker.Random.Int(18, 100),
        Id = Guid.NewGuid(),
        OverallWalkDistance = 0,
        WalkDistances = new List<Guid>() { }
    };

    PersonService personService = new PersonService();
    var task = personService.AddPersonAsync(person);

}