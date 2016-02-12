using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestImenik
{
    [Route("api/telefontip")]
    public class TelefonTipController : Controller
    {
        private ImenikDbContext db;

        public TelefonTipController(ImenikDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<TelefonTip> GetAll()
        {
            return db.TelefonTip.ToList();
        }
    }
}