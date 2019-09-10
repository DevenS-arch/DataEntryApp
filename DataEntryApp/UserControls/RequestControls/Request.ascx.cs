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
    public partial class Request : System.Web.UI.UserControl
    {
        #region Event handlers

        protected override void OnInit(EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadMasterData();
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
               

                var duplicateRequest = requestBLL.GetRequest(req);
                if (duplicateRequest == null || duplicateRequest.Id == req.Id)
                {
                    requestBLL.UpdateRequests(req);
                }
                else
                {
                    Ext.Net.Notification.Show(new Ext.Net.NotificationConfig
                    {
                        Title = "Notification",
                        Icon = Ext.Net.Icon.Information,
                        AutoHide = true,
                        HideDelay = 2000,
                        Html = "Request already exists!"

                    });
                }

                LoadMasterData();
            }
            catch (Exception ex)
            {
            }
        }

        [DirectMethod]
        public void OnDeleteRequest(object request)
        {
            var requestBLL = new RequestBLL();

            var req = JsonConvert.DeserializeObject<RequestDTO>(request.ToString());

            requestBLL.DeleteRequests(req);

            LoadMasterData();
        }
        #endregion

        #region Private helper methods

        private void LoadMasterData()
        {
            var division = new DivisionBLL().GetDivisions();

            this.ReqDivisionStore.DataSource = division;
            this.ReqDivisionStore.DataBind();

            var requests = new RequestBLL().GetRequests();

            this.RequestStore.DataSource = requests;
            this.RequestStore.DataBind();
            //this.RequestStore.Reload();
        }

    #endregion

}

}