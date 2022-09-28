 using System;
using Microsoft.AspNetCore.Mvc;
using Northwind.Web.Models;
using System.Collections.Generic;
using Northwind.Web.Repository;

namespace Northwind.Web.Controllers
{
    public class EmployeeController : Controller
    {

        //using depedency injection
        private readonly IEmployee _IEmployee;

        //Constructornya terlebih dahulu
        public EmployeeController(IEmployee iEmployee)
        {
            _IEmployee = iEmployee;
        }

  

        //Constructornya terlebih dahulu


        /// Trigger artinya panggil
        public IActionResult ListEmployee()
        {
            //Code Practice
/*            var listOfEmployee = new List<Employee>() {
                new Employee {Id=1001, Name="Bang Taqin", BirthDate =new DateTime (1999,07,03) },
                new Employee {Id=1002, Name="Ka Silvi", BirthDate =new DateTime (2002,04,24) },
                new Employee {Id=1003, Name="Ka Intan", BirthDate =new DateTime (2002,08,11)}

            };*/
            //Get all dari interface
            return View("ListEmployee", _IEmployee.GetAll());
        }
        public IActionResult Person()
        {
            //Code Practice
            /*            var listOfEmployee = new List<Employee>() {
                            new Employee {Id=1001, Name="Bang Taqin", BirthDate =new DateTime (1999,07,03) },
                            new Employee {Id=1002, Name="Ka Silvi", BirthDate =new DateTime (2002,04,24) },
                            new Employee {Id=1003, Name="Ka Intan", BirthDate =new DateTime (2002,08,11)}

                        };*/
            //Get all dari interface
            return View("Person", _IEmployee.GetAll());
        }

        public  IActionResult Category()
        {
            return View();
        }


        private IActionResult View(string v, Func<List<Employee>> getAll)
        {
            throw new NotImplementedException();
        }


    }
}
