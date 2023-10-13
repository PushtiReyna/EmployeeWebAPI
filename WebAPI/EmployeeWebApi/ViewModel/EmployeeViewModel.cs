using System;
using System.Collections.Generic;

namespace EmployeeWebApi.ViewModel;

public partial class EmployeeViewModel
{
    public int EmployeeId { get; set; }

    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;
}
