using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Major_Project_Doctor.Models
{
    public class Staff
    {
       
        public int Id { get; set; }

        public string Staff_Name { get; set; }

        public string Department { get; set; }

        public string Staff_Contact { get; set; }
    }
}
