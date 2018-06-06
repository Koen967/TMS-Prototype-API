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
    public class TruckLocationsController : ApiController
    {
        private PrototypeEntities db = new PrototypeEntities();

        // GET: api/TruckLocations
        public IQueryable<TruckLocation> GetTruckLocations()
        {
            return db.TruckLocations;
        }

        // GET: api/TruckLocations/5
        [ResponseType(typeof(TruckLocation))]
        public IHttpActionResult GetTruckLocation(int id)
        {
            TruckLocation truckLocation = db.TruckLocations.Find(id);
            if (truckLocation == null)
            {
                return NotFound();
            }

            return Ok(truckLocation);
        }

        // PUT: api/TruckLocations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTruckLocation(int id, TruckLocation truckLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != truckLocation.id)
            {
                return BadRequest();
            }

            db.Entry(truckLocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckLocationExists(id))
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

        // POST: api/TruckLocations
        [ResponseType(typeof(TruckLocation))]
        public IHttpActionResult PostTruckLocation(TruckLocation truckLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TruckLocations.Add(truckLocation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = truckLocation.id }, truckLocation);
        }

        // DELETE: api/TruckLocations/5
        [ResponseType(typeof(TruckLocation))]
        public IHttpActionResult DeleteTruckLocation(int id)
        {
            TruckLocation truckLocation = db.TruckLocations.Find(id);
            if (truckLocation == null)
            {
                return NotFound();
            }

            db.TruckLocations.Remove(truckLocation);
            db.SaveChanges();

            return Ok(truckLocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TruckLocationExists(int id)
        {
            return db.TruckLocations.Count(e => e.id == id) > 0;
        }
    }
}