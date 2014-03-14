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

        private string Message
        {
            get { return Session["SucessMessage"] as string; }
        }
       

        #endregion  

        protected void Page_Load(object sender, EventArgs e)
        {
            var ID = RouteData.Values["id"].ToString();

            if (Session["SucessMessage"] != null)
            {

                UppdateMessage.Text = string.Format(UppdateMessage.Text, Message);

                UppdateMessagePanel.Visible = true;
                Session.Remove("SucessMessage");
            }
        }


        #region Get-Metod Skiva


        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Records.Model.Record FormView1_GetItem([RouteData]int id)
        {
            return Service.GetRecord(id);
        }

        #endregion

        #region Update-metod Skiva        
       

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormView1_UpdateItem([RouteData]int id)
        {
           

            try
            {
                var record = Service.GetRecord(id);
                if (record == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Skiva med skivID {0} hittades inte.", id));

                    return;
                }

                if (TryUpdateModel(record))
                {
                    //var pricevalue = ((TextBox)FormView1.FindControl("PriceTextBox")).Text;

                    //var Price = decimal.Parse(pricevalue, CultureInfo.InvariantCulture);
                    //var Purchasedate = DateTime.Parse(((TextBox)FormView1.FindControl("PurchaseDateTextBox")).Text);

                    var ReleaseDate = DateTime.Parse(((TextBox)FormView1.FindControl("ReleaseDateTextBox")).Text);

                    record.Releasedate = ReleaseDate;
                    Service.SaveRecord(record);
                    Session["success"] = true;
                    Session["UppdateMessage"] = "uppdaterades!";
                    Response.RedirectToRoute("RecordDetails", new { id = record.RecordID });
                    Context.ApplicationInstance.CompleteRequest();

                }

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            }


        }

        #endregion

        #region Update-metod Digital Skiva
        

        public void FormView2_UpdateItem([RouteData]int id)
        {


            try
            {
                var digrecord = Service.GetDigitalRecordByRecordID(id);
                if (digrecord == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Skiva med skivID {0} hittades inte.", id));

                    return;
                }

                if (TryUpdateModel(digrecord))
                {
      
                    Service.UpdateDigitalRecord(digrecord);
                    Session["sucessMessage"] = "Övriga Uppgifter uppdaterades.";
                    Response.RedirectToRoute("EditRecord", new { id = digrecord.RecordID });
                    Context.ApplicationInstance.CompleteRequest();
                    
                    

                }

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            }
        }

        #endregion

        #region Select-metod Digital Skiva               

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Records.Model.DigitalRecord FormView2_GetItem([RouteData]int id)
        {
            return Service.GetDigitalRecordByRecordID(id);
        }
        
        #endregion

        #region Update-metod Fysisk Skiva

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormView3_UpdateItem([RouteData]int id)
        {


            try
            {
                var physrecord = Service.GetPhysicalRecordByRecordID(id);
                if (physrecord == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Skiva med skivID {0} hittades inte.", id));

                    return;
                }

                if (TryUpdateModel(physrecord))
                {
                    var DateofPurchase = DateTime.Parse(((TextBox)FormView1.FindControl("PurchaseDateTextBox")).Text);

                    physrecord.DateofPurchase = DateofPurchase;

                    Service.UpdatePhysicalRecord(physrecord);
                    Session["sucessMessage"] = "Övriga Uppgifter uppdaterades.";
                    Response.RedirectToRoute("EditRecord", new { id = physrecord.RecordID });
                    Context.ApplicationInstance.CompleteRequest();



                }

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            }
        }


        #endregion

        #region Select-metod Fysisk skiva

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Records.Model.PhysicalRecord FormView3_GetItem([RouteData]int id)
        {
            return Service.GetPhysicalRecordByRecordID(id);
        }


        #endregion






    }
}