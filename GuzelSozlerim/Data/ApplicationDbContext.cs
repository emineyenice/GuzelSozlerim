using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuzelSozlerim.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    //kullanici klasını kullanan IdentityDbContext oluşturmuş olduk
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //composite primery key oluşturduk
            builder.Entity<KullaniciSoz>().HasKey(x => new { x.KullaniciId, x.GuzelSozId });
            //builder.Entity<KullaniciSoz>().HasKey("KullaniciId", "GuzelSozId");
            base.OnModelCreating(builder);
        }
        public DbSet<GuzelSoz> GuzelSozler { get; set; }
        public DbSet<KullaniciSoz> KullaniciSozler { get; set; }
    }
}
