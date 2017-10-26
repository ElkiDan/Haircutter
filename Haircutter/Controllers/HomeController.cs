using Haircutter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haircutter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            using (var db = new HaircutterContext())
            {
                customers = db.Customers.ToList();
            }
            
            return View(customers);
        }

        public ActionResult AddNewCustomer()
        {
            

            return PartialView();
        }

        [HttpPost]
       public ActionResult updateApp(int userid)
        {
            using (var db = new HaircutterContext())
            {
                db.Appointments.Add(new Appointment()
                {
                    appointmentDate = DateTime.Now,
                    customerId = userid
                });
                db.Customers.Where(i => i.Id == userid).FirstOrDefault().appointmentsCount -= 1;
                db.SaveChanges();
            }
            var res = "הקבוצה נוצרה בהצלחה";
            return Content(res);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            using (var db = new HaircutterContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            var res = "הלקוח נוסף בהצלחה";
            return Content(res);
        }

        public ActionResult DisplayApps(int userid)
        {
            if (userid <= 0)
            {
                userid = 1;
            }
            List<Appointment> appointments = new List<Appointment>();
            using (var db = new HaircutterContext())
            {
                appointments = db.Appointments.Where(i=>i.customerId == userid).ToList();
            }
            return View(appointments);
        }
    }
}