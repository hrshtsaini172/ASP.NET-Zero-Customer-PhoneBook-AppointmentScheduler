using MyTraining1121AngularDemo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class GetCustomersInput :PagedInputDto
    {
        public string Filter { get; set; }   
    }
}
