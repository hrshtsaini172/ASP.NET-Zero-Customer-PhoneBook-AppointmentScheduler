using MyTraining1121AngularDemo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class GetCustomerUsersInput : PagedInputDto
    {
        public int CustomerId { get; set; }
        public string Filter { get; set; }
    }
}
