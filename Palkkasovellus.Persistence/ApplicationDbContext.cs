﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Palkkasovellus.Entity;

namespace Palkkasovellus.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Maksuhistoria> Maksuhistoriat { get; set; }
        public DbSet<Henkilo> Henkilot { get; set; }
        public DbSet<Verovuosi> Verov { get; set; }
    }
}
