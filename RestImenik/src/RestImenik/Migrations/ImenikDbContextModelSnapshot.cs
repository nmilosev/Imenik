using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using RestImenik;

namespace RestImenik.Migrations
{
    [DbContext(typeof(ImenikDbContext))]
    partial class ImenikDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestImenik.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<int>("KontaktId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Grupa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Im", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IMKontaktPodatak");

                    b.Property<int>("ImTipId");

                    b.Property<int>("KontaktId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.ImTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Kontakt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beleska");

                    b.Property<string>("Broj");

                    b.Property<int>("DrzavaId");

                    b.Property<int>("GrupaId");

                    b.Property<string>("Ime");

                    b.Property<string>("Jmbg");

                    b.Property<int>("KorisnikId");

                    b.Property<int>("MestoId");

                    b.Property<string>("Nadimak");

                    b.Property<string>("Prezime");

                    b.Property<string>("Ulica");

                    b.Property<string>("WebSajt");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Guid");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Mesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Telefon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Broj");

                    b.Property<int>("KontaktId");

                    b.Property<int>("TelefonTipId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.TelefonTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("RestImenik.Email", b =>
                {
                    b.HasOne("RestImenik.Kontakt")
                        .WithMany()
                        .HasForeignKey("KontaktId");
                });

            modelBuilder.Entity("RestImenik.Im", b =>
                {
                    b.HasOne("RestImenik.ImTip")
                        .WithMany()
                        .HasForeignKey("ImTipId");

                    b.HasOne("RestImenik.Kontakt")
                        .WithMany()
                        .HasForeignKey("KontaktId");
                });

            modelBuilder.Entity("RestImenik.Kontakt", b =>
                {
                    b.HasOne("RestImenik.Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId");

                    b.HasOne("RestImenik.Grupa")
                        .WithMany()
                        .HasForeignKey("GrupaId");

                    b.HasOne("RestImenik.Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.HasOne("RestImenik.Mesto")
                        .WithMany()
                        .HasForeignKey("MestoId");
                });

            modelBuilder.Entity("RestImenik.Telefon", b =>
                {
                    b.HasOne("RestImenik.Kontakt")
                        .WithMany()
                        .HasForeignKey("KontaktId");

                    b.HasOne("RestImenik.TelefonTip")
                        .WithMany()
                        .HasForeignKey("TelefonTipId");
                });
        }
    }
}
