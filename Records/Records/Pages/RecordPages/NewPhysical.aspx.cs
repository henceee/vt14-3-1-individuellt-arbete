using Records.Model;
using Records.Model.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Records.Pages.RecordPages
{
    public partial class NewPhysical : System.Web.UI.Page
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

        public void FormView1_InsertItem(Record record)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    record.RecordTypeID = 1;
                    Service.SaveRecord(record);

                    var pricevalue = ((TextBox)FormView1.FindControl("PriceTextBox")).Text;

                    
                    var Price = decimal.Parse(pricevalue, CultureInfo.InvariantCulture);
                    var Purchasedate = DateTime.Parse(((TextBox)FormView1.FindControl("PurchaseDateTextBox")).Text);
                    
                    var physrecord = new PhysicalRecord
                    {                            
                        RecordID = record.RecordID,
                        PriceAtPurchase =  Price,
                        DateofPurchase = Purchasedate
                        
                    };
                    Service.SavePhysicalRecord(physrecord);

                    RecordID = record.RecordID;

                    Response.RedirectToRoute("RecordDetails", new { id = physrecord.RecordID });
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