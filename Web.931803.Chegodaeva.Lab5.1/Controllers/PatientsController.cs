using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web._931803.Chegodaeva.Lab5._1.Models; 

namespace Web._931803.Chegodaeva.Lab5._1.Controllers
{
    public class PatientsController : Controller
    {
        private readonly AppContext _context;
        public PatientsController(AppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Patient());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient model)
        {
            if (!ModelState.IsValid) return View(model);
            await _context.Patients.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _context.Patients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(m => m.Id == id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _context.Patients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Patient model)
        {
            var patient = await _context.Patients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(model);
            patient.Name = model.Name;
            patient.Diagnosis = model.Diagnosis;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var patient = await _context.Patients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }
    }
}
