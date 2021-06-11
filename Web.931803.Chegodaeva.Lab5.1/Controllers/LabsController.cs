using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web._931803.Chegodaeva.Lab5._1.Models; 

namespace Web._931803.Chegodaeva.Lab5._1.Controllers
{
    public class LabsController : Controller
    {
        private readonly AppContext _context;
        public LabsController(AppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Labs.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Lab());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lab model)
        {
            if (!ModelState.IsValid) return View(model);
            await _context.Labs.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lab = await _context.Labs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Labs.Remove(lab);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Lab model)
        {
            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(model);
            lab.Name = model.Name;
            lab.Address = model.Address;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }
    }
}
