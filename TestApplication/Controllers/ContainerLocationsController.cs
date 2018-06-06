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
    public class ContainerLocationsController : ApiController
    {
        private PrototypeEntities db = new PrototypeEntities();

        // GET: api/ContainerLocations
        public IQueryable<ContainerLocation> GetContainerLocations()
        {
            return db.ContainerLocations;
        }

        // GET: api/ContainerLocations/5
        [ResponseType(typeof(ContainerLocation))]
        public IHttpActionResult GetContainerLocation(int id)
        {
            ContainerLocation containerLocation = db.ContainerLocations.Find(id);
            if (containerLocation == null)
            {
                return NotFound();
            }

            return Ok(containerLocation);
        }

        // PUT: api/ContainerLocations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContainerLocation(int id, ContainerLocation containerLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != containerLocation.id)
            {
                return BadRequest();
            }

            db.Entry(containerLocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerLocationExists(id))
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

        // POST: api/ContainerLocations
        [ResponseType(typeof(ContainerLocation))]
        public IHttpActionResult PostContainerLocation(ContainerLocation containerLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContainerLocations.Add(containerLocation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = containerLocation.id }, containerLocation);
        }

        // DELETE: api/ContainerLocations/5
        [ResponseType(typeof(ContainerLocation))]
        public IHttpActionResult DeleteContainerLocation(int id)
        {
            ContainerLocation containerLocation = db.ContainerLocations.Find(id);
            if (containerLocation == null)
            {
                return NotFound();
            }

            db.ContainerLocations.Remove(containerLocation);
            db.SaveChanges();

            return Ok(containerLocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContainerLocationExists(int id)
        {
            return db.ContainerLocations.Count(e => e.id == id) > 0;
        }
    }
}