using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraaEdge_MobileStore_Assignment.Models;
using ExtraaEdge_MobileStore_Assignment.BlRepository;

namespace ExtraaEdge_MobileStore_Assignment.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class BrandApiController : ControllerBase
    {
        Repository<TblBrand, int> _brandRepo;
        public BrandApiController()
        {
            this._brandRepo = new Repository<TblBrand, int>();
        }

        [HttpGet]
        [Route("api/Brands")]
        public List<TblBrand> GetAllBrands()
        {
            List<TblBrand> lst = _brandRepo.GetAll();
            return lst;
        }

        [HttpGet]
        [Route("api/Brands/{id}")]
        public TblBrand GetBrandsById(int id)
        {
            return _brandRepo.GetById(id);
        }

        [HttpPost]
        [Route("api/Brands")]
        public string AddBrand(TblBrand c)
        {
            _brandRepo.Create(c);
            return "Brand Add Successfully...";
        }
        [HttpPut]
        [Route("api/Brands")]
        public string UpdateBrandSuccess(TblBrand c)
        {
            _brandRepo.Update(c);
            return "Update Brand Successfully..";
        }
        [HttpDelete]
        [Route("api/Brands/{id}")]
        public string DeleteBrand(int id)
        {
            var brand = _brandRepo.GetById(id);
            _brandRepo.Delete(id);
            return "Brand Delete Successfully";
        }

    }
}
