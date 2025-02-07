using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Department
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? HeaOfDepartment { get; set; }

    public string? ContactNumbers { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
