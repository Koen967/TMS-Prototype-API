using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class TrucksController : ApiController
    {
        private PrototypeEntities db = new PrototypeEntities();
        
        // GET: api/Trucks
        [ActionName("GetValues")]
        public IQueryable<Truck> GetTrucks()
        {
            return db.Trucks;
        }

        // GET: api/Trucks/5
        [ActionName("GetValues")]
        [ResponseType(typeof(Truck))]
        public IHttpActionResult GetTruck(int id)
        {
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        // GET: api/Trucks/1/20/sort/filter
        [ActionName("TableValues")]
        public IQueryable<Truck> GetTrucksWithParams(int limit = 25, int offset = 0, string order = null, string filter = null)
        {
            var result = db.Trucks.AsQueryable();

            // Filter the data
            if (!String.IsNullOrEmpty(filter) && filter != "null")
            {
                if(filter.EndsWith(","))
                {
                    filter = filter.Remove(filter.Length - 1);
                }
                var filters = filter.Split(',');
                foreach (string fullFilter in filters)
                {
                    var filterParts = fullFilter.Split(' ');
                    var filterName = filterParts[0];
                    var filterOperator = WebUtility.UrlDecode(filterParts[1]);
                    var filterValue = filterParts[2];

                    if (filterOperator.Equals("contains"))
                    {
                        result = result.Where(filterName + ".Contains(@0)", filterValue);
                    }
                    else
                    {
                        result = result.Where(filterName + ' ' + filterOperator + ' ' + filterValue);
                    }
                }
            }

            var totalRows = result.Count();

            // Order the data
            if (!String.IsNullOrEmpty(order) && order != "null")
            {
                result = result.OrderBy(order);
            } else
            {
                result = result.OrderBy(x => x.id);
            }

            // Take the data for a page
            result = result.Skip(offset);
            result = result.Take(limit);

            return result;
        }

        // GET: api/Trucks/rows
        [ActionName("RowCount")]
        public int GetRowAmount(string filter = null)
        {
            var result = db.Trucks.AsQueryable();

            // Filter the data
            if (!String.IsNullOrEmpty(filter) && filter != "null")
            {
                if (filter.EndsWith(","))
                {
                    filter = filter.Remove(filter.Length - 1);
                }
                var filters = filter.Split(',');
                foreach (string fullFilter in filters)
                {
                    var filterParts = fullFilter.Split(' ');
                    var filterName = filterParts[0];
                    var filterOperator = WebUtility.UrlDecode(filterParts[1]);
                    var filterValue = filterParts[2];

                    if (filterOperator.Equals("contains"))
                    {
                        result = result.Where(filterName + ".Contains(@0)", filterValue);
                    }
                    else
                    {
                        result = result.Where(filterName + ' ' + filterOperator + ' ' + filterValue);
                    }
                }
            }

            return result.Count();
        }

        // PUT: api/Trucks/5
        [ActionName("UpdateTruck")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTruck(int id, Truck truck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != truck.id)
            {
                return BadRequest();
            }

            db.Entry(truck).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(id))
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

        // POST: api/Trucks        
        [ActionName("InsertTruck")]
        [ResponseType(typeof(Truck))]
        public IHttpActionResult PostTruck(Truck truck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trucks.Add(truck);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = truck.id }, truck);
        }

        // DELETE: api/Trucks/5
        [ActionName("DeleteTruck")]
        [ResponseType(typeof(Truck))]
        public IHttpActionResult DeleteTruck(int id)
        {
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }

            db.Trucks.Remove(truck);
            db.SaveChanges();

            return Ok(truck);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TruckExists(int id)
        {
            return db.Trucks.Count(e => e.id == id) > 0;
        }
    }
}