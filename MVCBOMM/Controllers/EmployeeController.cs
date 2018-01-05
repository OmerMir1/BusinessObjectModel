using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinnesLayerAsModel;

namespace MVCBOMM.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeList()
        {
            GetFromDb getempdata = new GetFromDb();
            List<Employee> Elist = getempdata.employees.ToList();
            return View(Elist);
        }
    }
}