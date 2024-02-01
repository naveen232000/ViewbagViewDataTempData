using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewbagViewDataTempData.Models;

namespace ViewbagViewDataTempData.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        static List<Emp> emps = new List<Emp> { 
        new Emp { Id=1,Name="Naveen",Salary=65238,Designation="Developer"},
        new Emp { Id=2,Name="Jon",Salary=65238,Designation="Tester"},
        new Emp { Id=3,Name="Sam",Salary=65238,Designation="HR"},
        new Emp { Id=4,Name="Leo",Salary=65238,Designation="Manager"},
        new Emp { Id=5,Name="Das",Salary=65238,Designation="Tester"},
        };
        public ActionResult Index()
        {
            ViewBag.msg = "Welcome to Employee Management";
            ViewBag.empCount=emps.Count;
            return View(emps);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["msg"] = "Employee Registeration";
            return View(new Emp());
        }
        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                emps.Add(emp);
                TempData["tempData"] = " New Employee Registered Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
        Emp emp = emps.SingleOrDefault(e=>e.Id==id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Emp emp = emps.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                emps.Remove(emp);
                TempData["tempData"] = $"Employee {emp.Name} Deleted Successfully ";
            }
            return RedirectToAction("Index");
        }
    }
}