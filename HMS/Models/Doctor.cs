using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Doctor
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int? ContactNumber { get; set; }

    public string? Email { get; set; }

    public Guid? DepartmentId { get; set; }

    public int? Experience { get; set; }

    public string? Specialization { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsActive { get; set; }

    //public string? ProfilePictureId { get; set; }
}
