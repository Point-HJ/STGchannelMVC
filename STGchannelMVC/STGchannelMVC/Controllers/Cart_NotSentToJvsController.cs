using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using STGchannelMVC.Models;

namespace STGchannelMVC.Controllers
{
    public class Cart_NotSentToJvsController : ApiController
    {
        private STGchannelEntities db = new STGchannelEntities();

        // GET: api/Cart_NotSentToJvs
        public IQueryable<Cart_NotSentToJvs> GetCart_NotSentToJvs()
        {
            return db.Cart_NotSentToJvs;
        }

        // GET: api/Cart_NotSentToJvs/5
        [ResponseType(typeof(Cart_NotSentToJvs))]
        public async Task<IHttpActionResult> GetCart_NotSentToJvs(int id)
        {
            Cart_NotSentToJvs cart_NotSentToJvs = await db.Cart_NotSentToJvs.FindAsync(id);
            if (cart_NotSentToJvs == null)
            {
                return NotFound();
            }

            return Ok(cart_NotSentToJvs);
        }

        // PUT: api/Cart_NotSentToJvs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart_NotSentToJvs(int id, Cart_NotSentToJvs cart_NotSentToJvs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart_NotSentToJvs.OrderID)
            {
                return BadRequest();
            }

            db.Entry(cart_NotSentToJvs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cart_NotSentToJvsExists(id))
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

        // POST: api/Cart_NotSentToJvs
        [ResponseType(typeof(Cart_NotSentToJvs))]
        public async Task<IHttpActionResult> PostCart_NotSentToJvs(Cart_NotSentToJvs cart_NotSentToJvs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cart_NotSentToJvs.Add(cart_NotSentToJvs);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cart_NotSentToJvs.OrderID }, cart_NotSentToJvs);
        }

        // DELETE: api/Cart_NotSentToJvs/5
        [ResponseType(typeof(Cart_NotSentToJvs))]
        public async Task<IHttpActionResult> DeleteCart_NotSentToJvs(int id)
        {
            Cart_NotSentToJvs cart_NotSentToJvs = await db.Cart_NotSentToJvs.FindAsync(id);
            if (cart_NotSentToJvs == null)
            {
                return NotFound();
            }

            db.Cart_NotSentToJvs.Remove(cart_NotSentToJvs);
            await db.SaveChangesAsync();

            return Ok(cart_NotSentToJvs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cart_NotSentToJvsExists(int id)
        {
            return db.Cart_NotSentToJvs.Count(e => e.OrderID == id) > 0;
        }
    }
}