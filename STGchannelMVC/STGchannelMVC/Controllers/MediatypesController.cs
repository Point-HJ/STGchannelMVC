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
    public class MediatypesController : ApiController
    {
        private ProductEntities db = new ProductEntities();

        // GET: api/Mediatypes
        public IQueryable<xakh> Getxakh()
        {
            return db.xakh;
        }

        // GET: api/Mediatypes/5
        [ResponseType(typeof(xakh))]
        public IHttpActionResult Getxakh(string id)
        {
            xakh xakh = db.xakh.Find(id);
            if (xakh == null)
            {
                return NotFound();
            }

            return Ok(xakh);
        }

        // PUT: api/Mediatypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putxakh(string id, xakh xakh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xakh.ArtKat)
            {
                return BadRequest();
            }

            db.Entry(xakh).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!xakhExists(id))
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

        // POST: api/Mediatypes
        [ResponseType(typeof(xakh))]
        public IHttpActionResult Postxakh(xakh xakh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.xakh.Add(xakh);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (xakhExists(xakh.ArtKat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = xakh.ArtKat }, xakh);
        }

        // DELETE: api/Mediatypes/5
        [ResponseType(typeof(xakh))]
        public IHttpActionResult Deletexakh(string id)
        {
            xakh xakh = db.xakh.Find(id);
            if (xakh == null)
            {
                return NotFound();
            }

            db.xakh.Remove(xakh);
            db.SaveChanges();

            return Ok(xakh);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool xakhExists(string id)
        {
            return db.xakh.Count(e => e.ArtKat == id) > 0;
        }
    }
}