using System;
using System.Collections.Generic;

namespace GridApp.Models;

public partial class GridDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Country { get; set; }
}
