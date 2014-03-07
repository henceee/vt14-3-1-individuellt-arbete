using Records.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Records.Pages.RecordPages
{
    public partial class Details : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Records.Model.Record FormView1_GetItem([RouteData]int id)
        {

            try
            {
                Service service = new Service();
                return service.GetRecord(id);

            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades vid redigering.");
                return null;
            }
                         
            
            
        }
    }
}