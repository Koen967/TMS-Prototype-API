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
    public class ContainersController : ApiController
    {
        private PrototypeEntities db = new PrototypeEntities();

        // GET: api/Containers
        public IQueryable<Container> GetContainers()
        {
            return db.Containers;
        }

        // GET: api/Containers/5
        [ResponseType(typeof(Container))]
        public IHttpActionResult GetContainer(int id)
        {
            Container container = db.Containers.Find(id);
            if (container == null)
            {
                return NotFound();
            }

            return Ok(container);
        }

        // PUT: api/Containers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContainer(int id, Container container)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != container.id)
            {
                return BadRequest();
            }

            db.Entry(container).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
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

        // POST: api/Containers
        [ResponseType(typeof(Container))]
        public IHttpActionResult PostContainer(Container container)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Containers.Add(container);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = container.id }, container);
        }

        // DELETE: api/Containers/5
        [ResponseType(typeof(Container))]
        public IHttpActionResult DeleteContainer(int id)
        {
            Container container = db.Containers.Find(id);
            if (container == null)
            {
                return NotFound();
            }

            db.Containers.Remove(container);
            db.SaveChanges();

            return Ok(container);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContainerExists(int id)
        {
            return db.Containers.Count(e => e.id == id) > 0;
        }
    }
}