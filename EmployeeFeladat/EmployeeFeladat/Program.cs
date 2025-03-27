
using EmployeeFeladat.DbModels;
using EmployeeFeladat.Models;
using EmployeeFeladat.Repo;


//Email nélküli
try { 

    Employee NoEmail = new Employee("NoEmail Emil", "");
}
catch (ArgumentException err)
{
    Console.WriteLine(err.Message);
}

//Normal
Employee employee1 = new Employee("Nagy Anna", "nagy.anna@munkahely.com");
Console.WriteLine(employee1);

//Negativ Fizetés
try
{
    employee1.IncreaseSalary(-50000);
}
catch (ArgumentException err)
{
    Console.WriteLine(err.Message);
}


//2 valid fizetés
employee1.IncreaseSalary(25000);
employee1.IncreaseSalary(40000);
Console.WriteLine(employee1);

//adó
Console.WriteLine($"Adó: {employee1.TaxAmount}");


//Repo Test
EmployeeRepo repo = new EmployeeRepo(new DatabaseContext());

Console.WriteLine(repo.GetEmployeeCount());

repo.ListEmployees();

repo.ListEmplyeesWithSalaryAbove(480000);

repo.ListEmployeesDescBySalary();

repo.GetAvgAndSumSalary();

repo.GetNumberOfEmployeesInSalaryRange();

repo.GetEmployeesTax();

repo.GetEmployeesPaymentCount();

repo.UpdateSalary("nagy.anna@munkahely.com", 2000000);
repo.ListEmployees();

try
{

repo.DeleteEmployee("asd");
}
catch (ArgumentException err)
{
    Console.WriteLine(err.Message);
}

repo.ListEmployees();