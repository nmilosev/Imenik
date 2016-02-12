using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestImenik
{
    [Route("api/grupa")]
    public class GrupaController : Controller
    {
        private ImenikDbContext db;

        public GrupaController(ImenikDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Grupa> GetAll()
        {
            return db.Grupa.ToList();
        }
    }
}