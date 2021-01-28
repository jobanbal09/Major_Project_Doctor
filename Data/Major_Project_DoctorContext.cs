using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Major_Project_Doctor.Models;

namespace Major_Project_Doctor.Data
{
    public class Major_Project_DoctorContext : DbContext
    {
        public Major_Project_DoctorContext (DbContextOptions<Major_Project_DoctorContext> options)
            : base(options)
        {
        }

        public DbSet<Major_Project_Doctor.Models.Location> Location { get; set; }

        public DbSet<Major_Project_Doctor.Models.Patient> Patient { get; set; }

        public DbSet<Major_Project_Doctor.Models.Specialist> Specialist { get; set; }

        public DbSet<Major_Project_Doctor.Models.Staff> Staff { get; set; }

        public DbSet<Major_Project_Doctor.Models.Appointment> Appointment { get; set; }
    }
}
