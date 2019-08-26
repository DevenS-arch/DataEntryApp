using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using TechTicketPOC.BLL;
//using TechTicketPOC.Common.Extensions;
//using TechTicketPOC.Entities;
//using static TechTicketPOC.Entities.Constants.FieldDataType;
//using static TechTicketPOC.AppCode.Constants.ControlTypes;
//using static TechTicketPOC.Common.Constants.SessionKeys;
//using static TechTicketPOC.Common.SessionWrapper;

namespace DataEntryApp.UserControls
{
    public partial class AddTemplate : System.Web.UI.UserControl
    {

        #region Properties

        public int? DivisionId
        {
            get
            {
                //var selectedDivision = X.GetCmp<ComboBox>(nameof(cboxDivision)).Value;

                //if (selectedDivision != null && int.TryParse(selectedDivision.ToString(), out int divisionId))
                   // return divisionId;
               // else
                    return null;

            }
        }

        public int? RequestId
        {
            get
            {
                //var selectedDivision = X.GetCmp<ComboBox>(nameof(cboxRequest)).Value;

                //if (selectedDivision != null && int.TryParse(selectedDivision.ToString(), out int divisionId))
                //    return divisionId;
                //else
                    return null;

            }

        }

        public string RequestName
        {
            get
            {
                //return X.GetCmp<ComboBox>(nameof(cboxRequest)).SelectedItem.Text;
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

        protected void OnSave(object sender, DirectEventArgs args)
        {

            if (RequestId.HasValue)
            {
                //var requestId = RequestId.Value;
                //var emailTemplate = Get<EmailTemplateDTO>(string.Format(EMAIL_TEMPLATE_BY_REQUEST, requestId));
                //List<Tuple<string, string>> emailData = GetData(requestId, emailTemplate);
                //DisplayEmailPreview(emailData, emailTemplate);
            }

        }

        protected void OnCancel(object sender, DirectEventArgs args)
        {

            if (RequestId.HasValue)
            {
                //var requestId = RequestId.Value;
                //var emailTemplate = Get<EmailTemplateDTO>(string.Format(EMAIL_TEMPLATE_BY_REQUEST, requestId));
                //List<Tuple<string, string>> emailData = GetData(requestId, emailTemplate);
                //DisplayEmailPreview(emailData, emailTemplate);
            }

        }




        #endregion

        #region Private helper methods

        private void LoadMasterData()
        {
            //strDivsion.DataSource = new DivisionBLL().GetDivisions();
            //strDivsion.DataBind();
        }


        #endregion
    }

}