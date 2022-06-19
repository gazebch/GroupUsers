﻿// See https://aka.ms/new-console-template for more information

User[] people =
{
    new User(1, "Jora", "Test1", 26), new User(2, "Tom", "Test2", 15),
    new User(3, "Borov", "Test3", 15), new User(4, "Kolt", "Test4", 9),
    new User(5, "Otec", "Test5", 9), new User(6, "Polik", "Test6", 9),
};

var companies = people.GroupBy(s => s.Age);

foreach (var company in companies)
{
    Console.WriteLine(company.Key);

    foreach (var person in company)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine(); // для разделения между группами
}

record class User(long Id, string Name, string LastName, long Age);