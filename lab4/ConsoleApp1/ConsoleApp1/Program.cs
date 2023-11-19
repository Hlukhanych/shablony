using System;
using System.Collections.Generic;

interface IUniversityComponent
{
    string GetName();
    decimal CalculateSalary();
    void IncreaseSalary(int percentage);
    void AddComponent(IUniversityComponent component);
}

class University : IUniversityComponent
{
    public string Name { get; }
    private List<IUniversityComponent> components = new List<IUniversityComponent>();

    public University(string name)
    {
        Name = name;
    }

    public void AddComponent(IUniversityComponent component)
    {
        components.Add(component);
    }

    public string GetName()
    {
        return Name;
    }

    public decimal CalculateSalary()
    {
        decimal totalSalary = 0;
        foreach (var component in components)
        {
            totalSalary += component.CalculateSalary();
        }
        return totalSalary;
    }

    public void IncreaseSalary(int percentage)
    {
        foreach (var component in components)
        {
            component.IncreaseSalary(percentage);
        }
    }
}

class Faculty : IUniversityComponent
{
    public string Name { get; }
    private List<IUniversityComponent> components = new List<IUniversityComponent>();

    public Faculty(string name)
    {
        Name = name;
    }

    public void AddComponent(IUniversityComponent component)
    {
        components.Add(component);
    }

    public string GetName()
    {
        return Name;
    }

    public decimal CalculateSalary()
    {
        decimal totalSalary = 0;
        foreach (var component in components)
        {
            totalSalary += component.CalculateSalary();
        }
        return totalSalary;
    }

    public void IncreaseSalary(int percentage)
    {
        foreach (var component in components)
        {
            component.IncreaseSalary(percentage);
        }
    }
}

class Department : IUniversityComponent
{
    public string Name { get; }
    private List<IUniversityComponent> components = new List<IUniversityComponent>();

    public Department(string name)
    {
        Name = name;
    }

    public void AddComponent(IUniversityComponent component)
    {
        components.Add(component);
    }

    public string GetName()
    {
        return Name;
    }

    public decimal CalculateSalary()
    {
        decimal totalSalary = 0;
        foreach (var component in components)
        {
            totalSalary += component.CalculateSalary();
        }
        return totalSalary;
    }

    public void IncreaseSalary(int percentage)
    {
        foreach (var component in components)
        {
            component.IncreaseSalary(percentage);
        }
    }
}

class Employee : IUniversityComponent
{
    public string Name { get; }
    public int Experience { get; }
    private decimal Salary;

    public Employee(string name, int experience, decimal baseSalary)
    {
        Name = name;
        Experience = experience;
        Salary = baseSalary;
    }

    public string GetName()
    {
        return Name;
    }

    public decimal CalculateSalary()
    {
        return Salary;
    }

    public void IncreaseSalary(int percentage)
    {
        Salary *= (1 + percentage / 100.0m);
    }

    public void AddComponent(IUniversityComponent component) { }
}

class Program
{
    static void Main()
    {
        // Створення структури університету за допомогою компоновщика
        IUniversityComponent university = new University("My University");

        IUniversityComponent faculty1 = new Faculty("Faculty of Science");
        IUniversityComponent faculty2 = new Faculty("Faculty of Arts");

        university.AddComponent(faculty1);
        university.AddComponent(faculty2);

        IUniversityComponent department1 = new Department("Physics Department");
        IUniversityComponent department2 = new Department("Mathematics Department");
        IUniversityComponent department3 = new Department("Literature Department");

        faculty1.AddComponent(department1);
        faculty1.AddComponent(department2);
        faculty2.AddComponent(department3);

        IUniversityComponent employee1 = new Employee("John Doe", 10, 50000);
        IUniversityComponent employee2 = new Employee("Jane Smith", 8, 45000);
        IUniversityComponent employee3 = new Employee("Bob Johnson", 12, 60000);

        department1.AddComponent(employee1);
        department2.AddComponent(employee2);
        department3.AddComponent(employee3);

        // a) Підрахунок заробітної плати на кожному рівні
        decimal totalSalary = university.CalculateSalary();
        Console.WriteLine($"Total University Salary: {totalSalary}");
        decimal faculty1Salary = faculty1.CalculateSalary();
        Console.WriteLine($"Faculty1 Salary: {faculty1Salary}");
        decimal faculty2Salary = faculty2.CalculateSalary();
        Console.WriteLine($"Faculty2 Salary: {faculty2Salary}");
        decimal department1Salary = department1.CalculateSalary();
        Console.WriteLine($"Department1 Salary: {department1Salary}");
        decimal department2Salary = department2.CalculateSalary();
        Console.WriteLine($"Department2 Salary: {department2Salary}");
        decimal department3Salary = department3.CalculateSalary();
        Console.WriteLine($"Department3 Salary: {department3Salary}");

        // б) Збільшення заробітної плати працівникам зі стажем більше Х років
        university.IncreaseSalary(10);

        // Виведення результатів
        totalSalary = university.CalculateSalary();
        Console.WriteLine($"Salary++ \nTotal University Salary after Increase: {totalSalary}");
    }
}
