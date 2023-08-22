using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraaEdge_MobileStore_Assignment.Models;
using ExtraaEdge_MobileStore_Assignment.BlRepository;

namespace ExtraaEdge_MobileStore_Assignment.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class MobileApiController : ControllerBase
    {
        Repository<TblMobileBrand, int> _mobileRepo;
        public MobileApiController()
        {
            this._mobileRepo = new Repository<TblMobileBrand, int>();
        }
        [HttpGet]
        [Route("api/Mobiles")]
        public List<TblMobileBrand> GetAllMobiles()
        {
            List<TblMobileBrand> lst = _mobileRepo.GetAll();
            return lst;
        }

        [HttpGet]
        [Route("api/Mobiles/{id}")]
        public TblMobileBrand GetMobilesById(int id)
        {
            return _mobileRepo.GetById(id);
        }

        [HttpPost]
        [Route("api/Mobiles")]
        public string AddMobile(TblMobileBrand c)
        {
            _mobileRepo.Create(c);
            return "Mobile Add Successfully...";
        }
        [HttpPut]
        [Route("api/Mobiles")]
        public string UpdateMobilesuccess(TblMobileBrand c)
        {
            _mobileRepo.Update(c);
            return "Update Mobile Successfully..";
        }
        [HttpDelete]
        [Route("api/Mobiles/{id}")]
        public string DeleteMobile(int id)
        {
            var mobile = _mobileRepo.GetById(id);
            _mobileRepo.Delete(id);
            return "Mobile Delete Successfully";
        }



    }
}
