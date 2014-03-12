using Records.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Records.Pages.RecordPages
{
    public partial class Delete : System.Web.UI.Page
    {
        #region fält

        private Service _service;

        #endregion

        #region egenskaper

        public Service Service { get { return _service ?? (_service = new Service()); } }

        public int Id {

            //ID som skickats med som argument vid GetRouteURL hämtas ut

            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Trycker användaren avbryt, tas anv. tillbaka till detaljerna för skivan med det ID

            CancelLinkButton.NavigateUrl = GetRouteUrl("RecordDetails", new { id = Id });


            if (!IsPostBack)
            {
                try {

                    var record = Service.GetRecord(Id);
                    
                    if(record != null){

                        RecordTitleLiteral.Text = record.Title;
                        return;

                    }

                    //Om nåt går snett och skivan inte hittas ....

                    ModelState.AddModelError(String.Empty, string.Format("Skivan med SkivID {0} hittades inte", ID));

                }
                
                    //generellt fel

                catch(Exception){

                    ModelState.AddModelError(String.Empty, "Ett fel inträffade vid borttagning av skivan");

                }
            }
        }


        #region DeleteLinkButton_Command


        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {

                //försöker parsa ID skickas med som argument (CommandArgument) som int

                var id = int.Parse(e.CommandArgument.ToString());

                Service.DeleteRecord(id);

                Session["SucessMessage"] = "togs bort";
                Response.RedirectToRoute("Records", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett fel inträffade vid borttagning av skivan");
            }

        #endregion

       
        }
    }
}