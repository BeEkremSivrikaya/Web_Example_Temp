using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Example_Temp.Models;

namespace Web_Example_Temp.Controllers
{
    public class OkulController : Controller
    {

        AppDbContext _context;
        public OkulController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var okullar = await _context.Okullar.Include(o => o.Öğrenciler).ToListAsync();
            return View(okullar);
        }

        [HttpGet]
        public IActionResult Okul_Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Okul_Ekle(Okul okul)
        {
            try
            {
                await _context.Okullar.AddAsync(okul);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Veri tabanına ekleme sırasında bir hata oluştu.");
                return View(okul);
            }
        }

        public async Task<IActionResult> Okul_Sil(int id)
        {
            var okul = await _context.Okullar.FindAsync(id);
            _context.Okullar.Remove(okul);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Okul_Güncelle(int id)
        {
            var okul = await _context.Okullar.FindAsync(id);

            return View(okul);
        }
        [HttpPost]
        public async Task<IActionResult> Okul_Güncelle(Okul okul)
        {
            _context.Okullar.Update(okul);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
