using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecordCollection.Model
{
    public class Record
    {
      
      
        public int RecordID { get; set; }

        [Required(ErrorMessage = "Titel måste anges")]
        [StringLength(30, ErrorMessage="Titeln får vara max 30 tecken")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Artist måste anges")]
        [StringLength(20, ErrorMessage = "Titeln får vara max 20 tecken")]
        public string Artist { get; set; }
        

        [Required(ErrorMessage = "Speltid måste anges")]
        [RegularExpression(@"^[0-9]{2}[0-9]?[:][0-5][0-9]$", ErrorMessage="Ange speltid i formatet mm:ss eller mmm:ss")]
        public string Playtime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Releasedate { get; set; }
  

        [Required(ErrorMessage = "Skivbolag måste anges")]
        [StringLength(20, ErrorMessage = "Skivbolagsnamnet får vara max 20 tecken")]
        public string Recordlabel { get; set; }

       

    }
}











        /*
          @RecordID int=0,
          @Title varchar(30) = ' ',
          @Artist varchar(20) = ' ',
          @Playtime varchar(6) = '00:00',
          @Releasedate date = '1900-01-01',
          @Recordlabel varchar(20)=' ',
          @GenreID int =1
       */