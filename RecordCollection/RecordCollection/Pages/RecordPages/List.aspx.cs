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

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
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
    }
}

