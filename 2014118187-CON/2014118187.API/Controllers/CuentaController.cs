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
using _2014118187_ENT.Entities;
using _2014118187_PER;

namespace _2014118187.API.Controllers
{
    public class CuentaController : ApiController
    {
        private _2014118187DbContext db = new _2014118187DbContext();

        // GET: api/Cuenta
        public IQueryable<Cuenta> GetCuenta()
        {
            return db.Cuenta;
        }

        // GET: api/Cuenta/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult GetCuenta(int id)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        // PUT: api/Cuenta/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuenta(int id, Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuenta.Pin)
            {
                return BadRequest();
            }

            db.Entry(cuenta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
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

        // POST: api/Cuenta
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult PostCuenta(Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cuenta.Add(cuenta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuenta.Pin }, cuenta);
        }

        // DELETE: api/Cuenta/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult DeleteCuenta(int id)
        {
            Cuenta cuenta = db.Cuenta.Find(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            db.Cuenta.Remove(cuenta);
            db.SaveChanges();

            return Ok(cuenta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuentaExists(int id)
        {
            return db.Cuenta.Count(e => e.Pin == id) > 0;
        }
    }
}