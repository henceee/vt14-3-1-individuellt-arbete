using Records.Model;
using Records.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Records.Pages.RecordPages
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IEnumerable<Record> ListView1_GetData1()
        {
            try
            {
                Service service = new Service();
                return service.GetRecords();
              
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Fel inträffade då kunder hämtades.");
                return null;
            }
        }



    }
}