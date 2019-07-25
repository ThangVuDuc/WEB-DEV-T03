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
        public IEnumerable<Ref> GetRefs()
        {
            return db.Refs;
        }

        /// <summary>
        /// Hàm thực hiện thêm mới phiếu thu chi REF
        /// Người tạo VDThang
        /// Ngày tạo 25/07/2019
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [Route("refs")]
        [HttpPost]
        public int Post([FromBody] Ref refitem)
        {
            try
            {
                refitem.RefID = Guid.NewGuid();
                db.Refs.Add(refitem);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Hàm thực hiện sửa đổi phiếu thu chi REF
        /// Người tạo VDThang
        /// Ngày tạo 25/07/2019
        /// </summary>
        /// <param name="refitem"></param>
        /// <returns></returns>
        [Route("refs")]
        [HttpPut]
        public int Put([FromBody] Ref refitem)
        {
            try
            {
                var refFind = db.Refs.Where(p => p.RefID == refitem.RefID).FirstOrDefault();
                refFind.RefDate = refitem.RefDate;
                refFind.RefType = refitem.RefType;
                refFind.Total = refitem.Total;
                refFind.ContactName = refitem.ContactName;
                refFind.Reason = refitem.Reason;
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Hàm thực hiện xóa dữ liệu phiếu thu chi REF
        /// Người tạo VDThang
        /// Ngày tạo: 25/07/2019
        /// </summary>
        /// <param name="refids"></param>
        [Route("refs")]
        [HttpDelete]
        public void DeleteMultiple([FromBody]List<Guid> refids)
        {
            foreach (var refid in refids)
            {
                var refItem = db.Refs.Where(p => p.RefID == refid).FirstOrDefault();
                db.Refs.Remove(refItem);
            }
            db.SaveChanges();
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