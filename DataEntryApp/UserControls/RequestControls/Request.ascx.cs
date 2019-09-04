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
    public partial class Request : System.Web.UI.UserControl
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

            if (DivisionId != null)
            {
                var requests = new RequestBLL().GetRequests();
                this.Store1.DataSource = requests;
                this.Store1.DataBind();
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