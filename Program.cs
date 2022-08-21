// See https://aka.ms/new-console-template for more information

var comp = new FindAgeComparer();

User[] people =
{
    new User(1, "Jora", "Test1", 26), new User(2, "Tom", "Test2", 15),
    new User(3, "Borov", "Test3", 15), new User(4, "Kolt", "Test4", 9),
    new User(5, "Otec", "Test5", 9), new User(6, "Polik", "Test6", 9),
};

var ageGroup = people.GroupBy(s => s, comp);

foreach (var agePeople in ageGroup)
{
    Console.WriteLine(comp.YearOld(agePeople.Key.Age) ? "Несовершеннолетний" : "Совершеннолетний");

    foreach (var person in agePeople)
    {
        Console.WriteLine(person.Name + " " + person.Age);
    }
    Console.WriteLine(); // для разделения между группами
}

public class FindAgeComparer : IEqualityComparer<User>
{
    public bool Equals(User x, User y)
    {
        return YearOld(x.Age) == YearOld(y.Age);
    }

    public int GetHashCode(User i)
    {
        int f = 1;
        int nf = 100;
        return YearOld(i.Age) ? f.GetHashCode() : nf.GetHashCode();
    }

    public bool YearOld(int id)
    {
        return (id < 18);
    }
}

public record class User(long Id, string Name, string LastName, int Age);