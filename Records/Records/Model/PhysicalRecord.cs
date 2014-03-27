using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Records.Model
{
    public class PhysicalRecord
    {
        
        [Required(ErrorMessage = "Inköpspris måste anges")]
        public Decimal PriceAtPurchase  { get; set; }
        
        [Required(ErrorMessage = "Inköpsdatum måste anges")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime DateofPurchase { get; set; }

        public int RecordID { get; set; }

    }
}