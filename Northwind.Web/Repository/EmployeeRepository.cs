using Northwind.Web.Controllers;
using Northwind.Web.Models;
using System;
using System.Collections.Generic;
/// <summary>
/// 10-9-2022 Video 4
/// Penggunaan Defedenci Injection
/// Desain Repository
/// </summary>

namespace Northwind.Web.Repository
{
    public class EmployeeRepository : IEmployee
    {
        public List<Employee> GetAll()
        {
            var listOfEmployee = new List<Employee>() 
            {
                new Employee {Id=1001, Name="Ahsan Murobi", Email="Ahsanmurobi@gmail.com", BirthDate =new System.DateTime (1996,04,24) },
                new Employee {Id=1002, Name="Khoerul Mutaqin",Email="Khoerulmutaqin@gmail.com", BirthDate =new DateTime (1999,07,03) },
                new Employee {Id=1003, Name="Silvia Raudha",Email="Silviaraudha@gmail.com", BirthDate =new DateTime (2002,03,24)},
                new Employee {Id=1004, Name="Apnan Faiz",Email="Apnanfaiz@gmail.com", BirthDate =new DateTime (2003,07,22)},
                new Employee {Id=1005, Name="Ahmad Abdul Muiz",Email="Ahmadmuiz@gmail.com", BirthDate =new DateTime (2011,07,11)},

            };
            return listOfEmployee;
        }
    }
}
