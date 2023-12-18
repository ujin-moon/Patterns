using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var employee1 = new Employee { Id = 1, Name = "John" };
        var employee2 = new Employee { Id = 3, Name = "Alice" };
        var employee3 = new Employee { Id = 2, Name = "Bob" };

        var list = new List<Employee> { employee1, employee2, employee3 };

        Console.WriteLine("Original List:");
        foreach (var employee in list)
        {
            Console.WriteLine(employee);
        }

        SortLists(list);

        Console.WriteLine("\nSorted List (by Id):");
        foreach (var employee in list)
        {
            Console.WriteLine(employee);
        }

        Console.WriteLine("\nSorted List (by Name):");
        list.Sort((x, y) => x.Name.CompareTo(y.Name));
        foreach (var employee in list)
        {
            Console.WriteLine(employee);
        }
        Console.ReadLine();
    }

    public static void SortLists(List<Employee> list)
    {
        list.Sort(new EmployeeByIdComparer());
    }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return string.Format("Id = {0}, Name = {1}", Id, Name);
    }
}

class EmployeeByIdComparer : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return x.Id.CompareTo(y.Id);
    }
}