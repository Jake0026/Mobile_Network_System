using System;
using System.Collections.Generic;

namespace Mobile_Network_System.lib;

public partial class Complaint
{
    public Complaint(string description)
    {
        Description = description;
        Status = "unresolved";
    }

    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;
}
