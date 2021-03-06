﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Records.Model
{
    public class Record
    {
        public int RecordID { get; set; }

        [Required(ErrorMessage = "Titel måste anges")]
        [StringLength(30, ErrorMessage = "Titeln får vara max 30 tecken")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Artist måste anges")]
        [StringLength(20, ErrorMessage = "Titeln får vara max 20 tecken")]
        public string Artist { get; set; }


        [Required(ErrorMessage = "Speltid måste anges")]
        [RegularExpression(@"^[0-9]{2}[0-9]?[:][0-5][0-9]$", ErrorMessage = "Ange speltid i formatet mm:ss eller mmm:ss")]
        public string Playtime { get; set; }

        [Required(ErrorMessage = "Releasedatum måste anges")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime Releasedate { get; set; }


        [Required(ErrorMessage = "Skivbolag måste anges")]
        [StringLength(20, ErrorMessage = "Skivbolagsnamnet får vara max 20 tecken")]
        public string Recordlabel { get; set; }

        
        //FK i databasen men nödvändig för att veta ifall det är fysisk/digital skiva
        //och för att veta ifall ytterligare skivinfo finns i tabellen Fysisk Skiva eller Digital Skiva

        public int RecordTypeID { get; set; }
    }
}