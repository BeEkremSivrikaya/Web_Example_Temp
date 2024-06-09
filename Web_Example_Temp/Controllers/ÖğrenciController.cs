using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Example_Temp.Models;

namespace Web_Example_Temp.Controllers
{
    public class ÖğrenciController : Controller
    {
        AppDbContext _context;
        public ÖğrenciController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var öğrenciler = await _context.Öğrenciler.Include(ö => ö.Okul).ToListAsync();
            return View(öğrenciler);
        }

        [HttpGet]
        public async Task<IActionResult> Öğrenci_Ekle()
        {
            var okullar = await _context.Okullar.ToListAsync();
            ViewBag.Okullar = new SelectList(okullar, "Id", "Ad");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Öğrenci_Ekle(Öğrenci öğrenci)
        {
            try
            {
                await _context.Öğrenciler.AddAsync(öğrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Veri tabanına ekleme sırasında bir hata oluştu.");
                return View(öğrenci);
            }
        }

        public async Task<IActionResult> Öğrenci_Sil(int id)
        {
            var öğrenci = await _context.Öğrenciler.FindAsync(id);
             _context.Öğrenciler.Remove(öğrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Öğrenci_Güncelle(int id)
        {
            var okullar = await _context.Öğrenciler.FindAsync(id);
    
            return View(okullar);
        }
        [HttpPost]  
        public async Task<IActionResult> Öğrenci_Güncelle(Öğrenci öğrenci)
        {
             _context.Öğrenciler.Update(öğrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
