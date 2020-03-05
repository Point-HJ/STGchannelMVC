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
    public class SelectionsAPIController : ApiController
    {
        private STGchannelEntities db = new STGchannelEntities();

        // GET: api/SelectionsAPI
        public IQueryable<Selection> GetSelection()
        {
            return db.Selection;
        }

        // GET: api/SelectionsAPI/5
        [ResponseType(typeof(Selection))]
        public IHttpActionResult GetSelection(int id)
        {
            Selection selection = db.Selection.Find(id);
            if (selection == null)
            {
                return NotFound();
            }

            return Ok(selection);
        }

        // PUT: api/SelectionsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSelection(int id, Selection selection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selection.BookID)
            {
                return BadRequest();
            }

            db.Entry(selection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectionExists(id))
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

        // POST: api/SelectionsAPI
        [ResponseType(typeof(Selection))]
        public IHttpActionResult PostSelection(Selection selection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Selection.Add(selection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = selection.BookID }, selection);
        }

        // DELETE: api/SelectionsAPI/5
        [ResponseType(typeof(Selection))]
        public IHttpActionResult DeleteSelection(int id)
        {
            Selection selection = db.Selection.Find(id);
            if (selection == null)
            {
                return NotFound();
            }

            db.Selection.Remove(selection);
            db.SaveChanges();

            return Ok(selection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SelectionExists(int id)
        {
            return db.Selection.Count(e => e.BookID == id) > 0;
        }
    }
}