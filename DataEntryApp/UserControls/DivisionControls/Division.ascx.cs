using DataEntryApp.BL;
using DataEntryApp.Entities;
using Ext.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataEntryApp.UserControls
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UC")]
    public partial class Division : System.Web.UI.UserControl
    {

        #region Properties

        //public string DivisionId
        //{
        //    get
        //    {
        //        string selectedDivision = X.GetCmp<ComboBox>(nameof(cboxDivision)).Value.ToString();

        //        // var selectedDivisionss = selectedDivision.ToString().Replace("divisions/","");



        //        if (selectedDivision != null)
        //            return selectedDivision;
        //        else
        //            return null;

        //    }
        //}

        //public string RequestId
        //{
        //    get
        //    {
        //        string selectedRequest = X.GetCmp<ComboBox>(nameof(cboxRequest)).Value.ToString();

        //        //var selectedRequestss = selectedRequest.ToString().Replace("requests/", "");

        //        if (selectedRequest != null)
        //            return selectedRequest;
        //        else
        //            return null;

        //    }

        //}

        //public string RequestName
        //{
        //    get
        //    {
        //        return X.GetCmp<ComboBox>(nameof(cboxRequest)).SelectedItem.Text;
        //    }

        //}

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


        protected void OnDivisionSelected(object sender, DirectEventArgs e)
        {

           
                var requests = new RequestBLL().GetRequests();

                if (requests.Count < 0)
                {
                    this.RequestPanel.Visible = false;

                }

                this.RequestStore.DataSource = requests;
                this.RequestStore.DataBind();
            

        }
        [DirectMethod]
        public void OnAddDivision(object division)
        {
            try
            {
                //this.Window.Visible = true;
                //if (RequestId != null)
                //{
                //    this.Response.Redirect("~/EditExt.aspx");
                //    //Response.Redirect("~/EditExt.aspx");
                //}
            }
            catch (Exception ex)
            {
            }

        }

        [DirectMethod]
        protected void OnAddRequest(object sender, DirectEventArgs args)
        {
            try
            {
               // this.Window.Visible = true;
                //if (RequestId != null)
                //{
                //    this.Response.Redirect("~/EditExt.aspx");
                //    //Response.Redirect("~/EditExt.aspx");
                //}
            }
            catch (Exception ex)
            {
            }

        }

        protected void OnSaveDivision(object sender, DirectEventArgs e)
        {
            try
            {

                //var val = this.dvName.Text;

                //if (val != null)
                //{
                //    var divisions = new List<DivisionDTO>()
                //{
                //    new DivisionDTO { DivisionName = val }
                //};

                //    var divisionBll = new DivisionBLL();
                //    divisionBll.AddDivisions(divisions);

                //    //this.dvName.Text = null;

                //    LoadMasterData();
                //}
            }
            catch (Exception ex)
            {

            }
        }

        protected void OnRequestSelected(object sender, DirectEventArgs e)
        {
            //if (RequestId != null)
            //{
            //    var emailTemplate = new EmailTemplateBLL().GetEmailTemplate(RequestId);

            //    var emailTemplateFields = new EmailTemplateFieldsBLL().GetEmailTemplateFields(emailTemplate.Id);
            //    this.Store1.DataSource = emailTemplateFields;
            //    this.Store1.DataBind();
            //    //GenerateEmailTemplate(RequestId.Value);
            //}

        }

        [DirectMethod]
        public void OnDeleteDivision(object division)
        {
            var divisionBLL = new DivisionBLL();

            var div = JsonConvert.DeserializeObject<DivisionDTO>(division.ToString());

            divisionBLL.DeleteDivisions(div);

            LoadMasterData();
        }

        [DirectMethod]
        public void OnDeleteRequest(object request)
        {

        }
        #endregion

        #region Private helper methods

        private void LoadMasterData()
        {
            var division = new DivisionBLL().GetDivisions();

            this.DivisionStore.DataSource = division;
            this.DivisionStore.DataBind();

            this.Store1.DataSource = division;
            this.Store1.DataBind();

            var requests = new RequestBLL().GetRequests();

            this.RequestStore.DataSource = requests;
            this.RequestStore.DataBind();

        }

        [DirectMethod]
        public void EditDivision(string field, string oldValue, string newValue, object division)
        {

            var div = JsonConvert.DeserializeObject<DivisionDTO>(division.ToString());
            try
            {
                //string message = "<b>Property:</b> {0}<br /><b>Field:</b> {1}<br /><b>Old Value:</b> {2}<br /><b>New Value:</b> {3}";

                //// Send Message...
                //X.Msg.Notify(new NotificationConfig()
                //{
                //    Title = "Edit Record #" + div.Id.ToString(),
                //    Html = string.Format(message, div.Id, field, oldValue, newValue),
                //    HideDelay = 1500,
                //    Width = 250,
                //    Height = 150
                //}).Show();



                //this.DivisionPanel.GetStore().GetById(div.Id).Commit();

                var divisionBLL = new DivisionBLL();
                divisionBLL.UpdateDivisions(div);
            }
            catch (Exception ex)
            {
            }
        }

        [DirectMethod]
        public void EditRequest(string field, string oldValue, string newValue, object request)
        {

            var req = JsonConvert.DeserializeObject<RequestDTO>(request.ToString());
             
            try
            {
                //string message = "<b>Property:</b> {0}<br /><b>Field:</b> {1}<br /><b>Old Value:</b> {2}<br /><b>New Value:</b> {3}";

                //// Send Message...
                //X.Msg.Notify(new NotificationConfig()
                //{
                //    Title = "Edit Record #" + req.Id.ToString(),
                //    Html = string.Format(message, req.Id, field, oldValue, newValue),
                //    HideDelay = 1500,
                //    Width = 250,
                //    Height = 150
                //}).Show();



                //this.RequestPanel.GetStore().GetById(req.Id).Commit();

                var requestBLL = new RequestBLL();
                requestBLL.UpdateRequests(req);

                LoadMasterData();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }

}