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
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class TruckContainersController : ApiController
    {
        private PrototypeEntities db = new PrototypeEntities();

        // GET: api/TruckContainers
        public IQueryable<TruckContainer> GetTruckContainers()
        {
            return db.TruckContainers;
        }

        // GET: api/TruckContainers/5
        [ResponseType(typeof(TruckContainer))]
        public IHttpActionResult GetTruckContainer(int id)
        {
            TruckContainer truckContainer = db.TruckContainers.Find(id);
            if (truckContainer == null)
            {
                return NotFound();
            }

            return Ok(truckContainer);
        }

        // PUT: api/TruckContainers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTruckContainer(int id, TruckContainer truckContainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != truckContainer.id)
            {
                return BadRequest();
            }

            db.Entry(truckContainer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckContainerExists(id))
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

        // POST: api/TruckContainers
        [ResponseType(typeof(TruckContainer))]
        public IHttpActionResult PostTruckContainer(TruckContainer truckContainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TruckContainers.Add(truckContainer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = truckContainer.id }, truckContainer);
        }

        // DELETE: api/TruckContainers/5
        [ResponseType(typeof(TruckContainer))]
        public IHttpActionResult DeleteTruckContainer(int id)
        {
            TruckContainer truckContainer = db.TruckContainers.Find(id);
            if (truckContainer == null)
            {
                return NotFound();
            }

            db.TruckContainers.Remove(truckContainer);
            db.SaveChanges();

            return Ok(truckContainer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TruckContainerExists(int id)
        {
            return db.TruckContainers.Count(e => e.id == id) > 0;
        }
    }
}