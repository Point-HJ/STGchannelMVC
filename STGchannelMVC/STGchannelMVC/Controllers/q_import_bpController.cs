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
    public class q_import_bpController : ApiController
    {
        private Test_jvspkkEntities db = new Test_jvspkkEntities();

        // GET: api/q_import_bp
        public IQueryable<q_import_bp> Getq_import_bp()
        {
            return db.q_import_bp;
        }

        // GET: api/q_import_bp/5
        [ResponseType(typeof(q_import_bp))]
        public IHttpActionResult Getq_import_bp(short id)
        {
            q_import_bp q_import_bp = db.q_import_bp.Find(id);
            if (q_import_bp == null)
            {
                return NotFound();
            }

            return Ok(q_import_bp);
        }

        // PUT: api/q_import_bp/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putq_import_bp(short id, q_import_bp q_import_bp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != q_import_bp.foretagkod)
            {
                return BadRequest();
            }

            db.Entry(q_import_bp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!q_import_bpExists(id))
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

        // POST: api/q_import_bp
        [ResponseType(typeof(q_import_bp))]
        public IHttpActionResult Postq_import_bp(q_import_bp q_import_bp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.q_import_bp.Add(q_import_bp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (q_import_bpExists(q_import_bp.foretagkod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = q_import_bp.foretagkod }, q_import_bp);
        }

        // DELETE: api/q_import_bp/5
        [ResponseType(typeof(q_import_bp))]
        public IHttpActionResult Deleteq_import_bp(short id)
        {
            q_import_bp q_import_bp = db.q_import_bp.Find(id);
            if (q_import_bp == null)
            {
                return NotFound();
            }

            db.q_import_bp.Remove(q_import_bp);
            db.SaveChanges();

            return Ok(q_import_bp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool q_import_bpExists(short id)
        {
            return db.q_import_bp.Count(e => e.foretagkod == id) > 0;
        }
    }
}