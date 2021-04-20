﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<GuzelSoz> GuzelSozler { get; set; }
    }
}