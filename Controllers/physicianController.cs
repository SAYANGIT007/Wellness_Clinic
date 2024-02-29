using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using System.Net;
using System.Data.Entity.Validation;
using System.Data.Entity.Core.Metadata.Edm;
using CinicAutomation.Models;
using System.Reflection;

namespace ClinicAutimation.Controllers
{
    public class DoctorController : Controller
    {

        Models.MyclinicEntities db = new Models.MyclinicEntities();
        public ActionResult Index(int? doctorId)
        {

            if (doctorId == null)
            {
                return View("EnterDoctorId");
            }
            List<AppointmentViewModel> appointments = db.Appointments
                .Where(a => a.appointmentPhysicianID == doctorId)
                .Select(a => new AppointmentViewModel
                {
                    AppointmentID = a.appointmentID,
                    PatientID = a.appointmentPatientID,
                    PhysicianID = a.appointmentPhysicianID,
                    AppointmentDateTime = a.appointmentDateTime,
                    Reason = a.appointmentReason,
                    Status = a.appointmentStatus,
                    Criticality = a.appointmentCriticality
                })
                .ToList();

            return View(appointments);
        }

        public ActionResult AddPrescription(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            Patient patient = db.Patients.Find(appointment.appointmentPatientID);
            if (patient == null)
            {
                return HttpNotFound();
            }

            PrescriptionViewModel viewModel = new PrescriptionViewModel
            {
                Appointment = appointment,
                Patient = patient
            };

            return View(viewModel);
        }

        public ActionResult SavePrescription(PrescriptionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var prescription = new PhysicianPrescription
                    {
                        PhysicianPrescriptionDescription = viewModel.Prescription.PhysicianPrescriptionDescription,
                        Drug = db.Drugs.Find(viewModel.Prescription.PhysicianPrescriptionDrugID),
                    };

                    db.PhysicianPrescriptions.Add(prescription);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "An error occurred while saving the prescription.");

                }
            }

            return View(viewModel);
        }

        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(prescsavemodel model)
        {
            using (var context = new MyclinicEntities())
            {
                PhysicianPrescription ob = new PhysicianPrescription()
                {

                    PhysicianPrescriptionScheduleID = model.PhysicianPrescriptionScheduleID,
                    PhysicianPrescriptionDrugID = model.PhysicianPrescriptionDrugID,
                    PhysicianPrescriptionDescription = model.PhysicianPrescriptionDescription

                };
                context.PhysicianPrescriptions.Add(ob);
                context.SaveChanges();

            }
            return View();


        }





    }
}