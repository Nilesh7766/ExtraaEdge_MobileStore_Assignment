using System;
using System.Collections.Generic;

namespace ExtraaEdge_MobileStore_Assignment.Models
{
    public partial class TblMobileSale
    {
        public int SaleId { get; set; }
        public int? CustomerId { get; set; }
        public int? MobileId { get; set; }
        public int? SaleQuantity { get; set; }
        public DateTime? SaleDate { get; set; }
        public double? SaleAmount { get; set; }

        public virtual TblCustomer? Customer { get; set; }
        public virtual TblMobileBrand? Mobile { get; set; }
    }
}
