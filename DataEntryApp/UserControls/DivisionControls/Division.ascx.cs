using DataEntryApp.BL;
using DataEntryApp.Entities;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataEntryApp.UserControls
{
    public partial class Division : System.Web.UI.UserControl
    {

        #region Properties

        public string DivisionId
        {
            get
            {
                string selectedDivision = X.GetCmp<ComboBox>(nameof(cboxDivision)).Value.ToString();

               // var selectedDivisionss = selectedDivision.ToString().Replace("divisions/","");



                if (selectedDivision != null )
                    return selectedDivision;
                else
                    return null;

            }
        }

        public string RequestId
        {
            get
            {
                string selectedRequest = X.GetCmp<ComboBox>(nameof(cboxRequest)).Value.ToString();

                //var selectedRequestss = selectedRequest.ToString().Replace("requests/", "");

                if (selectedRequest != null )
                    return selectedRequest;
                else
                    return null;

            }

        }

        public string RequestName
        {
            get
            {
                return X.GetCmp<ComboBox>(nameof(cboxRequest)).SelectedItem.Text;
            }

        }

        #endregion

        #region Event handlers

        protected override void OnInit(EventArgs e)
        {
            //if (!IsPostBack && !X.IsAjaxRequest)
            //    GenerateEmailTemplate(33);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadMasterData();
               
                //GenerateEmailTemplate(33);
            }

        }

        protected void OnEmail(object sender, DirectEventArgs args)
        {
            try
            {

                if (RequestId != null)
                {
                    this.Response.Redirect("~/EditExt.aspx");
                    //Response.Redirect("~/EditExt.aspx");
                }
            }
            catch (Exception ex) {
            }

        }

        protected void OnDivisionSelected(object sender, DirectEventArgs e)
        {

            if (DivisionId != null)
            {
                var requests = new RequestBLL().GetRequests(DivisionId);
                strRequests.DataSource = requests;
                strRequests.DataBind();
            }

        }

        protected void OnRequestSelected(object sender, DirectEventArgs e)
        {
            if (RequestId != null)
            {
                var emailTemplate = new EmailTemplateBLL().GetEmailTemplate(RequestId);
                
                var emailTemplateFields = new EmailTemplateFieldsBLL().GetEmailTemplateFields(emailTemplate.Id);
                this.Store1.DataSource = emailTemplateFields;
                this.Store1.DataBind();
                //GenerateEmailTemplate(RequestId.Value);
            }

        }

        #endregion

        #region Private helper methods

        private void LoadMasterData()
        {
            strDivsion.DataSource = new DivisionBLL().GetDivisions();
            strDivsion.DataBind();
        }


        #endregion
    }

}