using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechTicket.DataEntry.UserControls;
using Ext.Net;

namespace TechTicket.DataEntry.Web
{
    public partial class EmailTemplateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //LoadDivisionControl();
            }

        }

        //  [DirectMethod]
        //  public void OnTabChange(string id)
        //  {  // UserControl
        //      UserControl v =(UserControl)LoadControl("~/UserControls/TemplateFieldControls/TemplateList.ascx");
        //      v.ID = "fieldTemplateData";
        //      TemplatePanel.ContentControls.Add(v);
        //      TemplatePanel.UpdateContent();
        //     // Ext.Net.Panel panel3 = new Ext.Net.Panel("My Stuff");
        //      TemplateList uc =
        //(TemplateList)Page.LoadControl("~/UserControls/TemplateFieldControls/TemplateList.ascx");

        //      //TemplatePanel.Content = uc;
        //     //  TemplatePanel.ContentContainer.Controls.Add(uc);
        //     // TemplatePanel.Render()
        //  }

        public void OnTabChange(object sender, DirectEventArgs e)
        {

            if (sender is TabPanel)
            {
                var panelId = ((TabPanel)sender).ActiveTab.ID;

                if (panelId == nameof(DivisionPanel))
                    LoadDivisionControl();
                else if (panelId == nameof(RequestPanel))
                    LoadRequestControl();
                else if (panelId == nameof(TemplatePanel))
                    LoadEmailTemplateControl();

            }

        }

        [DirectMethod]
        public void OnTabChange(string panelId)
        {

            if (panelId == nameof(DivisionPanel))
                LoadDivisionControl();
            else if (panelId == nameof(RequestPanel))
                LoadRequestControl();
            else if (panelId == nameof(TemplatePanel))
                LoadEmailTemplateControl();

        }

        #region Helper methods

        private void LoadDivisionControl()
        {
        }

        private void LoadRequestControl()
        {
            RequestData.LoadMasterData();
        }

        private void LoadEmailTemplateControl()
        {
            fieldTemplateData.LoadMasterData();
            var divisionId = Session["DivisionId"];

            if (divisionId != null)
                fieldTemplateData.GetAndBindRequests(divisionId.ToString());

        }

        #endregion
    }
}