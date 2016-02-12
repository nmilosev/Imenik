using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestImenik
{
    [Route("api/imtip")]
    public class IMTipController : Controller
    {
        private ImenikDbContext db;

        public IMTipController(ImenikDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<ImTip> GetAll()
        {
            return db.IMTip.ToList();
        }
    }
}

