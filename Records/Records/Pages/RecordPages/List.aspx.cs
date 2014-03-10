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

        #region Egenskaper

        private string Message
        {
            get { return Session["SucessMessage"] as string; }
        }
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SucessMessage"] != null) {

                UppdateMessage.Text = string.Format(UppdateMessage.Text, Message);

                UppdateMessagePanel.Visible = true;
                Session.Remove("SucessMessage");
            }

           
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