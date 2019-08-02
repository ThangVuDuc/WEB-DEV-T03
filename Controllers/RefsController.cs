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
using MISA.Entities;
using MISA.DL;
using FresherTraining.Properties;

namespace FresherTraining.Controllers
{
    public class RefsController : ApiController
    {
        private RefDL _refDL = new RefDL();
        /// <summary>
        /// Hàm thực hiện lấy dữ liệu bảng phiếu thu chi REF
        /// Người tạo VDThang   
        /// Ngày tạo: 25/07/2019
        /// </summary>
        /// <returns></returns>
        [Route("refs")]
        [HttpGet]
        public AjaxResult GetRefs()
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetRefData();
            }catch(Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Data = ex;
                _ajaxResult.Message = Resources.erroVN;
            }
            return _ajaxResult;
        }

        /// <summary>
        /// Hàm thực hiện lấy dữ liệu phiếu thu theo trường RefID
        /// Người tạo VDThang
        /// Ngày tạo 01/08/2019
        /// </summary>
        /// <returns></returns>
        [Route("refs/{refid}")]
        [HttpGet]
        public AjaxResult GetRefByRefID(Guid refid)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetRefByRefID(refid);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Data = ex;
                _ajaxResult.Message = Resources.erroVN;
            }
            return _ajaxResult;
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
        public AjaxResult Post([FromBody] Ref _refitem)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _refDL.AddRef(_refitem);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Data = ex;
                _ajaxResult.Message = Resources.erroVN;
            }
            return _ajaxResult;
        }

        ///// <summary>
        ///// Hàm thực hiện sửa đổi phiếu thu chi REF
        ///// Người tạo VDThang
        ///// Ngày tạo 25/07/2019
        ///// </summary>
        ///// <param name="refitem"></param>
        ///// <returns></returns>
        [Route("refs")]
        [HttpPut]
        public AjaxResult Put([FromBody] Ref _refitem)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _refDL.UpdateRef(_refitem);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Data = ex;
                _ajaxResult.Message = Resources.erroVN;
            }
            return _ajaxResult;

        }

        ///// <summary>
        ///// Hàm thực hiện xóa dữ liệu phiếu thu chi REF
        ///// Người tạo VDThang
        ///// Ngày tạo: 25/07/2019
        ///// </summary>
        ///// <param name="refids"></param>
        [Route("refs")]
        [HttpDelete]
        public AjaxResult DeleteMultiple([FromBody]List<Guid> _refids)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _refDL.DelMulRef(_refids);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Data = ex;
                _ajaxResult.Message = Resources.erroVN;
            }
            return _ajaxResult;
        }
    }
}