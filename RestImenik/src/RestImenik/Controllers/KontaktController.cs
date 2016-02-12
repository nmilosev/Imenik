using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Newtonsoft.Json;

namespace RestImenik
{
    [Route("api/kontakt")]
    public class KontaktController : Controller
    {
        private ImenikDbContext db;

        public KontaktController(ImenikDbContext db) 
        {
            this.db = db;
        }

        private Korisnik IsLoggedIn(string guid) 
        {
            Korisnik k;
            if (string.IsNullOrEmpty(guid) || (k = db.Korisnik.Where(kor => kor.Guid == guid).SingleOrDefault()) == null)
            {                
                return null;
            }
            return k;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, string guid)
        {
            if (IsLoggedIn(guid) == null)
            {
                Response.StatusCode = 401; //401 - unauthorized
                return null;
            }
            else
            {       
                var item = db.Kontakt
                .Include(osoba => osoba.Telefons)
                .Include(osoba => osoba.Mesto)
                .Include(osoba => osoba.Drzava)
                .Include(osoba => osoba.Emails)
                .Include(osoba => osoba.Grupa)
                .Include(osoba => osoba.Ims)
                .Include(osoba => osoba.Korisnik)
                    .Where(o => o.Id == id && o.Korisnik.Guid == guid).SingleOrDefault();

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    item.Telefons.ForEach(t => t.TelefonTip = db.TelefonTip.Single(tt => tt.Id == t.TelefonTipId));
                    item.Ims.ForEach(i => i.ImTip = db.IMTip.Single(imt => imt.Id == i.ImTipId));
                    return new ObjectResult(item);
                }
            }
        }

        [HttpGet]
        public IEnumerable<Kontakt> GetAll(string guid)
        {           
            Korisnik k = IsLoggedIn(guid);
            if (k == null)
            {
                Response.StatusCode = 401; //401 - unauthorized
                return null;
            }
            else
            {       
                //no eager load
                //https://github.com/aspnet/EntityFramework/issues/3797
                //https://github.com/aspnet/EntityFramework/issues/3176
                //http://data.uservoice.com/forums/72025-entity-framework-feature-suggestions/suggestions/2766643-provide-mechanism-to-statically-define-eager-loadi
                //explicit:
                var ret = db.Kontakt
                    .Include(osoba => osoba.Telefons)
                    .Include(osoba => osoba.Mesto)
                    .Include(osoba => osoba.Drzava)
                    .Include(osoba => osoba.Emails)
                    .Include(osoba => osoba.Grupa)
                    .Include(osoba => osoba.Ims)
                    .Where(o => o.Korisnik.Id == k.Id).ToList();          
                
                foreach (Kontakt kon in ret) {
                    kon.Telefons.ForEach(t => t.TelefonTip = db.TelefonTip.Single(tt => tt.Id == t.TelefonTipId));
                    kon.Ims.ForEach(i => i.ImTip = db.IMTip.Single(imt => imt.Id == i.ImTipId));
                }

                return ret;
            }
        }

        [Route("grupa")]
        [HttpGet]
        public IEnumerable<Kontakt> GetAllForGrupa(string guid, int grupaId)
        {           
            Korisnik k = IsLoggedIn(guid);
            if (k == null)
            {
                Response.StatusCode = 401; //401 - unauthorized
                return null;
            }
            else
            {       
                //no eager load
                //https://github.com/aspnet/EntityFramework/issues/3797
                //https://github.com/aspnet/EntityFramework/issues/3176
                //http://data.uservoice.com/forums/72025-entity-framework-feature-suggestions/suggestions/2766643-provide-mechanism-to-statically-define-eager-loadi
                //explicit:
                var ret = db.Kontakt
                    .Include(osoba => osoba.Telefons)
                    .Include(osoba => osoba.Mesto)
                    .Include(osoba => osoba.Drzava)
                    .Include(osoba => osoba.Emails)
                    .Include(osoba => osoba.Grupa)
                    .Include(osoba => osoba.Ims)
                    .Where(o => o.Korisnik.Id == k.Id && o.GrupaId == grupaId).ToList();          

                foreach (Kontakt kon in ret) {
                    kon.Telefons.ForEach(t => t.TelefonTip = db.TelefonTip.Single(tt => tt.Id == t.TelefonTipId));
                    kon.Ims.ForEach(i => i.ImTip = db.IMTip.Single(imt => imt.Id == i.ImTipId));
                }

                return ret;
            }
        }

        [Route("search")]
        [HttpGet]
        public IEnumerable<Kontakt> Search(string guid, string query)
        {           
            Korisnik k = IsLoggedIn(guid);
            if (k == null)
            {
                Response.StatusCode = 401; //401 - unauthorized
                return null;
            }
            else
            {       
                //no eager load
                //https://github.com/aspnet/EntityFramework/issues/3797
                //https://github.com/aspnet/EntityFramework/issues/3176
                //http://data.uservoice.com/forums/72025-entity-framework-feature-suggestions/suggestions/2766643-provide-mechanism-to-statically-define-eager-loadi
                //explicit:
                var ret = db.Kontakt
                    .Include(osoba => osoba.Telefons)
                    .Include(osoba => osoba.Mesto)
                    .Include(osoba => osoba.Drzava)
                    .Include(osoba => osoba.Emails)
                    .Include(osoba => osoba.Grupa)
                    .Include(osoba => osoba.Ims)
                    .Where(o => o.Korisnik.Id == k.Id)
                    .Where(o => o.Ime.Contains(query) || o.Prezime.Contains(query) || o.Nadimak.Contains(query)).ToList();          

                foreach (Kontakt kon in ret) {
                    kon.Telefons.ForEach(t => t.TelefonTip = db.TelefonTip.Single(tt => tt.Id == t.TelefonTipId));
                    kon.Ims.ForEach(i => i.ImTip = db.IMTip.Single(imt => imt.Id == i.ImTipId));
                }

                return ret;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string guid) {
            if (IsLoggedIn(guid) == null)
            {
                Response.StatusCode = 401; //401 - unauthorized
                return null;
            }
            else
            {       
                var o = db.Kontakt
                .Single(os => os.Id == id);
                
                db.Remove(o);

                db.SaveChanges();

                return new HttpOkResult();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Kontakt k)
        {
            if (k == null)
            {
                return HttpBadRequest();
            }

            db.Kontakt.Add(k);
            db.SaveChanges();
            return new HttpOkResult();
        }

        [HttpPut]
        public IActionResult Modify([FromBody] Kontakt k) {
            if (k == null)
            {
                return HttpBadRequest();
            }

            db.Kontakt.Update(k);
            db.SaveChanges();
            return new HttpOkResult();
        }     
    }
}