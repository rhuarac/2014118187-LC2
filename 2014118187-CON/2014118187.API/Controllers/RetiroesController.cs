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
using _2014118187_ENT.EntitiesDTO;
using AutoMapper;

namespace _2014118187.API.Controllers
{
    public class RetiroesController : ApiController
    {
        //private _2014118187DbContext db = new _2014118187DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public RetiroesController()
        {

        }

        public RetiroesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: api/Retiroes
        // public IQueryable<Retiro> GetRetiro()
        //{
        //  return db.Retiro;
        //}

        // GET: api/Retiroes/5
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult Get()
        {
            var Retiros = _UnityOfWork.Retiro.GetAll();

            if (Retiros == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var RetiroDTO = new List<RetiroDTO>();

            foreach (var retiro in Retiros)
                RetiroDTO.Add(Mapper.Map<Retiro, RetiroDTO>(retiro));

            return Ok(RetiroDTO);
        }

        // PUT: api/Retiroes/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutRetiro(int id, Retiro retiro)
        //{
        //  if (!ModelState.IsValid)
        //{
        //  return BadRequest(ModelState);
        //}

        //if (id != retiro.RetiroId)
        //{
        //  return BadRequest();
        //}
        //{
        //                throw;
        //          }
        //    }

        //  return StatusCode(HttpStatusCode.NoContent);
        //}

        public IHttpActionResult Get(int id)
        {
            var retiro= _UnityOfWork.Retiro.Get(id);

            if (retiro == null)
                return NotFound();

            return Ok(Mapper.Map<Retiro, RetiroDTO>(retiro));
        }

        [HttpPut]
        public IHttpActionResult Update(int id, RetiroDTO retiroDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retiroInPersistence = _UnityOfWork.Retiro.Get(id);
            if (retiroInPersistence == null)
                return NotFound();

            Mapper.Map<RetiroDTO, Retiro>(retiroDTO, retiroInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(retiroDTO);
        }
        // POST: api/Retiroes
        //[ResponseType(typeof(Retiro))]
        //public IHttpActionResult PostRetiro(Retiro retiro)
        //{
        //  if (!ModelState.IsValid)
        //{
        //  return BadRequest(ModelState);
        //}

        //           db.Retiro.Add(retiro);
        //         db.SaveChanges();

        //       return CreatedAtRoute("DefaultApi", new { id = retiro.RetiroId }, retiro);
        // }

        public IHttpActionResult Create(RetiroDTO retiroDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retiro = Mapper.Map<RetiroDTO, Retiro>(retiroDTO);

            _UnityOfWork.Retiro.Add(retiro);
            _UnityOfWork.SaveChanges();

            retiroDTO.RetiroId = retiro.RetiroId;

            return Created(new Uri(Request.RequestUri + "/" + retiro.RetiroId), retiroDTO);
        }


        // DELETE: api/Retiroes/5
        //[ResponseType(typeof(Retiro))]
        //public IHttpActionResult DeleteRetiro(int id)
        // {
        //   Retiro retiro = db.Retiro.Find(id);
        // if (retiro == null)
        //{
        //    return NotFound();
        //}

        //db.Retiro.Remove(retiro);
        //db.SaveChanges();

        //return Ok(retiro);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retiroInDataBase = _UnityOfWork.Retiro.Get(id);
            if (retiroInDataBase == null)
                return NotFound();

            _UnityOfWork.Retiro.Delete(retiroInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
        }

        // protected override void Dispose(bool disposing)
        //{
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