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
           

        }

  

        public void FormView2_InsertItem(Record record)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    record.RecordTypeID = 2;
                    Service.SaveRecord(record);

                    var digrecord = new DigitalRecord
                    {
                        RecordID = record.RecordID,
                        DiscSize = ((TextBox)FormView2.FindControl("DiscSizeTextBox")).Text
                    };
                    Service.SaveDigitalRecord(digrecord);

                    RecordID = record.RecordID;                   

                    Response.RedirectToRoute("RecordDetails", new { id = digrecord.RecordID });
                    Context.ApplicationInstance.CompleteRequest();

                }
                catch (Exception)
                {
                    
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då skivan skulle sparas");
                }
            }
        }






       
      

 

        

    }
}