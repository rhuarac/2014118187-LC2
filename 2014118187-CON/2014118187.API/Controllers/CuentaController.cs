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
using _2014118187_ENT.IRepositories;
using AutoMapper;
using _2014118187_ENT.EntitiesDTO;

namespace _2014118187.API.Controllers
{
    public class CuentaController : ApiController
    {
        //private _2014118187DbContext db = new _2014118187DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public CuentaController()
        {

        }

        public CuentaController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: api/Cuenta
       // public IQueryable<Cuenta> GetCuenta()
        //{
          //  return db.Cuenta;
        //}

        // GET: api/Cuenta/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult Get()
        {
            var Cuentas = _UnityOfWork.Cuenta.GetAll();

            if (Cuentas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var CuentaDTO = new List<CuentaDTO>();

            foreach (var cuenta in Cuentas)
                CuentaDTO.Add(Mapper.Map<Cuenta, CuentaDTO>(cuenta));

            return Ok(CuentaDTO);
        }

        // PUT: api/Cuenta/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCuenta(int id, Cuenta cuenta)
        //{
        // if (!ModelState.IsValid)
        //{
        //  return BadRequest(ModelState);
        //}

        //if (id != cuenta.Pin)
        //{
        //  return BadRequest();
        //}

        //db.Entry(cuenta).State = EntityState.Modified;

        //try
        //{
        // db.SaveChanges();
        // }
        //catch (DbUpdateConcurrencyException)
        //{
        ///  if (!CuentaExists(id))
        //{
        //  return NotFound();
        // }
        //else
        //{
        //  throw;
        //   }
        //}

        //return StatusCode(HttpStatusCode.NoContent);
        //}
        public IHttpActionResult Get(int id)
        {
            var cuenta = _UnityOfWork.Cuenta.Get(id);

            if (cuenta == null)
                return NotFound();

            return Ok(Mapper.Map<Cuenta, CuentaDTO>(cuenta));
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CuentaDTO cuentaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cuentaInPersistence = _UnityOfWork.Cuenta.Get(id);
            if (cuentaInPersistence == null)
                return NotFound();

            Mapper.Map<CuentaDTO, Cuenta>(cuentaDTO, cuentaInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(cuentaDTO);
        }
        // POST: api/Cuenta
        //[ResponseType(typeof(Cuenta))]
        //public IHttpActionResult PostCuenta(Cuenta cuenta)
        //{
        //  if (!ModelState.IsValid)
        //{
        //  return BadRequest(ModelState);
        ///}

        //db.Cuenta.Add(cuenta);
        //db.SaveChanges();

        //return CreatedAtRoute("DefaultApi", new { id = cuenta.Pin }, cuenta);
        //}
        public IHttpActionResult Create(CuentaDTO cuentaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cuenta = Mapper.Map<CuentaDTO, Cuenta>(cuentaDTO);

            _UnityOfWork.Cuenta.Add(cuenta);
            _UnityOfWork.SaveChanges();

            cuentaDTO.CuentaId = cuenta.CuentaId;

            return Created(new Uri(Request.RequestUri + "/" + cuenta.CuentaId), cuentaDTO);
        }



        // DELETE: api/Cuenta/5
        //[ResponseType(typeof(Cuenta))]
        //public IHttpActionResult DeleteCuenta(int id)
        //{
        //  Cuenta cuenta = db.Cuenta.Find(id);
        //if (cuenta == null)
        //{
        //  return NotFound();
        //}

        //db.Cuenta.Remove(cuenta);
        //db.SaveChanges();

        //return Ok(cuenta);
        //}

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cuentaInDataBase = _UnityOfWork.Cuenta.Get(id);
            if (cuentaInDataBase == null)
                return NotFound();

            _UnityOfWork.Cuenta.Delete(cuentaInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
        }

        //protected override void Dispose(bool disposing)
        // {
        //  if (disposing)
        //{
        //  db.Dispose();
        //}
        //base.Dispose(disposing);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}