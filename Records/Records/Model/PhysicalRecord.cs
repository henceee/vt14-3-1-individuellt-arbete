using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Records.Model.DAL
{
    public class PhysicalRecord
    {
        public int PhysRecordID { get; set; }

        [Required(ErrorMessage = "Inköpspris måste anges")]
        [RegularExpression(@"[0-9]{1,4}[.][0-9]{2}", ErrorMessage="Ange Priset som ett flytal med högst 4 tal följt av två decimaler")]
        public Decimal PriceAtPurchase  { get; set; }
        
        [Required(ErrorMessage = "Inköpsdatum måste anges")]
        [DataType(DataType.Date)]
        public DateTime DateofPurchase { get; set; }

        public int RecordID { get; set; }

    }
}