using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class RefDL
    {
        private FresherTrainingContext db = new FresherTrainingContext();

        //Hàm thực hiện lấy hết dữ liệu bảng phiếu thu
        //Người tạo VDThang 01/08/2019
        public IEnumerable<Ref> GetRefData()
        {
            return db.Refs;
        }

        //Hàm thực hiện thêm mới dữ liệu phiếu thu
        //Người tạo VDThang 01/08/2019
        public void AddRef(Ref _ref)
        {
            _ref.RefID = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        //Hàm thực hiện việc sửa dữ liệu phiếu thu
        //Người tạo DVCuong 01/08/2019
        public void UpdateRef(Ref _ref)
        {
            var _refFind = db.Refs.Where(p => p.RefID == _ref.RefID).FirstOrDefault();
            if(_refFind != null)
            {
               _refFind.RefDate = _ref.RefDate;
               _refFind.RefType = _ref.RefType;
               _refFind.Total = _ref.Total;
               _refFind.ContactName = _ref.ContactName;
               _refFind.Reason = _ref.Reason;
            }
            db.SaveChanges();
        }

        //Hàm thực hiện việc xóa dữ liệu phiếu thu
        //Người tạo DVCuong 01/08/2019

        public void DelMulRef(List<Guid> _refids)
        {
            foreach (var _refid in _refids)
            {
                var _refItem = db.Refs.Where(p => p.RefID == _refid).FirstOrDefault();
                db.Refs.Remove(_refItem);
            }
            db.SaveChanges();
        }

        //Hàm thực hiện lấy phiếu thu thep RefID
        //Người tạo VDThang 01/08/2019
        public Ref GetRefByRefID(Guid _refID)
        {
            var _refItem = db.Refs.Where(p => p.RefID == _refID).FirstOrDefault();
            return _refItem;
        }
    }
}
