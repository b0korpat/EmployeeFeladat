using System;
using System.Collections.Generic;

namespace EmployeeFeladat.DbModels;

public partial class Dolgozok
{
    public string? Email { get; set; }

    public string? Name { get; set; }

    public int? Salary { get; set; }

    public int? PaymentCount { get; set; }
}
