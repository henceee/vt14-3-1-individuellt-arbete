using Records.Model;
using Records.Model.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Records.Pages.RecordPages
{
    public partial class AddInfo : System.Web.UI.Page
    {
        #region fält

        Service _service;
        Record _record;

        #endregion

        #region egenskaper

        public int Id
        {

            //ID som skickats med som argument vid GetRouteURL hämtas ut

            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        public Service Service
        {

            get { return _service ?? (_service = new Service()); }
        }

        public Record Record
        {

            get { return _record ?? (_record = new Record()); }
            set { _record = value; }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Record = Service.GetRecord(Id);
                    
            //Om det är en fysisk skiva => lägga till som digital.
            if (Record.RecordTypeID == 1)
            {

                AddInfoHeaderLiteral.Text = "Lägg till som digital skiva";
                FormView1.Visible = true;
                FormView3.Visible = false;

            }
            else {
                FormView1.Visible = false;
            }
        }


        #region Insert Digital Skiva

        public void FormView1_InsertItem(DigitalRecord digrecord)
        {
          
            if (ModelState.IsValid)
            {
                try
                {

                    digrecord.RecordID = Id;

                    Service.SaveDigitalRecord(digrecord);

                    //TODO: Fixa till i Service för hantering av multi

                    //RecordTypeID 3 är 'multi', både som fysisk och digital
                    Record.RecordTypeID = 3;

                    Service.SaveRecord(Record);

                    Response.RedirectToRoute("RecordDetails", new { id = digrecord.RecordID });

                }
                catch
                {

                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när skivan skulle läggas in");
                }

            }
        }

        #endregion


        #region GetMetod Digital Skiva
        
       
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Records.Model.DigitalRecord FormView1_GetItem([RouteData] int id)
        {
            try
            {

                return Service.GetDigitalRecordByRecordID(id);


            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Fel inträffade då skivan hämtades.");
                return null;
            }
        }
        #endregion


        #region GetMetod Skiva

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Records.Model.Record FormView2_GetItem([RouteData]int id)
        {
            return Service.GetRecord(id);
        }
        #endregion


        #region InsertMetod Fysisk Skiva
        
        
        public void FormView3_InsertItem(PhysicalRecord physrecord)
        {
           
            if (ModelState.IsValid)
            {
                try
                {

                    physrecord.RecordID = Id;

                    var pricevalue = ((TextBox)FormView3.FindControl("PriceTextBox")).Text;
                    //TODO fixa så det funkar utan InvariantCulture
                    var Price = decimal.Parse(pricevalue, CultureInfo.InvariantCulture);
                    physrecord.PriceAtPurchase = Price;

                    Service.SavePhysicalRecord(physrecord);
                    
                    //TODO: Fixa till i Service för hantering av multi                   

                    //RecordTypeID 3 är 'multi', både som fysisk och digital
                    Record.RecordTypeID = 3;

                    Service.SaveRecord(Record);

                    Response.RedirectToRoute("RecordDetails", new { id = physrecord.RecordID });

                }
                catch
                {

                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när skivan skulle läggas in");
                }

            }
        }
        #endregion
        

     

    
    }   
}