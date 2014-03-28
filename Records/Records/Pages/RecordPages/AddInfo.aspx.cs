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

            FormView1.Visible = (Record.RecordTypeID == 1) ? true : false;

            if (Record.RecordTypeID == 1) {

                AddInfoHeaderLiteral.Text = "Lägg till som digital skiva";               
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

                    //Record.RecordTypeID = 3;

                    //Service.SaveRecord(Record);

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

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Records.Model.PhysicalRecord FormView6_GetItem([RouteData]int id)
        {
            return Service.GetPhysicalRecordByRecordID(id);
        }


        //TODO: Undersök varför inte InsertItem för fysisk skiva anropas.
        public void FormView6_InsertItem(PhysicalRecord physrecord)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    physrecord.RecordID = Id;

                    Service.SavePhysicalRecord(physrecord);

                    //TODO: Fixa till i Service för hantering av multi

                    //Record.RecordTypeID = 3;

                    //Service.SaveRecord(Record);

                    Response.RedirectToRoute("RecordDetails", new { id = physrecord.RecordID });

                }
                catch
                {

                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när skivan skulle läggas in");
                }

            }
        }

     

    
    }   
}