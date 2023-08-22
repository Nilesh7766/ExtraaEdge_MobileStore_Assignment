namespace ExtraaEdge_MobileStore_Assignment.Models
{
    public class SaleMobileReportsVM
    {
        public List<salemobileVm> salemobiles { get; set; }
        public List<CustomersVM> Customers { get; set; }

        public List<MobileBrandsVM> MobileBrands { get; set; }

        public List<MobileVM> MobileVMs { get; set; }

    }
    public class CustomersVM
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
    }

    public class MobileVM
    {
        public int MobileId { get; set; }
        public string? Mobile { get; set; }
        public int? BrandId { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }

    }

    public class MobileBrandsVM
    {
        public int BrandId { get; set; }
        public string? Barnd { get; set; }

    }

    public class salemobileVm
    {
        public salemobileVm()
        {
            this.SaleDate = DateTime.Now;
        }
        public int SaleId { get; set; }
        public int? CustomerId { get; set; }
        public int? MobileId { get; set; }
        public int? SaleQuantity { get; set; }
        public DateTime? SaleDate { get; set; }
        public double? SaleAmount { get; set; }
    }
    public class MobileSaleReports
    {
        public int MobileId { get; set; }
        public string? Mobile { get; set; }
        public int? BrandId { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }

        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Barnd { get; set; }

        public int SaleId { get; set; }
        public int? SaleQuantity { get; set; }
        public DateTime? SaleDate { get; set; }
        public double? SaleAmount { get; set; }


    }
}
