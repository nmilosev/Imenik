using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestImenik
{
    [Route("api/mesto")]
    public class MestoController : Controller
    {
        private ImenikDbContext db;

        public MestoController(ImenikDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Mesto> GetAll()
        {
            return db.Mesto.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = db.Mesto.Where(m => m.Id == id).SingleOrDefault();
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mesto = db.Mesto.Where(m => m.Id == id).SingleOrDefault();
            if (mesto == null)
            {
                return HttpNotFound();
            }
            db.Mesto.Remove(mesto);
            db.SaveChanges();
            return new HttpOkResult();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Mesto item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            db.Mesto.Add(item);
            db.SaveChanges();
            return new ObjectResult(item);
        }

    }
}

