using System;
using System.Collections.Generic;

namespace EmployeeWebApi.Repository.Entities;

public partial class EmployeeMst
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
