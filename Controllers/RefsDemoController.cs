using FresherTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FresherTraining.Controllers
{
    public class RefsDemoController : ApiController
    {
        /// Thực hiện lấy dữ liệu các phiếu thu từ model
        /// Người tạo VDThang 
        /// Ngày tạo 19/07/2019
        /// <returns>Danh sách phiếu thu</returns>
        //[Route("refs")]
        //[HttpGet]
        //public IEnumerable<Ref> Get()
        //{
        //    return Ref.Refs;
        //}

        //[Route("refs/{refno}")]
        //[HttpGet]
        //public string Get(string refno)
        //{
        //    return "value";
        //}

        //[Route("refs")]
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //[Route("refs")]
        //[HttpPut]
        //public void Put([FromBody]string value)
        //{
        //}

        //[Route("refs/{refno}")]
        //[HttpDelete]
        //public void Delete(string refno)
        //{
        //    var refItem = Ref.Refs.Where(p => p.refNo == refno).FirstOrDefault();
        //    Ref.Refs.Remove(refItem);
        //}

        //[Route("refs")]
        //[HttpDelete]
        //public void DeleteMultiple([FromBody]List<string> refnos)
        //{
        //    foreach(var refno in refnos)
        //    {
        //        var refItem = Ref.Refs.Where(p => p.refNo == refno).FirstOrDefault();
        //        Ref.Refs.Remove(refItem);
        //    }
        //}
    }
}
