using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public Guid? ProfilePictureId { get; set; }

    public Guid? Salt { get; set; }

    public string? ProfilePictureName { get; set; }
}
