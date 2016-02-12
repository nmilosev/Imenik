using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace RestImenik
{
    
    public class ImenikDbContext : DbContext
    {
        public DbSet<Kontakt> Kontakt {get; set;}

        public DbSet<Korisnik> Korisnik {get; set;}

        public DbSet<Telefon> Telefon {get; set;}
        public DbSet<Email> Email {get; set;}
        public DbSet<Im> IMs {get; set;}

        public DbSet<Drzava> Drzava {get; set;}
        public DbSet<Grupa> Grupa {get; set;}
        public DbSet<ImTip> IMTip {get; set;}
        public DbSet<Mesto> Mesto {get; set;}
        public DbSet<TelefonTip> TelefonTip {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }




}

