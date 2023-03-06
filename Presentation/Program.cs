// Welcome

using Domain.Interfaces;
using Infrastructure.Models.Addresses;
using Infrastructure.Models.Person;
using Infrastructure.Services;
using Tynamix.ObjectFiller;

bool isActive = true;

while (isActive)
{
    Console.Clear();

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
    PersonService personService = new PersonService();

    var task = personService.AddPersonAsync(
        CreatePersonFiller(CreateAddressFiller().Create()).Create());
}

Filler<Person> CreatePersonFiller(IAddress address)
{
    var filler = new Filler<Person>();

    filler.Setup().OnType<IAddress>().Use(address); 

    return filler;
}
Filler<Address> CreateAddressFiller() => new Filler<Address>();
