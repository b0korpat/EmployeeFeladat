using EmployeeFeladat.DbModels;
using EmployeeFeladat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeFeladat.Repo
{
    class EmployeeRepo
    {
        private readonly DatabaseContext _context;

        public EmployeeRepo(DatabaseContext context)
        {
            _context = context;
        }

        public int GetEmployeeCount()
        {
            return _context.Dolgozoks.Count();
        }

        public void ListEmployees()
        {
            foreach (var employee in _context.Dolgozoks)
            {
                Console.WriteLine(employee.Name + " (" + employee.Email + ") - " + employee.Salary);
            }
        }

        public void ListEmplyeesWithSalaryAbove(int salary)
        {
            foreach (var employee in _context.Dolgozoks.Where(e => e.Salary > salary))
            {
                Console.WriteLine(employee.Name + " (" + employee.Email + ") - " + employee.Salary);
            }
        }

        public void ListEmployeesDescBySalary()
        {
            foreach (var employee in _context.Dolgozoks.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine(employee.Name + " (" + employee.Email + ") - " + employee.Salary);
            }
        }

        public void GetAvgAndSumSalary()
        {
            var avg = _context.Dolgozoks.Average(e => e.Salary);
            var sum = _context.Dolgozoks.Sum(e => e.Salary);
            Console.WriteLine($"Átlag: {avg}, Összeg: {sum}");
        }

        public void GetNumberOfEmployeesInSalaryRange()
        {
            var groupedEmployees = _context.Dolgozoks
                .GroupBy(e => e.Salary < 400000 ? "400000 Ft alatt" :
                              e.Salary <= 500000 ? "400000 - 500000 Ft között" :
                              "500000 Ft felett")
                .ToList();

            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
                foreach (var employee in group)
                {
                    Console.WriteLine(employee.Name + " (" + employee.Email + ") - " + employee.Salary);
                }
            }
        }


        public void GetEmployeesTax()
        {
            foreach (var employee in _context.Dolgozoks)
            {
                Console.WriteLine(employee.Name + " - " + employee.TaxAmount);
            }
        }

        public void GetEmployeesPaymentCount()
        {
            foreach (var employee in _context.Dolgozoks)
            {
                Console.WriteLine(employee.Name + " - " + employee.PaymentCount);
            }
        }

        public void AddEmployee(Employee employee)
        {
            if (_context.Dolgozoks.Any(e => e.Email == employee.Email))
            {
                throw new ArgumentException("Már létezik ilyen email című dolgozó");
            }

            _context.Dolgozoks.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateSalary(string email, int amount)
        {
            var employee = _context.Dolgozoks.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                throw new ArgumentException("Nincs ilyen email című dolgozó");
            }
            employee.Salary = amount;
            _context.SaveChanges();
        }

        public void DeleteEmployee(string email)
        {
            var employee = _context.Dolgozoks.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                throw new ArgumentException("Nincs ilyen email című dolgozó");
            }
            _context.Dolgozoks.Remove(employee);
            _context.SaveChanges();

        }
    }
}