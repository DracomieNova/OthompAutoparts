﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backendAPI.Model
{
    public class MainForm
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int EmployeeId { get; set; }
        public string licencePlate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

       

    }
}
