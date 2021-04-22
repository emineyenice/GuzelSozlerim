using GuzelSozlerim.Data;
using GuzelSozlerim.Extensions;
using GuzelSozlerim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GuzelSozlerim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_db.GuzelSozler.Include("Begenenler.Kullanici").ToList());
        }

        [Authorize]// Sadece üyeler kullanabilir
        [HttpPost]
        public IActionResult BegeniDurumunuGuncelle(int id, bool begenildiMi)
        {
            try
            {
                string userId = User.GetUserId();
               // Kullanici kul = _db.Users.Find(userId);
                var begeni = new KullaniciSoz() { GuzelSozId = id, KullaniciId = userId };

                if (begenildiMi)
                {
                    if (!_db.KullaniciSozler.Contains(begeni))
                    {
                        _db.KullaniciSozler.Add(begeni);
                    }
                }
                else
                {
                    if (_db.KullaniciSozler.Contains(begeni))
                    {
                        _db.KullaniciSozler.Remove(begeni);
                    }
                }
                //begeni durumu true gelirse ekle yoksa kaldır
                //_db.Entry(begeni).State = begenildiMi ? EntityState.Added : EntityState.Deleted;
                _db.SaveChanges();

                // bu değişiklikten sonra toplam beğeni sayısını döndürelim

                return new EmptyResult();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
