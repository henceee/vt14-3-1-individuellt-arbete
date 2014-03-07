using RecordCollection.Model;
using RecordCollection.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordCollection.Pages.RecordPages
{
    

    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

       

        /// <summary>
        /// GetData till List.aspx
        /// Försöker skapa ett nytts service objekt, kallar på GetRecords() i Service-klassen
        /// för att hämta ut alla skivor i databasen.
        /// </summary>
        /// <returns></returns>

        #region GetData
        

        public IEnumerable<Record> ListView1_GetData()
        {
            try
            {
                Service service = new Service();
                return service.GetRecords();
            }
            catch (Exception) {

                ModelState.AddModelError(String.Empty, "Fel inträffade då kunder hämtades.");
                return null;
            }
        }

        #endregion

    }
}

