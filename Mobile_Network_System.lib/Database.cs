using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Network_System.lib
{
    public class Database : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-6O1ENUJ;Database=Mobile_Network_System;Trusted_Connection=true;Encrypt=false");
        }
        public List<Complaint> GetAllComplaints()
        {
            return Complaints.ToList();
        }
    }
}
