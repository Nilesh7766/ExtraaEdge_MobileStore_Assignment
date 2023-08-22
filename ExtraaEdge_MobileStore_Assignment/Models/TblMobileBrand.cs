using System;
using System.Collections.Generic;

namespace ExtraaEdge_MobileStore_Assignment.Models
{
    public partial class TblMobileBrand
    {
        public TblMobileBrand()
        {
            TblMobileSales = new HashSet<TblMobileSale>();
        }

        public int MobileId { get; set; }
        public string? Mobile { get; set; }
        public int? BrandId { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }

        public virtual TblBrand? Brand { get; set; }
        public virtual ICollection<TblMobileSale> TblMobileSales { get; set; }
    }
}
