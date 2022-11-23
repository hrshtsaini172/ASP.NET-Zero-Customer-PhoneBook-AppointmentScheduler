using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class AssignUserToCustomerInput
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
