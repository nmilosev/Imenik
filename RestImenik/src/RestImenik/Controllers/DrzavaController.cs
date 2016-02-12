using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestImenik
{
    [Route("api/drzava")]
    public class DrzavaController : Controller
    {
        private ImenikDbContext db;

        public DrzavaController(ImenikDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Drzava> GetAll()
        {
            return db.Drzava.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = db.Drzava.Where(d => d.Id == id).SingleOrDefault();
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var drzava = db.Drzava.Where(d => d.Id == id).SingleOrDefault();
            if (drzava == null)
            {
                return HttpNotFound();
            }
            db.Drzava.Remove(drzava);
            db.SaveChanges();
            return new HttpOkResult();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Drzava item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            db.Drzava.Add(item);
            db.SaveChanges();
            return new ObjectResult(item);
        }

    }
}

