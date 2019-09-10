using TechTicket.DataEntry.BL;
using TechTicket.DataEntry.Entities;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TechTicket.DataEntry.UserControls
{
    public partial class TemplateList : System.Web.UI.UserControl
    {

        #region Properties

        public string DivisionId
        {
            get
            {
                var selectedDivision = X.GetCmp<ComboBox>(nameof(cboxDivision)).Value;

                if (selectedDivision != null)
                    return selectedDivision.ToString();
                else
                    return null;

            }
        }

        public string RequestId
        {
            get
            {
                var selectedDivision = X.GetCmp<ComboBox>(nameof(cboxRequest)).Value;

                if (selectedDivision != null)
                    return selectedDivision.ToString();
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

        public List<EmailTemplateFieldDTO> FieldList { get; set; } = new List<EmailTemplateFieldDTO>();

        public List<FieldOptionDTO> FieldOptionList { get; set; } = new List<FieldOptionDTO>();

        public string FieldType { get; set; }

        private Dictionary<string, string> _toEmailLkp = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"Rasier - Invoice", "invoices@jamesriverins.com" }
            ,{"Rasier - W9", "invoices@jamesriverins.com" }
            ,{"Rasier - Letters", "Letters@jamesriverins.com" }
            ,{"Rasier - Sharefile", "Miscellaneous@jamesriverins.com" }
            ,{"Rasier - Fax", "Miscellaneous@jamesriverins.com" }
            ,{"Rasier - PIP Claim", "Claims@jamesriverins.com" }
            ,{"Rasier - Collision Claim", "Claims@jamesriverins.com" }
            ,{"Rasier - Reassignment", "Claims@jamesriverins.com" }
            ,{"Rasier - Reset Claim", "Claims@jamesriverins.com" }
            ,{"Core - Split file", "Core.Requests@jamesriverins.com" }
            ,{"Core - Reset Requests", "Core.Requests@jamesriverins.com" }
            ,{"Core - Transfer Request", "Core.Requests@jamesriverins.com" }
            ,{"Core - Rotation Requests", "Core.Requests@jamesriverins.com" }
            ,{"Core - Invoice", "Core.invoices@jamesriverins.com" }
            ,{"Core - W9", "Core.invoices@jamesriverins.com" }
            ,{"Core - Letters", "Core.Letters@jamesriverins.com" }
            ,{"Core - Sharefile", "Core.Miscellaneous@jamesriverins.com" }
            ,{"Core - Fax", "Core.Miscellaneous@jamesriverins.com" }
            ,{"Core - CMS Calls", "Core.Miscellaneous@jamesriverins.com" }
            ,{"Lit - Bulk Lawsuits", "Lit.Requests@jamesriverins.com" }
            ,{"Lit - Rotations", "Lit.Requests@jamesriverins.com" }
            ,{"Lit - Claim Transfer", "LitClaims@jamesriverins.com" }
            ,{"Lit - Claim Reset", "LitClaims@jamesriverins.com" }
            ,{"Lit - Claim Setup", "LitClaims@jamesriverins.com" }
            ,{"Lit - PIP Claim", "LitClaims@jamesriverins.com" }
            ,{"Lit - Invoice", "Lit.invoices@jamesriverins.com" }
            ,{"Lit - W9", "Lit.invoices@jamesriverins.com" }
            ,{"Lit - Letters", "Lit.letters@jamesriverins.com" }
            ,{"Lit - Sharefile", "Lit.miscellaneous@jamesriverins.com" }
            ,{"Lit - Fax", "Lit.miscellaneous@jamesriverins.com" }
            ,{"Lit - CMS Calls", "Lit.miscellaneous@jamesriverins.com" }
            ,{"Total Loss - Request", "TotalLoss@jamesriverins.com" }

        };
        #endregion

        #region Event handlers

        protected override void OnInit(EventArgs e)
        {
            //if (!IsPostBack && !X.IsAjaxRequest)
            //    GenerateEmailTemplate(33);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadMasterData();
                //GenerateEmailTemplate(33);
            }

        }

        protected void OnAddClick(object sender, DirectEventArgs args)
        {

            //    if (RequestId.HasValue)
            //    {
            //        var requestId = RequestId.Value;
            //        var emailTemplate = Get<EmailTemplateDTO>(string.Format(EMAIL_TEMPLATE_BY_REQUEST, requestId));
            //        List<Tuple<string, string>> emailData = GetData(requestId, emailTemplate);
            //        DisplayEmailPreview(emailData, emailTemplate);
            //    }

        }

        protected void OnDivisionSelected(object sender, DirectEventArgs e)
        {
            if (DivisionId != null)
            {
                if(Session["DivisionId"] != null && !DivisionId.Equals(Session["DivisionId"].ToString()))
                {
                    cboxRequest.Clear();
                    cboxRequest.EmptyText = "Select Request";
                    pnlTemplateGrid.Hidden = true;
                    cntLabel.Hidden = true;
                    pnlAddTemplateButton.Hidden = true;
                }
                Session["DivisionId"] = DivisionId;
                Session["DivisionName"] = cboxDivision.SelectedItem.Text;               
                GetAndBindRequests(DivisionId);
            }
        }

        public void GetAndBindRequests(string divisionId)
        {
            var requests = new RequestBLL().GetRequestsForDivision(divisionId);
            strRequests.DataSource = requests;
            strRequests.DataBind();
        }

        protected void OnRequestSelected(object sender, DirectEventArgs e)
        {
            if (RequestId != null)
            {
                Session["RequestId"] = RequestId;
                Session["RequestName"] = cboxRequest.SelectedItem.Text;
                GenerateEmailTemplate(RequestId);
            }

        }

        private void GenerateEmailTemplate(string requestId)
        {

            var emailTemplate = new EmailTemplateBLL().GetEmailTemplate(requestId);
            //Session["EmailTemplate"] = emailTemplate;

            if (emailTemplate != null)
            {


                Session["TemplateId"] = emailTemplate.Id;
                pnlTemplateGrid.Hidden = false;
                cntLabel.Hidden = true;
                pnlAddTemplateButton.Hidden = true;

                this.Store1.DataSource = new object[]
                    {
                    emailTemplate
                    };
                this.Store1.DataBind();
            }
            else
            {
                pnlTemplateGrid.Hidden = true;
                cntLabel.Hidden = false;
                pnlAddTemplateButton.Hidden = false;
            }

        }


        [DirectMethod]
        private void ShowWindow()
        {
            this.Window1.Visible = true;
            this.btnAddTemplate.Disable();
        }

        #endregion

        #region Private helper methods

        public void LoadMasterData()
        {
            var data = (List<DivisionDTO>)new DivisionBLL().GetDivisions();
            strDivsion.DataSource = data;
            strDivsion.DataBind();
            //pnlTemplateGrid.Hidden = true;
            //cntLabel.Hidden = true;
            //pnlAddTemplateButton.Hidden = true;
        }


        #endregion
        [DirectMethod]
        public void DeleteTemplate()
        {
            string templateId, requestId;
            if (Session["TemplateId"] != null)
            {
                templateId = Session["TemplateId"].ToString();
                new EmailTemplateBLL().DeleteEmailTemplate(templateId);
                requestId = Session["RequestId"].ToString();
                GenerateEmailTemplate(requestId);
            }

        }

        #region Window methods
        protected void Select_RadioButton(object sender, DirectEventArgs e)
        {


            if (rdHidden.Checked)
                return;

            Session["FieldOptions"] = null;
            cbxFieldOptions.Reset();
            //cbxFieldOptions.remove;
            strFieldOptions.RemoveAll();
            int optionListOffset = 0, saveTemplateOffset = 0;
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }

            //set field type
            FieldType = X.GetCmp<RadioGroup>("rdRadioGroup").CheckedItems[0].InputValue;
            this.FormPanelFieldData.Title = FieldType + " Field";
            Session["FieldType"] = FieldType;

            pnlFieldOptions.Hidden = true;

            //set panel size
            if (FieldType == "Dropdown")
            {
                optionListOffset = 110;
                pnlFieldOptions.Hidden = false;
            }
            panelFieldData.Height = 280 + optionListOffset;

            //set the window size if/else count>0
            if (FieldList.Count > 0)
            {
                saveTemplateOffset = 30;
            }
            this.Window1.Height = 470 + optionListOffset + saveTemplateOffset;

            this.Window1.X = 200;

            //show the form panel
            var panel = X.GetCmp<Ext.Net.Panel>("panelFieldData");
            panel.Hidden = false;

            // cbxDataType.Set(  "String","String");
            // cbxDataType.Disable();

            // this.cbxDataType.SelectedItems.Add(new Ext.Net.ListItem { Text = "String", Value = "String" });
            // this.cbxDataType.UpdateSelectedItems();


            //reset form
            FormPanelFieldData.Reset();
            cbxDataType.SelectedItem.Value = "string";

            var v = cbxDataType.Items;


        }

        protected void SaveField(object sender, DirectEventArgs e)
        {
            var isValid = true;//CheckValidity();
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
            }
            return !isDuplicate;
        }

        protected void SaveFieldAfterValidation()
        {
            //get fieldOptionList
            List<FieldOptionDTO> foList = new List<FieldOptionDTO>();
            if (Session["FieldOptions"] != null)
            {
                foList = (List<FieldOptionDTO>)Session["FieldOptions"];
            }

            //create a field obj on save field
            var DataType = cbxDataType.Value;
            var DefaultValue = X.GetCmp<TextField>("txDefaultValue").Text;
            var DisplayName = X.GetCmp<TextField>("txDisplayName").Text;
            var FieldName = X.GetCmp<TextField>("txFieldName").Text;
            var FieldOrder = Convert.ToInt32(X.GetCmp<NumberField>("txFieldOrder").Text);
            var FieldType = Session["FieldType"].ToString();
            var IsAllowBlank = Convert.ToBoolean(cbxAllowBlank.Value);

            var field = new EmailTemplateFieldDTO()
            {
                DataType = Convert.ToString(DataType),
                DefaultValue = DefaultValue,
                DisplayName = DisplayName,
                FieldName = FieldName,
                FieldOrder = FieldOrder,
                FieldType = FieldType,
                IsAllowBlank = IsAllowBlank,
                FieldOptions = foList,
            };

            if (FieldType.Equals("DropDown", StringComparison.InvariantCultureIgnoreCase))
                field.DataType = "string";

            if (field.DataType == "Alphanumeric Text")
                field.FormatRegEx = @"/[\w\s]/";

            if (short.TryParse(txtMaxLength.Text, out short maxLength))
                field.MaxLength = maxLength;

            //get fieldList from session if exists
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }

            FieldList.Add(field);

            //update session
            Session["FieldList"] = FieldList;

            //form reset
            FormPanelFieldData.Reset();

            //hide the form panel
            X.GetCmp<Ext.Net.Panel>("panelFieldData").Hidden = true;

            //set window height as form panel is hidden
            this.Window1.Height = 240;

            //reset radio group to select again
            //rdRadioGroup.Reset();
            rdHidden.Checked = true;

            //reset fieldOption session value
            Session["FieldOptions"] = null;

            //show template save button if >0 field are added
            if (FieldList.Count > 0)
            {
                //X.GetCmp<Ext.Net.Button>("btnSaveTemplate").Show();
                btnSaveTemplate.Hidden = false;
                btnSaveTemplate.Enable();
            }
        }

        protected void SaveTemplate(object sender, DirectEventArgs e)
        {
            var fList = (List<EmailTemplateFieldDTO>)Session["FieldList"];

            if (fList == null || fList.Count == 0)
            {
                X.Msg.Alert("Save Email Template", "Please add atleast on template field.").Show();
                return;
            }

            string divisionId = null, divisionName = null, requestId = null, requestName = null;

            if (Session["DivisionId"] != null && Session["RequestId"] != null)
            {
                divisionId = Session["DivisionId"].ToString();
                requestId = Session["RequestId"].ToString();
                divisionName = Session["DivisionName"].ToString();
                requestName = Session["RequestName"].ToString();
            }

            EmailTemplateDTO dtoTemplate = new EmailTemplateDTO()
            {
                RequestId = requestId,
                Fields = fList,
                TemplateName = divisionName + "-" + requestName,
                AttachmentRequired = true
            };

            if (_toEmailLkp.TryGetValue($"{divisionName} - {requestName}", out string toEmail))
                dtoTemplate.To = new List<string> { toEmail };
            else
                dtoTemplate.To = new List<string>() { "invoices@jamesriverins.com" };

            this.Window1.Hide();
            Session["FieldList"] = null;
            Session["FieldType"] = null;
            this.btnAddTemplate.Enable();
            this.FieldList = new List<EmailTemplateFieldDTO>();
            if (dtoTemplate != null)
            {
                new EmailTemplateBLL().SaveEmailTemplate(dtoTemplate);
            }
            if (requestId != null)
            {
                GenerateEmailTemplate(requestId);
            }
        }

        protected void OnCloseWindow(object sender, DirectEventArgs e)
        {
            this.FieldList = new List<EmailTemplateFieldDTO>();
            Session["FieldList"] = null;
            Session["FieldType"] = null;
            //reset fieldOption session value
            Session["FieldOptions"] = null;
            this.btnAddTemplate.Enable();
            //form reset
            FormPanelFieldData.Reset();
            //hide the form panel
            X.GetCmp<Ext.Net.Panel>("panelFieldData").Hidden = true;
            //set window height as form panel is hidden
            this.Window1.Height = 200;
            //reset radio group to select again
            //rdRadioGroup.Reset();
            rdHidden.Checked = true;
        }

        protected void AddFieldOption(object sender, DirectEventArgs e)
        {
            // update option field list
            FieldOptionList = new List<FieldOptionDTO>();
            if (Session["FieldOptions"] != null)
            {
                FieldOptionList = (List<FieldOptionDTO>)Session["FieldOptions"];
            }

            var fieldOptionText = X.GetCmp<TextField>("txtFieldOptionText").Text;
            //var fieldOptionValue = X.GetCmp<TextField>("txtFieldOptionValue").Text;

            var newOption = new FieldOptionDTO() { DisplayName = fieldOptionText, Value = fieldOptionText };
            FieldOptionList.Add(newOption);
            Session["FieldOptions"] = FieldOptionList;

            // Insert item in list UI
            if (fieldOptionText != "")
            {
                cbxFieldOptions.InsertItem(0, fieldOptionText, fieldOptionText);
                X.GetCmp<TextField>("txtFieldOptionText").Text = "";
                //X.GetCmp<TextField>("txtFieldOptionValue").Text = "";
            }

        }

        protected void RemoveOption(object sender, DirectEventArgs e)
        {
            var valueToRemove = cbxFieldOptions.Value.ToString();

            //remove item from list
            if (Session["FieldOptions"] != null)
            {
                FieldOptionList = (List<FieldOptionDTO>)Session["FieldOptions"];
            }

            FieldOptionList = FieldOptionList.Where(fo => fo.Value != valueToRemove).ToList();

            Session["FieldOptions"] = FieldOptionList;

            //remove item from UI
            cbxFieldOptions.RemoveByValue(valueToRemove);
            cbxFieldOptions.Clear();

        }
        #endregion
    }

}