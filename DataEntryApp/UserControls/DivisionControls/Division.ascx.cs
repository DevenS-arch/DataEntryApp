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

                var duplicateDivision = divisionBLL.GetDivision(div);
                if (duplicateDivision == null || duplicateDivision.Id == div.Id)
                {
                    divisionBLL.UpdateDivisions(div);
                }
                else {
                    Ext.Net.Notification.Show(new Ext.Net.NotificationConfig
                    {
                        Title = "Notification",
                        Icon = Ext.Net.Icon.Information,                        
                        AutoHide = true,
                        HideDelay=2000,
                        Html ="Division already exists!"
                        
                    });
                }
                LoadMasterData();

            }
            catch (Exception ex)
            {
            }
        }

        [DirectMethod]
        public void OnDeleteDivision(object division)
        {
            var divisionBLL = new DivisionBLL();

            var div = JsonConvert.DeserializeObject<DivisionDTO>(division.ToString());

            divisionBLL.DeleteDivisions(div);

            LoadMasterData();
        }

        #endregion

        #region Private helper methods

        private void LoadMasterData()
        {
            var division = new DivisionBLL().GetDivisions();

            this.DivisionStore.DataSource = division;
            this.DivisionStore.DataBind();

        }


        #endregion
    }

}