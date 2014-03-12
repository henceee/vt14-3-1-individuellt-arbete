using Records.Model;
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
    public partial class NewDigital : System.Web.UI.Page
    {

        #region fält

        Service _service;

        #endregion

        #region egenskaper

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }


       
        public int RecordID { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["enabled"] as bool? == true){            

                FormView1.Enabled = true;
                FormView2.DefaultMode = FormViewMode.ReadOnly;
                
                Session.Remove("enabled");

                                
            }

            //if (Session["recordid"] != null) {

            //    RecordID = (int)Session["recordid"];
            //}
        }

  

        #region InsertMetod Skiva

        public void FormView2_InsertItem(Record record)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    record.RecordTypeID = 2;
                    Service.SaveRecord(record);
                    RecordID=record.RecordID;

                    Session["enabled"] = true;
                    //Session["recordid"] = record.RecordID;
                    Response.RedirectToRoute("NewDigital", new { id =  RecordID});
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då skivan skulle sparas");
                }
            }
        }

        #endregion



        #region InsertMetod Digital
               
        public void FormView1_InsertItem(DigitalRecord digrecord)
        {
            if (ModelState.IsValid)
            {
                try {

                    digrecord.RecordID = RecordID;
                    Service.SaveDigitalRecord(digrecord);
                    Session["SucessMessage"] = "lades till";
                    Response.RedirectToRoute("RecordDetails", null);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då skivan skulle sparas");
                }

            }
        }

        #endregion

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Record FormView2_GetItem([RouteData]int id)
        {
            return Service.GetRecord(id);
        }

      

 

        

    }
}