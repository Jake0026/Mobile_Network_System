using System;
using System.Collections.Generic;

namespace Mobile_Network_System.lib;

public partial class Operator
{
    public Operator(string name, string phone, string logo, int percent)
    {
        Name = name;
        Phone = phone;
        Logo = logo;
        Percent = percent;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public int Percent { get; set; }
}
