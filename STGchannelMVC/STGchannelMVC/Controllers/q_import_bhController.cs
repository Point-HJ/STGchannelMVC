using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using STGchannelMVC.Models;

namespace STGchannelMVC.Controllers
{
    public class q_import_bhController : ApiController
    {
        private Test_jvspkkEntities db = new Test_jvspkkEntities();

        // GET: api/q_import_bh
        public IQueryable<q_import_bh> Getq_import_bh()
        {
            return db.q_import_bh;
        }

        // GET: api/q_import_bh/5
        [ResponseType(typeof(q_import_bh))]
        public IHttpActionResult Getq_import_bh(short id)
        {
            q_import_bh q_import_bh = db.q_import_bh.Find(id);
            if (q_import_bh == null)
            {
                return NotFound();
            }

            return Ok(q_import_bh);
        }

        // PUT: api/q_import_bh/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putq_import_bh(short id, q_import_bh q_import_bh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != q_import_bh.foretagkod)
            {
                return BadRequest();
            }

            db.Entry(q_import_bh).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!q_import_bhExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/q_import_bh
        [ResponseType(typeof(q_import_bh))]
        public IHttpActionResult Postq_import_bh(q_import_bh q_import_bh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.q_import_bh.Add(q_import_bh);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (q_import_bhExists(q_import_bh.foretagkod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = q_import_bh.foretagkod }, q_import_bh);
        }

        // DELETE: api/q_import_bh/5
        [ResponseType(typeof(q_import_bh))]
        public IHttpActionResult Deleteq_import_bh(short id)
        {
            q_import_bh q_import_bh = db.q_import_bh.Find(id);
            if (q_import_bh == null)
            {
                return NotFound();
            }

            db.q_import_bh.Remove(q_import_bh);
            db.SaveChanges();

            return Ok(q_import_bh);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool q_import_bhExists(short id)
        {
            return db.q_import_bh.Count(e => e.foretagkod == id) > 0;
        }
    }
}