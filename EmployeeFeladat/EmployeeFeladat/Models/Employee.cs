using System;

namespace EmployeeFeladat.Models
{
    class Employee
    {
        private const double adoKulcs = 0.2;
        private int salary = 0;
        private string email;
        private int paymentCount = 0;

        public string Name { get; set; }
        public string Email
        {
            get { return email; }
            private set { email = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public double TaxAmount
        {
            get { return salary * adoKulcs; }
        }

        public int PaymentCount
        {
            get { return paymentCount; }
        }

        public Employee(string name, string email)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email vagy név üres");
            }

            Name = name;
            Email = email;
        }

        public void IncreaseSalary(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Negatív értékkel nem lehet növelni");
            }

            salary += amount;
            paymentCount++;
        }
        public override string ToString()
        {
            return $"Név: {Name}, Email: {Email}, Fizetés: {salary},Fizetések száma: {paymentCount}";
        }
    }
}
