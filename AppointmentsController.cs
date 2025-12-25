using Microsoft.AspNetCore.Mvc;
using HealthcareAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareAppointmentSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        // Temporary in-memory data store (acts like a database)
        private static List<Appointment> appointments = new List<Appointment>
        {
            new Appointment
            {
                Id = 1,
                PatientName = "Ravi",
                DoctorName = "Dr. Kumar",
                AppointmentDate = DateTime.Today
            },
            new Appointment
            {
                Id = 2,
                PatientName = "Anita",
                DoctorName = "Dr. Mehta",
                AppointmentDate = DateTime.Today.AddDays(1)
            }
        };

        // GET: /Appointments
        [HttpGet]
        public IActionResult Index()
        {
            return View(appointments);
        }

        // GET: /Appointments/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            appointment.Id = appointments.Any() ? appointments.Max(a => a.Id) + 1 : 1;
            appointments.Add(appointment);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Appointments/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: /Appointments/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            var existing = appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.PatientName = appointment.PatientName;
            existing.DoctorName = appointment.DoctorName;
            existing.AppointmentDate = appointment.AppointmentDate;

            return RedirectToAction(nameof(Index));
        }

        // GET: /Appointments/Delete/1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointment = appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                appointments.Remove(appointment);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}




