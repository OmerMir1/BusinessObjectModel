using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinnesLayerAsModel;
using System.Data;
using System.Web.ModelBinding;

namespace MVCBOMM.Controllers
{
    public class EmployeeController : Controller
    {
        // To Displays the employee list using SQLTools class file
        public ActionResult EmpList()
        {
            SQLTools.connect();
            DataTable dt = SQLTools.ExecuteSelect("Select * from EmployeeDetails");
            SQLTools.CloseConnection();
            return View(dt);
           

        }

        // To Displays the employee list using GetfromDB class file
        public ActionResult EmployeeList()
        {
            GetFromDb getempdata = new GetFromDb();
            List<Employee> Elist = getempdata.employees.ToList();
            return View(Elist);
        }


        //Click on the create new link and display create new screen

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }


        // Submit the new data entered in the form and save it to DB
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            TryUpdateModel(employee);

            GetFromDb SendEmployeeFormData = new GetFromDb();
            SendEmployeeFormData.RecieveDataAndAddToDB(employee);

            return RedirectToAction("EmployeeList");
        }



        // Click on the Edit Link in Employee List screen and open the edit screen for update
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            GetFromDb EditData = new GetFromDb();
            Employee e = EditData.employees.Single(emp => emp.EmployeeID == id);
            return View(e);
        }

        // Recieve the data on form page via employee object and pass it onto the RecvAndUpdateToDB method for manipulation via a stored procedure
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            TryValidateModel(employee);

            if (ModelState.IsValid)
            {
                GetFromDb.RecvAndUpdateToDB(employee);
            }
            else
            {
                return RedirectToAction("EditEmployee");
            }
            return RedirectToAction("EmployeeList");
        }


    }
}