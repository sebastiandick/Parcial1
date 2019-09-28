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
using Dick.Models;

namespace Dick.Controllers
{
    public class ClownsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Clowns
        public IQueryable<Clown> GetClowns()
        {
            return db.Clowns;
        }

        // GET: api/Clowns/5
        [ResponseType(typeof(Clown))]
        public IHttpActionResult GetClown(int id)
        {
            Clown clown = db.Clowns.Find(id);
            if (clown == null)
            {
                return NotFound();
            }

            return Ok(clown);
        }

        // PUT: api/Clowns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClown(int id, Clown clown)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clown.ClownID)
            {
                return BadRequest();
            }

            db.Entry(clown).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClownExists(id))
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

        // POST: api/Clowns
        [ResponseType(typeof(Clown))]
        public IHttpActionResult PostClown(Clown clown)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clowns.Add(clown);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clown.ClownID }, clown);
        }

        // DELETE: api/Clowns/5
        [ResponseType(typeof(Clown))]
        public IHttpActionResult DeleteClown(int id)
        {
            Clown clown = db.Clowns.Find(id);
            if (clown == null)
            {
                return NotFound();
            }

            db.Clowns.Remove(clown);
            db.SaveChanges();

            return Ok(clown);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClownExists(int id)
        {
            return db.Clowns.Count(e => e.ClownID == id) > 0;
        }
    }
}