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
using FresherTraining.Models;

namespace FresherTraining.Controllers
{
    public class RefsController : ApiController
    {
        private FresherTrainingContext db = new FresherTrainingContext();

        /// <summary>
        /// Hàm thực hiện lấy dữ liệu bảng phiếu thu chi REF
        /// Người tạo VDThang   
        /// Ngày tạo: 25/07/2019
        /// </summary>
        /// <returns></returns>
        [Route("refs")]
        [HttpGet]
        public IQueryable<Ref> GetRefs()
        {
            return db.Refs;
        }

        // GET: api/Refs/5
        [ResponseType(typeof(Ref))]
        public IHttpActionResult GetRef(Guid id)
        {
            Ref @ref = db.Refs.Find(id);
            if (@ref == null)
            {
                return NotFound();
            }

            return Ok(@ref);
        }

        // PUT: api/Refs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRef(Guid id, Ref @ref)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @ref.RefID)
            {
                return BadRequest();
            }

            db.Entry(@ref).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefExists(id))
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

        // POST: api/Refs
        [ResponseType(typeof(Ref))]
        public IHttpActionResult PostRef(Ref @ref)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Refs.Add(@ref);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RefExists(@ref.RefID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = @ref.RefID }, @ref);
        }

        // DELETE: api/Refs/5
        [ResponseType(typeof(Ref))]
        public IHttpActionResult DeleteRef(Guid id)
        {
            Ref @ref = db.Refs.Find(id);
            if (@ref == null)
            {
                return NotFound();
            }

            db.Refs.Remove(@ref);
            db.SaveChanges();

            return Ok(@ref);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RefExists(Guid id)
        {
            return db.Refs.Count(e => e.RefID == id) > 0;
        }
    }
}