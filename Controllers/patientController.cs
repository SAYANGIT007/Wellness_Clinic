using CinicAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace CinicAutomation.Controllers
{
    
    public class patientController : Controller
    {
        // GET: patient
        public ActionResult Login()
        { // Patient logins
            return View();
        }
        [HttpPost]
        
        public ActionResult Login(LoginModel model)
        { // Patient logins
            using(var context=new myclinicEntities1())
            {
                tbl_login obj =context.tbl_login.Where(x=>x.Username==model.Username && x.Password==model.Password).SingleOrDefault();
                if(obj !=null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    Session["ID"] = obj.patientFk;
                    return RedirectToAction("GetDetailsPatient");
                }
            }
            
                return RedirectToAction("Login");
        }
        [Authorize(Roles = "Patient")]
        public ActionResult GetDetailsPatient()
        {
            // Patient details gets displayed
            int ID = Convert.ToInt32(Session["ID"]);
            using(var context=new myclinicEntities1()) 
            {
                var result = context.patients.Where(x=>x.id==ID).Select(x=>new patientModel()
                {
                    id =x.id,
                    name = x.name,
                    dob=x.dob,
                    gender = x.gender,
                    email = x.email,
                    phone = x.phone,
                    address = x.address,
                    history = x.history,

                }).ToList();
                return View(result);
            }
            
        }
        [Authorize]
        public ActionResult GetDetailAppointment()
        {
            // Appointment details get displayed 
            int ID = Convert.ToInt32(Session["ID"]);
            using (var context = new myclinicEntities1())
            {
                var result = context.appointments.Include("patient").Include("physician").ToList().Where(x => x.patientFk == ID).Select(x => new AppointmentModel()
                {
                    AppointmentModelID = x.AppointID,
                    AppDate = x.AppDate,
                    patient = new patient()
                    {
                        name = x.patient.name,
                        history = x.patient.history,
                        gender = x.patient.gender,
                    },
                    physician = new physician()
                    {
                        physicianName = x.physician.physicianName
                    },
                    AppCriticality = x.AppCriticality,
                    AppReason = x.AppReason,
                    AppStatus = x.AppStatus,
                    patientFk = x.patientFk,
                    physicianFk = x.physicianFk,

                }).ToList();

                return View(result);
            }

        }
        [Authorize]
        public ActionResult CreateAppointment()
        {   //Patient Books Appointment.

            var db = new myclinicEntities1();
            ViewBag.PhysicianFk =  new SelectList(  db.physicians.ToList(), "physicianID", "physicianName");

            return View(); 
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateAppointment(AppointmentModel model)
        { // Patients Books Apointment.
            int ID = Convert.ToInt32(Session["ID"]);
            using (var context = new myclinicEntities1())
            {  
                    appointment obj = new appointment()
                    {
                        physicianFk = model.physicianFk,
                        patientFk = ID,
                        AppDate = model.AppDate,
                        AppCriticality = model.AppCriticality,
                        AppReason = model.AppReason,

                    };
                    context.appointments.Add(obj);
                    context.SaveChanges();
                
            }
            return RedirectToAction("GetDetailsPatient");
        }


    }
}