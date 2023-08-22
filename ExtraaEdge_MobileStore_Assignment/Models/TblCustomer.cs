using System;
using System.Collections.Generic;

namespace ExtraaEdge_MobileStore_Assignment.Models
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblMobileSales = new HashSet<TblMobileSale>();
        }

        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }

        public virtual ICollection<TblMobileSale> TblMobileSales { get; set; }
    }
}
