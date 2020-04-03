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
    public class q_material_groupController : ApiController
    {
        private ProductEntities db = new ProductEntities();

        // GET: api/q_material_group
        public IQueryable<q_material_group> Getq_material_group()
        {
            return db.q_material_group;
        }

        // GET: api/q_material_group/5
        [ResponseType(typeof(q_material_group))]
        public IHttpActionResult Getq_material_group(short id)
        {
            q_material_group q_material_group = db.q_material_group.Find(id);
            if (q_material_group == null)
            {
                return NotFound();
            }

            return Ok(q_material_group);
        }

        // PUT: api/q_material_group/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putq_material_group(short id, q_material_group q_material_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != q_material_group.ForetagKod)
            {
                return BadRequest();
            }

            db.Entry(q_material_group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!q_material_groupExists(id))
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

        // POST: api/q_material_group
        [ResponseType(typeof(q_material_group))]
        public IHttpActionResult Postq_material_group(q_material_group q_material_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.q_material_group.Add(q_material_group);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (q_material_groupExists(q_material_group.ForetagKod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = q_material_group.ForetagKod }, q_material_group);
        }

        // DELETE: api/q_material_group/5
        [ResponseType(typeof(q_material_group))]
        public IHttpActionResult Deleteq_material_group(short id)
        {
            q_material_group q_material_group = db.q_material_group.Find(id);
            if (q_material_group == null)
            {
                return NotFound();
            }

            db.q_material_group.Remove(q_material_group);
            db.SaveChanges();

            return Ok(q_material_group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool q_material_groupExists(short id)
        {
            return db.q_material_group.Count(e => e.ForetagKod == id) > 0;
        }
    }
}