using CinicAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Contexts;
namespace CinicAutomation.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        { // Admin logins
            using (var context = new myclinicEntities1())
            {
                tbl_login obj = context.tbl_login.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();
                if (obj != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    Session["ID"] = obj.adminFk;
                    return RedirectToAction("GetDetailAppointment");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }

            }

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetDetailAppointment()
        {
            // Appointment details get displayed 

            using (var context = new myclinicEntities1())
            {
                var result = context.appointments.Include("patient").Include("physician").Include("schedule").ToList().Select(x => new AppointmentModel()
                {
                    AppointmentModelID = x.AppointID,
                    AppDate = x.AppDate,
                    patient = new patient()
                    {
                        name = x.patient.name,
                    },
                    physician = new physician()
                    {
                        physicianName = x.physician.physicianName
                    },
                    schedule=new schedule()
                    {
                       ScheduleDate=x.schedule.ScheduleDate,
                       ScheduleTime=x.schedule.ScheduleTime,
                    },
                    AppCriticality = x.AppCriticality,
                    AppReason = x.AppReason,
                    AppStatus = x.AppStatus,


                }).ToList();

                return View(result);
            }

        }

       [Authorize(Roles = "Admin")]

        public ActionResult ScheduleAppointment(int id)
        {
            Models.myclinicEntities1 context = new myclinicEntities1();
            return View(context.appointments.Find(id));
            // return View();
        }
        [HttpPost]
        public ActionResult ScheduleAppointment(int id, AppointmentModel model)
        {
            //Admin schedules or declines appointment
            using (var context = new myclinicEntities1())
            {
                var result = context.appointments.FirstOrDefault(x => x.AppointID == id);
                if (result != null)
                {
                    result.AppStatus = model.AppStatus;
                    result.schedule.ScheduleTime = model.schedule.ScheduleTime;
                    result.schedule.ScheduleDate = model.schedule.ScheduleDate;
                }
                context.SaveChanges();
            }
            return RedirectToAction("GetDetailAppointment");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult RegisterPhysician()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterPhysician(LoginModel model)
        {
            using (var context = new myclinicEntities1())
            {
                
                tbl_login obj= new tbl_login();
                {
                    obj.Username = model.Username;
                    obj.Password = model.Password;
                    obj.roleFk = 3;
                    
                    obj.physician = new physician()
                    {
                        physicianName = model.physician.physicianName,
                        physicianGender = model.physician.physicianGender,
                        physicianEmail = model.physician.physicianEmail,
                        physicianContact = model.physician.physicianContact,
                        physicianSpecialization = model.physician.physicianSpecialization,
                        physicianAddress = model.physician.physicianAddress,
                        
                    };
                    


                };
                context.tbl_login.Add(obj);
                context.SaveChanges();
                return RedirectToAction("GetDetailAppointment");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RegisterChemist()
        { return View(); }
         [HttpPost]
        public ActionResult RegisterChemist(LoginModel model)
        {
            using (var context = new myclinicEntities1())
            {

                tbl_login obj = new tbl_login();
                {
                    obj.Username = model.Username;
                    obj.Password = model.Password;
                    obj.roleFk = 4;
                    obj.Chemist = new Chemist()
                    {
                      ChemistName = model.Chemist.ChemistName,
                      ChemistPh = model.Chemist.ChemistPh,
                    };
                    

                };
                context.tbl_login.Add(obj);
                context.SaveChanges();
                return RedirectToAction("GetDetailAppointment");
            }
        }


    }
}