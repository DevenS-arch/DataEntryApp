using DataEntryApp.BL;
using DataEntryApp.Entities;
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
        public List<EmailTemplateFieldDTO> FieldList { get; set; } = new List<EmailTemplateFieldDTO>();


        public string FieldType { get; set; }
        #endregion

        #region Event handlers

        protected override void OnInit(EventArgs e)
        {
            //if (!IsPostBack && !X.IsAjaxRequest)
            //    GenerateEmailTemplate(33);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                this.GenerateEmailTemplate("requests/33");
                //FieldList = new List<EmailTemplateFieldDTO>();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadMasterData();
                //GenerateEmailTemplate(33);
            }

        }

        #endregion


        private void GenerateEmailTemplate(string requestId)
        {
            var emailTemplate = new EmailTemplateBLL().GetEmailTemplate(requestId);

            //if (emailTemplate != null)
            //    Set(string.Format(EMAIL_TEMPLATE_BY_REQUEST, requestId), emailTemplate);

            //GenerateFormControls(requestId);
            //AssignEventHandlers();
        }
        #region Private helper methods

        private void LoadMasterData()
        {
            //strDivsion.DataSource = new DivisionBLL().GetDivisions();
            //strDivsion.DataBind();
            //strDataType.DataSource = new List<Bind>()
            //{
            //    new Bind() {typeId = "Bool", typeValue = "Boolean" }
            //};
            //strDataType.DataBind();

        }

        protected void Select_RadioButton(object sender, DirectEventArgs e)
        {
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }

            //set the window height if/else count>0
            if (FieldList.Count > 0)
            {
                this.Window1.Height = 480;
            }
            else
            {
                this.Window1.Height = 445;
            }

            this.Window1.X = 200;

            //show the form panel
            var panel = X.GetCmp<Ext.Net.Panel>("panelFieldData");
            panel.Hidden = false;

            //reset form
            FormPanelFieldData.Reset();

            FieldType = X.GetCmp<RadioGroup>("rdRadioGroup").CheckedItems[0].InputValue;
            this.FormPanelFieldData.Title = FieldType + " Field";
            Session["FieldType"] = FieldType;
        }

        protected void SaveField(object sender, DirectEventArgs e)
        {
            var isValid = CheckValidity();
            if (isValid)
            {
                SaveFieldAfterValidation();
            }
        }

        protected bool CheckValidity()
        {
            string fieldValue = txFieldName.Text;
            var fieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            var isDuplicate = false;

            if (fieldList != null && fieldList.Count > 0)
            {
                //switch (fieldValue)
                //{
                //    case "txFieldName":
                //        isDuplicate = fieldList.Select(f => f.FieldName).Contains(fieldValue);
                //        break;
                //    case "txDisplayName":
                //        isDuplicate = fieldList.Select(f => f.DisplayName).Contains(fieldValue);
                //        break;
                //}
                isDuplicate = fieldList.Select(f => f.FieldName).Contains(fieldValue);
                txFieldName.IconCls = "icon - exclamation";
            }
            return !isDuplicate;
        }

        protected void SaveFieldAfterValidation()
        {
            //create a field obj on save field
            var DataType = X.GetCmp<ComboBox>(nameof(cbxDataType)).Value;
            var DefaultValue = X.GetCmp<TextField>("txDefaultValue").Text;
            var DisplayName = X.GetCmp<TextField>("txDisplayName").Text;
            var FieldName = X.GetCmp<TextField>("txFieldName").Text;
            var FieldOrder = Convert.ToInt32(X.GetCmp<TextField>("txFieldOrder").Text);
            var FieldType = Session["FieldType"].ToString();
            var IsAllowBlank = Convert.ToBoolean(cbxAllowBlank.Value);
            var v = new EmailTemplateFieldDTO()
            {
                DataType = Convert.ToString(DataType),
                DefaultValue = DefaultValue,
                DisplayName = DisplayName,
                FieldName = FieldName,
                FieldOrder = FieldOrder,
                FieldType = FieldType,
                IsAllowBlank = IsAllowBlank

            };

            //get fieldList from session if it there
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }

            FieldList.Add(v);

            //update session
            Session["FieldList"] = FieldList;

            //form reset
            FormPanelFieldData.Reset();

            //hide the form panel
            X.GetCmp<Ext.Net.Panel>("panelFieldData").Hidden = true;

            //set window height as form panel is hidden
            this.Window1.Height = 240;

            //reset radio group to select again
            rdRadioGroup.Reset();

            //show template save button if >0 field are added
            if (FieldList.Count > 0)
            {
                X.GetCmp<Ext.Net.Button>("btnSaveTemplate").Show();
            }
        }


        protected void SaveTemplate(object sender, DirectEventArgs e)
        {
            var fList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            EmailTemplateDTO dtoTemplate = new EmailTemplateDTO()
            {
                RequestId = "",
                Fields = fList
            };
            this.Window1.Hide();
            Session["FieldList"] = null;
            Session["FieldType"] = null;
            this.FieldList = new List<EmailTemplateFieldDTO>();
            if (dtoTemplate != null)
            {
                new EmailTemplateBLL().SaveEmailTemplate(dtoTemplate);
            }
        }

        protected void OnCloseWindow(object sender, DirectEventArgs e)
        {
            this.FieldList = new List<EmailTemplateFieldDTO>();
            Session["FieldList"] = null;
            Session["FieldType"] = null;
        }

        [DirectMethod]
        public object DirectCheckField(string value)
        {
            if (value == "Valid")
            {
                return true;
            }
            else
            {
                return "'Valid' is valid value only";
            }
        }

        protected void CheckField(object sender, RemoteValidationEventArgs e)
        {
            TextField field = (TextField)sender;

            var fieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            var isDuplicate = false;

            if (fieldList != null && fieldList.Count > 0)
            {
                switch (field.ID)
                {
                    case "txFieldName":
                        isDuplicate = fieldList.Select(f => f.FieldName).Contains(field.Text);
                        break;
                    case "txDisplayName":
                        isDuplicate = fieldList.Select(f => f.DisplayName).Contains(field.Text);
                        break;
                }
            }
            if (!isDuplicate)
            {
                e.Success = true;
            }
            else
            {
                e.Success = false;
                e.ErrorMessage = "Duplicate entry";
            }

            System.Threading.Thread.Sleep(1000);
        }
        #endregion
    }
}