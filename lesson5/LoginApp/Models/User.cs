using System;
using System.Collections.Generic;

namespace LoginApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? BirthDay { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public bool? Gender { get; set; }
}
