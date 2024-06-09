using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Example_Temp.Models;

namespace Web_Example_Temp.Controllers
{
    public class VeliController : Controller
    {
        AppDbContext _context;
        public VeliController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var veliler = await _context.Veliler.ToListAsync();
            return View(veliler);
        }

        [HttpGet]
        public IActionResult Veli_Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Veli_Ekle(Veli veli)
        {
            try
            {
                await _context.Veliler.AddAsync(veli);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Veri tabanına ekleme sırasında bir hata oluştu.");
                return View(veli);
            }
        }

        public async Task<IActionResult> Veli_Sil(int id)
        {
            var veli = await _context.Veliler.FindAsync(id);
            _context.Veliler.Remove(veli);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Veli_Güncelle(int id)
        {
            var veli = await _context.Veliler.FindAsync(id);

            return View(veli);
        }
        [HttpPost]
        public async Task<IActionResult> Veli_Güncelle(Veli veli)
        {
            _context.Veliler.Update(veli);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
