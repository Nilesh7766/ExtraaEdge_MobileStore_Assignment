using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraaEdge_MobileStore_Assignment.Models;
using ExtraaEdge_MobileStore_Assignment.BlRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExtraaEdge_MobileStore_Assignment.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class MobileSaleApiController : ControllerBase
    {
        Repository<TblMobileSale, int> _salemobileRepo;
        Repository<TblCustomer, int> _customerRepo;
        Repository<TblBrand, int> _brandRepo;
        Repository<TblMobileBrand, int> _mobileRepo;

        public MobileSaleApiController()
        {
            this._salemobileRepo = new Repository<TblMobileSale, int>();
            this._customerRepo = new Repository<TblCustomer, int>();
            this._brandRepo = new Repository<TblBrand, int>();
            this._mobileRepo = new Repository<TblMobileBrand, int>();
        }

        [HttpGet]
        [Route("api/SalesMobile")]
        public List<TblMobileSale> GetAllSalesMobile()
        {
            List<TblMobileSale> lst = _salemobileRepo.GetAll();
            return lst;
        }

        [HttpGet]
        [Route("api/SalesMobile/{id}")]
        public TblMobileSale GetSalesMobileById(int id)
        {
            return _salemobileRepo.GetById(id);
        }

        [HttpPost]
        [Route("api/SalesMobile")]
        public string AddSaleForMobile(TblMobileSale c)
        {
            _salemobileRepo.Create(c);

            return " Mobile Sale Successfully...";
        }
        [HttpPut]
        [Route("api/SalesMobile")]
        public string UpdateSalesMobileuccess(TblMobileSale c)
        {
            _salemobileRepo.Update(c);
            return "Update  Sale Mobile Successfully..";
        }

        [HttpDelete]
        [Route("api/SalesMobile/{id}")]
        public string DeleteMobile(int id)
        {
            var mobile = _salemobileRepo.GetById(id);
            _salemobileRepo.Delete(id);
            return "Mobile Sale Delete Successfully";
        }

      
        [HttpPost]
            [Route("api/AllMobileSaleReport")]
            public ActionResult<List<TblMobileSale>> GetAllSaleMobileReports(string? fDate, string? toDate, string? findmonth, int? brandid)
            {
                List<TblMobileSale> list = new List<TblMobileSale>();

                List<TblMobileSale> lst = new List<TblMobileSale>();

                List<MobileSaleReports> saleMobileReports = new List<MobileSaleReports>();
                List<TblCustomer> cust = new List<TblCustomer>();
                foreach (var sm in _salemobileRepo.GetAll())
                {
                    sm.Customer = null;
                    TblCustomer cc = _customerRepo.GetAll().FirstOrDefault(x => x.CustomerId == sm.CustomerId);
                    TblMobileBrand mm = _mobileRepo.GetAll().FirstOrDefault(x => x.MobileId == sm.MobileId);
                    mm.TblMobileSales = null;
                    cc.TblMobileSales = null;

                    TblMobileSale smo = new TblMobileSale()
                    {
                        SaleAmount = sm.SaleAmount,
                        SaleDate = sm.SaleDate,
                        SaleId = sm.SaleId,
                        CustomerId = sm.CustomerId,
                        MobileId = sm.MobileId,
                        Customer = cc,
                        Mobile = mm,
                        SaleQuantity = sm.SaleQuantity,


                    };
                    lst.Add(smo);

                }
                if ((fDate != null | fDate != "") && (toDate != null | toDate != "") && (brandid != null))
                {
                    int b = (int)brandid;
                    DateTime firstdate = DateTime.Parse(fDate);
                    DateTime seconddate = DateTime.Parse(toDate);
                    var ls = lst.Where(x => (x.SaleDate >= firstdate
                                          && x.SaleDate <= seconddate) && x.Mobile.BrandId == b).ToList();
                    return ls;
                }
                else if ((fDate != null | fDate != "") && (toDate != null | toDate != ""))
                {
                    DateTime firstdate = DateTime.Parse(fDate);
                    DateTime seconddate = DateTime.Parse(toDate);
                    var ls = lst.Where(x => (x.SaleDate >= firstdate
                                          && x.SaleDate <= seconddate)).ToList();
                    return ls;
                }



                else if (findmonth != "01-2001" && findmonth != "")
                {
                    DateTime Month = DateTime.Parse(findmonth);
                    var ls = lst.ToList().Where(x => x.SaleDate.Value.Month.Equals(Month.Month)).ToList();
                    return ls;

                }
                else if (brandid != null)
                {
                    int b = (int)brandid;
                    var ls = lst.ToList().Where(x => x.Mobile.BrandId == b).ToList();
                    return ls;
                }


                return lst;
            }
    }
}
