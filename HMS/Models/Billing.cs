using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Billing
{
    public Guid Id { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? DoctorId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? BillingDate { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsDeleted { get; set; }
}
