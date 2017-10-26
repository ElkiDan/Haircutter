using Haircutter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haircutter.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            List<Customer> customers = new List<Customer>();
            using (var db = new HaircutterContext()) {
                customers = db.Customers.ToList();
            }

            return View(customers);
        }

        public ActionResult AddNewCustomer() {
            return PartialView();
        }

        public ActionResult AddNewSub() {
            return PartialView();
        }

        public ActionResult UpdateSub() {
            return PartialView();
        }

        public ActionResult UpdateCustomer() {
            return PartialView();
        }

        public ActionResult UpdateApp() {
            return PartialView();
        }

        [HttpPost]
        public ActionResult updateCustomer(int userId, string color) {
            using (var db = new HaircutterContext()) {
                var customer = db.Customers.FirstOrDefault(i => i.Id == userId);

                if (!string.IsNullOrEmpty(color))
                    customer.color = color;

                db.SaveChanges();
            }
            var res = "success";
            return Content(res);
        }

        [HttpPost]
        public ActionResult updateSub(int userId, string color, int? appToAdd) {
            using (var db = new HaircutterContext()) {
                var sub = db.Customers.FirstOrDefault(i => i.Id == userId);
                if (appToAdd != null && appToAdd < 10 && sub.appointmentsCount + appToAdd > 0)
                    sub.appointmentsCount += appToAdd;
                if (!string.IsNullOrEmpty(color))
                    sub.color = color;

                db.SaveChanges();
            }


            var res = "success";
            return Content(res);
        }

        [HttpPost]
        public ActionResult updateApp(int userid, string comment) {
            var res = "";
            using (var db = new HaircutterContext()) {
                if (db.Customers.Where(i => i.Id == userid).FirstOrDefault().appointmentsCount > 0) {
                    if (string.IsNullOrEmpty(comment))
                        comment = "";
                    db.Appointments.Add(new Appointment() {
                        comment = comment,
                        appointmentDate = DateTime.Now,
                        customerId = userid
                    });
                    db.Customers.Where(i => i.Id == userid).FirstOrDefault().appointmentsCount -= 1;
                    db.SaveChanges();
                    res = "הצלחה";
                }
                else {
                    res = "כישלון מפואר";
                }
            }
            return Content(res);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer) {
            using (var db = new HaircutterContext()) {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            var res = "הלקוח נוסף בהצלחה";
            return Content(res);
        }

        public ActionResult DisplayApps(int userid) {
            if (userid <= 0) {
                userid = 1;
            }
            List<Appointment> appointments = new List<Appointment>();
            using (var db = new HaircutterContext()) {
                appointments = db.Appointments.Where(i => i.customerId == userid).ToList();
            }
            return View(appointments);
        }

        [HttpPost]
        public ActionResult deleteSubOrCus(int userId) {
            using (var db = new HaircutterContext()) {
                Customer customer = db.Customers.FirstOrDefault(i => i.Id == userId);
                if (customer.isSub) {
                    db.Appointments.RemoveRange(customer.Appointments);
                }
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            var res = "הלקוח נוסף בהצלחה";
            return Content(res);
        }
    }
}