using System;
using System.Collections.Generic;

namespace Mobile_Network_System.lib;

public partial class Customer
{
    public Customer(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
