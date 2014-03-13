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
    public partial class EditRecord : System.Web.UI.Page
    {
        #region fält

        Service _service;

        #endregion

        #region egenskaper

        public Service Service
        {

            get { return _service ?? (_service = new Service()); }
        }


       

        #endregion  

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormView1_UpdateItem([RouteData]int RecordID)
        {
            //TODO FIXA SERVICE - UpdateRecord
            //TODO FIXA UPDATEITEM

            ////try
            ////{
            ////    var contact = Service.Up(RecordID);
            ////    if (contact == null)
            ////    {

            ////        ModelState.AddModelError(String.Empty,
            ////            String.Format("Kontakten med kontaktnummer {0} hittades inte.", contactID));

            ////        return;
            ////    }

            ////    if (TryUpdateModel(contact))
            ////    {

            ////        Service.SaveContact(contact);
            ////        Session["success"] = true;
            ////        Session["UppdateMessage"] = "uppdaterades!";
            ////        Response.Redirect("~/");

            ////    }

            //}
            //catch (Exception)
            //{
            //    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            //}
        }
    }
}