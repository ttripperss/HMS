using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Member
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public DateTime? JoinDate { get; set; }

    public string? MembershipType { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public int? Age { get; set; }
}
