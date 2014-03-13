using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Records.Model
{
    public class DigitalRecord
    {
        //public int DigRecordID { get; set; }

        [Required(ErrorMessage = "Storlek måste anges")]
        [StringLength(6, ErrorMessage = "Storlek får vara max 6 tecken")]
        [RegularExpression(@"^[1-9][0-9]?[0-9]?\s?[a-z]{2}$", ErrorMessage = "Ange storlek i rätt format! T.ex 1 gb, eller 1gb")]
        public string DiscSize { get; set; }

        public int RecordID { get; set; }
    }
}