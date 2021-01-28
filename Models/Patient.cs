using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Major_Project_Doctor.Models
{
    public class Patient
    {
        
        public int Id { get; set; }//Id interger input

        public string Patient_Name { get; set; }//to add  Customername

        public string Address { get; set; } // to add address

        public string Patient_Age { get; set; } //to add customer age 

        public DateTime Joining_Date { get; set; }//to add start date 
    }
}
