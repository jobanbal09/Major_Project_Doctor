using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Major_Project_Doctor.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public Patient Patient{ get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; }


    }
}
