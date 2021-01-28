using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Major_Project_Doctor.Models
{
    public class Location
    {
      
        public int Id { get; set; }

        public string Name_of_clinic { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }
    }
}
