using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Major_Project_Doctor.Data;
using Major_Project_Doctor.Models;
using Microsoft.AspNetCore.Authorization;

namespace Major_Project_Doctor.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly Major_Project_DoctorContext _context;

        public AppointmentsController(Major_Project_DoctorContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var major_Project_DoctorContext = _context.Appointment.Include(a => a.Location).Include(a => a.Patient).Include(a => a.Specialist).Include(a => a.Staff);
            return View(await major_Project_DoctorContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Location)
                .Include(a => a.Patient)
                .Include(a => a.Specialist)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        [Authorize]
        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id");
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id");
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,StaffId,LocationId,SpecialistId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", appointment.LocationId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id", appointment.SpecialistId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", appointment.StaffId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", appointment.LocationId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id", appointment.SpecialistId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", appointment.StaffId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,StaffId,LocationId,SpecialistId")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", appointment.LocationId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id", appointment.SpecialistId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", appointment.StaffId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Location)
                .Include(a => a.Patient)
                .Include(a => a.Specialist)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
