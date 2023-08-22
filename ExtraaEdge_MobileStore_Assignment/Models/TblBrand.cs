using System;
using System.Collections.Generic;

namespace ExtraaEdge_MobileStore_Assignment.Models
{
    public partial class TblBrand
    {
        public TblBrand()
        {
            TblMobileBrands = new HashSet<TblMobileBrand>();
        }

        public int BrandId { get; set; }
        public string? Barnd { get; set; }

        public virtual ICollection<TblMobileBrand> TblMobileBrands { get; set; }
    }
}
