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
    public partial class Details : System.Web.UI.Page
    {
        #region fält

        Service _service;

        #endregion

        #region egenskaper        

        public Service Service {

            get { return _service ?? (_service = new Service()); }
        }
      
        public int Id
        {

            //ID som skickats med som argument vid GetRouteURL hämtas ut

            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }


        private string Message
        {
            get { return Session["SucessMessage"] as string; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteHyperLink.NavigateUrl = GetRouteUrl("RecordDelete", new { id = Id });
            ReturnHyperLink.NavigateUrl = GetRouteUrl("Records", null);

            if (Session["SucessMessage"] != null)
            {

                UppdateMessage.Text = string.Format(UppdateMessage.Text, Message);

                UppdateMessagePanel.Visible = true;
                Session.Remove("SucessMessage");
            }
        }

        #region Getmetod Skiva
        
    
        public Records.Model.Record FormView1_GetItem([RouteData]int id)
        {
            try
            {
               
                return Service.GetRecord(id);


            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades vid redigering.");
                return null;
            }
        }

        #endregion

        #region GetMetod Digital
        
      
        public Records.Model.DigitalRecord FormView2_GetItem([RouteData]int id)
        {
            
            return Service.GetDigitalRecordByRecordID(id);
        }

        #endregion

        #region GetMetod Fysisk
     

        public Records.Model.PhysicalRecord FormView3_GetItem([RouteData]int id)
        {
            
            return Service.GetPhysicalRecordByRecordID(id);
        }

        #endregion




    }
}