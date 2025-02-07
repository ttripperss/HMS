using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Patient
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? Gender { get; set; }

    public int? ContactNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public Guid? DoctorId { get; set; }

    public DateTime? DischargeDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string? ProfilePictureId { get; set; }
}
