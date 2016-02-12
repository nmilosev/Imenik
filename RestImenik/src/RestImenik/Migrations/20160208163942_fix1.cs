using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace RestImenik.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Email_Kontakt_KontaktId", table: "Email");
            migrationBuilder.DropForeignKey(name: "FK_Im_ImTip_ImTipId", table: "Im");
            migrationBuilder.DropForeignKey(name: "FK_Im_Korisnik_KorisnikId", table: "Im");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Drzava_DrzavaId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Grupa_GrupaId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Korisnik_KorisnikId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Mesto_MestoId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Telefon_Kontakt_KontaktId", table: "Telefon");
            migrationBuilder.DropForeignKey(name: "FK_Telefon_TelefonTip_TipId", table: "Telefon");
            migrationBuilder.DropColumn(name: "TipId", table: "Telefon");
            migrationBuilder.AddColumn<int>(
                name: "TelefonTipId",
                table: "Telefon",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Email_Kontakt_KontaktId",
                table: "Email",
                column: "KontaktId",
                principalTable: "Kontakt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Im_ImTip_ImTipId",
                table: "Im",
                column: "ImTipId",
                principalTable: "ImTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Im_Korisnik_KorisnikId",
                table: "Im",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Drzava_DrzavaId",
                table: "Kontakt",
                column: "DrzavaId",
                principalTable: "Drzava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Grupa_GrupaId",
                table: "Kontakt",
                column: "GrupaId",
                principalTable: "Grupa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Korisnik_KorisnikId",
                table: "Kontakt",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Mesto_MestoId",
                table: "Kontakt",
                column: "MestoId",
                principalTable: "Mesto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_Kontakt_KontaktId",
                table: "Telefon",
                column: "KontaktId",
                principalTable: "Kontakt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_TelefonTip_TelefonTipId",
                table: "Telefon",
                column: "TelefonTipId",
                principalTable: "TelefonTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Email_Kontakt_KontaktId", table: "Email");
            migrationBuilder.DropForeignKey(name: "FK_Im_ImTip_ImTipId", table: "Im");
            migrationBuilder.DropForeignKey(name: "FK_Im_Korisnik_KorisnikId", table: "Im");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Drzava_DrzavaId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Grupa_GrupaId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Korisnik_KorisnikId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Kontakt_Mesto_MestoId", table: "Kontakt");
            migrationBuilder.DropForeignKey(name: "FK_Telefon_Kontakt_KontaktId", table: "Telefon");
            migrationBuilder.DropForeignKey(name: "FK_Telefon_TelefonTip_TelefonTipId", table: "Telefon");
            migrationBuilder.DropColumn(name: "TelefonTipId", table: "Telefon");
            migrationBuilder.AddColumn<int>(
                name: "TipId",
                table: "Telefon",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Email_Kontakt_KontaktId",
                table: "Email",
                column: "KontaktId",
                principalTable: "Kontakt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Im_ImTip_ImTipId",
                table: "Im",
                column: "ImTipId",
                principalTable: "ImTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Im_Korisnik_KorisnikId",
                table: "Im",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Drzava_DrzavaId",
                table: "Kontakt",
                column: "DrzavaId",
                principalTable: "Drzava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Grupa_GrupaId",
                table: "Kontakt",
                column: "GrupaId",
                principalTable: "Grupa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Korisnik_KorisnikId",
                table: "Kontakt",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Kontakt_Mesto_MestoId",
                table: "Kontakt",
                column: "MestoId",
                principalTable: "Mesto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_Kontakt_KontaktId",
                table: "Telefon",
                column: "KontaktId",
                principalTable: "Kontakt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_TelefonTip_TipId",
                table: "Telefon",
                column: "TipId",
                principalTable: "TelefonTip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
