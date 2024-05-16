using CrudAdoExample.DAL;
using CrudAdoExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudAdoExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDAL dal;

        public HomeController()
        {
            dal = new EmployeeDAL ();
        }

        public IActionResult Index()
        {
            List<Employees> emps = dal.getAllEmployees();
            return View(emps);
        }

        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees emp)
        {
            try
            {
                dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
           
        }

        public IActionResult Edit(int id)
        {
            Employees emp =dal.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees emp)
        {
            try
            {
                dal.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult Details(int id)
        {
            Employees emp = dal.GetEmployeeById(id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            Employees emp = dal.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Employees employees)
        {
            try
            {
                dal.DeleteEmployee(employees.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
