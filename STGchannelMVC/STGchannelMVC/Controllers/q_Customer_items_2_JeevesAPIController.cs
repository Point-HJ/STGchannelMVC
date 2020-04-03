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
    public class q_Customer_items_2_JeevesAPIController : ApiController
    {
        private ProductEntities db = new ProductEntities();

        // GET: api/q_Customer_items_2_JeevesAPI
        public IQueryable<q_Customer_items_2_Jeeves> Getq_Customer_items_2_Jeeves()
        {
            return db.q_Customer_items_2_Jeeves;
        }

        // GET: api/q_Customer_items_2_JeevesAPI/5
        [ResponseType(typeof(q_Customer_items_2_Jeeves))]
        public IHttpActionResult Getq_Customer_items_2_Jeeves(int id)
        {
            q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves = db.q_Customer_items_2_Jeeves.Find(id);
            if (q_Customer_items_2_Jeeves == null)
            {
                return NotFound();
            }

            return Ok(q_Customer_items_2_Jeeves);
        }

        // PUT: api/q_Customer_items_2_JeevesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putq_Customer_items_2_Jeeves(int id, q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != q_Customer_items_2_Jeeves.id)
            {
                return BadRequest();
            }

            db.Entry(q_Customer_items_2_Jeeves).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!q_Customer_items_2_JeevesExists(id))
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

        // POST: api/q_Customer_items_2_JeevesAPI
        [ResponseType(typeof(q_Customer_items_2_Jeeves))]
        public IHttpActionResult Postq_Customer_items_2_Jeeves(q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.q_Customer_items_2_Jeeves.Add(q_Customer_items_2_Jeeves);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = q_Customer_items_2_Jeeves.id }, q_Customer_items_2_Jeeves);
        }

        // DELETE: api/q_Customer_items_2_JeevesAPI/5
        [ResponseType(typeof(q_Customer_items_2_Jeeves))]
        public IHttpActionResult Deleteq_Customer_items_2_Jeeves(int id)
        {
            q_Customer_items_2_Jeeves q_Customer_items_2_Jeeves = db.q_Customer_items_2_Jeeves.Find(id);
            if (q_Customer_items_2_Jeeves == null)
            {
                return NotFound();
            }

            db.q_Customer_items_2_Jeeves.Remove(q_Customer_items_2_Jeeves);
            db.SaveChanges();

            return Ok(q_Customer_items_2_Jeeves);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool q_Customer_items_2_JeevesExists(int id)
        {
            return db.q_Customer_items_2_Jeeves.Count(e => e.id == id) > 0;
        }
    }
}