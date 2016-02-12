using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestImenik
{
    
    public class KorisnikController : Controller
    {
        private ImenikDbContext db;

        public KorisnikController(ImenikDbContext db) {
            this.db = db;
        }

        [Route("api/login")]
        [HttpPost]
        public IActionResult Login([FromBody] Korisnik login)
        {
            var korisnik = db.Korisnik.Where(k => k.Username == login.Username && k.Password == login.Password).SingleOrDefault();
            if (korisnik == null) 
            {
                Response.StatusCode = 401; //401 - unauthorized
                return null;
            } 
            else 
            {
                korisnik.Guid = Guid.NewGuid().ToString();
                db.SaveChanges();
                return new HttpOkObjectResult(korisnik);
            }
        }      

        [Route("api/logout")]
        [HttpPost]
        public IActionResult Logout(string guid)
        {
            var korisnik = db.Korisnik.Where(k => k.Guid == guid).SingleOrDefault();
            if (korisnik == null) 
            {
                Response.StatusCode = 401; //401 - unauthorized
                return null;
            } 
            else 
            {
                korisnik.Guid = string.Empty;
                db.SaveChanges();
                return new HttpOkResult();
            }
        }  

        [Route("api/register")]
        [HttpPost]
        public IActionResult Logout([FromBody] Korisnik k)
        {
            if (k == null)
            {
                return HttpBadRequest();
            }
            db.Korisnik.Add(k);
            db.SaveChanges();
            return new HttpOkResult();
        }  

    }
}

