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

        private EmailTemplateDTO GenerateEmailTemplate(string requestId)
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
                return emailTemplate;
            }
            else
            {
                Session["TemplateId"] = null;
                pnlTemplateGrid.Hidden = true;
                cntLabel.Hidden = false;
                pnlAddTemplateButton.Hidden = false;
                return null;
            }

        }


        [DirectMethod]
        private void ShowWindow()
        {
            this.Window1.Visible = true;
            // this.btnAddTemplate.Disable();
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
                Session["TemplateId"] = null;
            }

        }

        [DirectMethod]
        public void EditTemplate()
        {
            if (Session["RequestId"] != null)
            {
                var requestId = Session["RequestId"].ToString();
                EmailTemplateDTO emailTemplate = GenerateEmailTemplate(requestId);
                //this.Window1.Visible = true;
                BindTemplate(emailTemplate);
            }
        }

        public void BindTemplate(EmailTemplateDTO emailTemplate)
        {
            cbxFieldList.Hidden = false;
            cbxFieldList.Store[0].DataSource = emailTemplate.Fields;
            cbxFieldList.DataBind();
            Session["FieldList"] = emailTemplate.Fields;
        }
        #region Window methods


        protected void EnableFieldDataForm(bool isNewField)
        {
            // reset field option data
            Session["FieldOptions"] = null;
            cbxFieldOptions.Reset();
            strFieldOptions.RemoveAll();

            //show the field data panel
            var panel = X.GetCmp<Ext.Net.Panel>("panelFieldData");
            panel.Hidden = false;

            //set field type
            if (isNewField)
            {
                FieldType = X.GetCmp<RadioGroup>("rdRadioGroup").CheckedItems[0].InputValue;
                this.FormPanelFieldData.Title = "New " + FieldType + " Field";

            }

            //Update field type
            Session["FieldType"] = FieldType;

            //reset existing field cbox on select new element/vice-versa
            if (isNewField)
            {
                ResetFieldList();
            }
            else
            {
                rdHidden.Checked = true;
            }

            //set panel size
            int optionListOffset = 0, saveTemplateOffset = 0, fieldListOffset = 0;
            pnlFieldOptions.Hidden = true;
            if (FieldType == "Dropdown")
            {
                optionListOffset = 65;
                pnlFieldOptions.Hidden = false;
            }
            panelFieldData.Height = 280 + optionListOffset;

            //set the window size if/else count>0
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }
            if (FieldList.Count > 0)
            {
                saveTemplateOffset = 30;
                fieldListOffset = 40;
            }
            this.Window1.Height = 470 + optionListOffset + saveTemplateOffset + fieldListOffset;

            //reset form
            FormPanelFieldData.Reset();
            this.Window1.X = 200;



        }
        protected void Select_RadioButton(object sender, DirectEventArgs e)
        {

            if (rdHidden.Checked)
                return;

            EnableFieldDataForm(true);

            //Hide delete button for new field
            btnDelete.Hidden = true;

            /*
            Session["FieldOptions"] = null;
            cbxFieldOptions.Reset();
            //cbxFieldOptions.remove;
            strFieldOptions.RemoveAll();
            int optionListOffset = 0, saveTemplateOffset = 0;
            

            //set field type
            FieldType = X.GetCmp<RadioGroup>("rdRadioGroup").CheckedItems[0].InputValue;
            this.FormPanelFieldData.Title = FieldType + " Field";
            Session["FieldType"] = FieldType;

            pnlFieldOptions.Hidden = true;

            //set panel size
            if (FieldType == "Dropdown")
            {
                optionListOffset = 65;
                pnlFieldOptions.Hidden = false;
            }
            panelFieldData.Height = 280 + optionListOffset;

            //set the window size if/else count>0
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }
            if (FieldList.Count > 0)
            {
                saveTemplateOffset = 30;
            }
            this.Window1.Height = 510 + optionListOffset + saveTemplateOffset;

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

            var v = cbxDataType.Items;*/


        }

        protected void SaveField(object sender, DirectEventArgs e)
        {
            var isValid = true;//CheckValidity();
            if (isValid)
            {
                SaveFieldAfterValidation();
            }
        }

        protected void CancelField(object sender, DirectEventArgs e)
        {
            DisableFieldDataForm();
        }

        protected void DeleteField(object sender, DirectEventArgs e)
        {
            //remove field from list and UI
            RemoveFieldFromList(false);
            DisableFieldDataForm();
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

        public void DisableFieldDataForm()
        {
            int fieldListOffset = 0, saveTemplateOffset = 0;
            //form reset
            FormPanelFieldData.Reset();

            //hide the form panel
            X.GetCmp<Ext.Net.Panel>("panelFieldData").Hidden = true;



            //reset radio group to select again/fieldList
            //rdRadioGroup.Reset();
            rdHidden.Checked = true;
            ResetFieldList();

            //reset fieldOption session value
            Session["FieldOptions"] = null;

            //get fieldList from session if exists
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
                if (FieldList.Count > 0)
                {
                    btnSaveTemplate.Hidden = false;
                    btnSaveTemplate.Enable();
                    cbxFieldList.Hidden = false;
                    fieldListOffset = 15;
                    saveTemplateOffset = 40;
                }
                else
                {
                    btnSaveTemplate.Hidden = true;
                    btnSaveTemplate.Disable();
                    cbxFieldList.Hidden = true;
                    fieldListOffset = 0;
                    saveTemplateOffset = 0;
                }
            }
            this.Window1.Height = 200 + fieldListOffset + saveTemplateOffset;

        }

        protected void SaveFieldAfterValidation()
        {
            var isTemplateUpdate = false;
            if (Session["TemplateId"] != null)
            {
                isTemplateUpdate = true;
            }

            

            //Remove field from list if field is updated and get the field (if template is updated)
            var field = RemoveFieldFromList(isTemplateUpdate);

            //get fieldList from session if exists
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }

            //get fieldOptionList
            List<FieldOptionDTO> foList = new List<FieldOptionDTO>();
            if (Session["FieldOptions"] != null)
            {
                foList = (List<FieldOptionDTO>)Session["FieldOptions"];
                //if template is updating, update field id in field options 
                if (isTemplateUpdate)
                {
                    foList.ForEach(fo => fo.TemplateFieldId = field.Id);
                }
            }

            ////If field is updating then remove the field from UI and data structure
            //if (Session["SelectedFieldIndex"]!=null)
            //{
            //    if (Session["SelectedFieldValue"] !=null && FieldList != null)
            //    {
            //        var selectedValue = Session["SelectedFieldValue"].ToString();
            //        FieldList.RemoveAll(f => f.FieldName == selectedValue);
            //    }
            //    cbxFieldList.RemoveByIndex(Convert.ToInt32(Session["SelectedFieldIndex"]));
            //}



            //create a field obj on save field
            var DataType = cbxDataType.Value;
            var DefaultValue = X.GetCmp<TextField>("txDefaultValue").Text;
            var DisplayName = X.GetCmp<TextField>("txDisplayName").Text;
            var FieldName = X.GetCmp<TextField>("txFieldName").Text;
            var FieldOrder = Convert.ToInt32(X.GetCmp<NumberField>("txFieldOrder").Text);
            var FieldType = Session["FieldType"].ToString();
            var IsAllowBlank = Convert.ToBoolean(cbxAllowBlank.Value);

            //update the field instance
            field.DataType = Convert.ToString(DataType);
            field.DefaultValue = DefaultValue;
            field.DisplayName = DisplayName;
            field.FieldName = FieldName;
            field.FieldOrder = FieldOrder;
            field.FieldType = FieldType;
            field.IsAllowBlank = IsAllowBlank;
            field.FieldOptions = foList;

            //if template isupdaing and new field is added, update templateid of the field
            if(isTemplateUpdate && field.EmailTemplateId==null)
            {
                field.EmailTemplateId = Session["TemplateId"].ToString();
            }

            if (FieldType.Equals("DropDown", StringComparison.InvariantCultureIgnoreCase))
                field.DataType = "string";

            if (field.DataType == "Alphanumeric Text")
                field.FormatRegEx = @"/[\w\s]/";

            if (short.TryParse(txtMaxLength.Text, out short maxLength))
                field.MaxLength = maxLength;


            FieldList.Add(field);

            //update session
            Session["FieldList"] = FieldList;

            ////form reset
            //FormPanelFieldData.Reset();

            ////hide the form panel
            //X.GetCmp<Ext.Net.Panel>("panelFieldData").Hidden = true;



            ////reset radio group to select again/fieldList
            ////rdRadioGroup.Reset();
            //rdHidden.Checked = true;
            //cbxFieldList.Reset();

            ////reset fieldOption session value
            //Session["FieldOptions"] = null;

            DisableFieldDataForm();

            //show template save button if >0 field are added
            if (FieldList.Count > 0)
            {
                //btnSaveTemplate.Hidden = false;
                //btnSaveTemplate.Enable();
                //cbxFieldList.Hidden = false;
                // FieldName = field.FieldName;
                cbxFieldList.InsertItem(0, FieldName, FieldName);
                //fieldListOffset = 15;

            }

            //set window height as form panel is hidden
            //this.Window1.Height = 240 + fieldListOffset;
        }

        protected void ResetFieldList()
        {
            Session["SelectedFieldValue"] = null;
            Session["SelectedFieldIndex"] = null;
            cbxFieldList.Reset();
        }

        protected EmailTemplateFieldDTO RemoveFieldFromList(bool isTemplateUpdate)
        {
            EmailTemplateFieldDTO field = new EmailTemplateFieldDTO();
            //get fieldList from session if exists
            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }
            else
            {
                return field;
            }

            //If field is updating/deleting then remove the old field from UI and data structure
            if (Session["SelectedFieldIndex"] != null)
            {
                if (Session["SelectedFieldValue"] != null && FieldList != null)
                {
                    var selectedValue = Session["SelectedFieldValue"].ToString();
                    //if template is updating get the removed field instance (if field is updating)
                    if (isTemplateUpdate)
                    {
                        field = FieldList.Where(f => f.FieldName == selectedValue).FirstOrDefault();
                    }
                    FieldList.RemoveAll(f => f.FieldName == selectedValue);
                }
                cbxFieldList.RemoveByIndex(Convert.ToInt32(Session["SelectedFieldIndex"]));
            }

            Session["FieldList"] = FieldList;
            return field;
        }

        protected void SaveTemplate(object sender, DirectEventArgs e)
        {
            var isTemplateUpdate = false;
            if (Session["TemplateId"] != null)
            {
                isTemplateUpdate = true;
            }
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
            if (isTemplateUpdate)
            {
                dtoTemplate.Id = Session["TemplateId"].ToString();

            }

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
                if (isTemplateUpdate)
                {
                    new EmailTemplateBLL().UpdateEmailTemplate(dtoTemplate);
                }
                else
                {
                    new EmailTemplateBLL().SaveEmailTemplate(dtoTemplate);
                }
            }
            if (requestId != null)
            {
                GenerateEmailTemplate(requestId);
            }
            //hide the field list
            ResetFieldList();
            cbxFieldList.Hidden = true;
            strFieldList.RemoveAll();

            //hide save template button
            btnSaveTemplate.Hidden = true;
            btnSaveTemplate.Disable();

            //reset window title
            Window1.Title = "Email Template";

            //X.Msg.Alert("Template","Email Template saved successfully!","Handler")   .Show();
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
            cbxFieldList.Hidden = true;
            ResetFieldList();
            strFieldList.RemoveAll();
            //hide save template button
            btnSaveTemplate.Hidden = true;
            btnSaveTemplate.Disable();
            //reset window title
            Window1.Title = "Email Template";
        }

        protected void AddFieldOption(object sender, DirectEventArgs e)
        {
            

            var fieldOptionText = X.GetCmp<TextField>("txtFieldOptionText").Text;
            //var fieldOptionValue = X.GetCmp<TextField>("txtFieldOptionValue").Text;



            // Insert item in list UI and data structure
            if (fieldOptionText != "")
            {
                // get option field list
                FieldOptionList = new List<FieldOptionDTO>();
                if (Session["FieldOptions"] != null)
                {
                    FieldOptionList = (List<FieldOptionDTO>)Session["FieldOptions"];
                }

                //update data structure
                var newOption = new FieldOptionDTO() { DisplayName = fieldOptionText, Value = fieldOptionText };
                FieldOptionList.Add(newOption);
                Session["FieldOptions"] = FieldOptionList;

                //update UI
                cbxFieldOptions.InsertItem(0, fieldOptionText, fieldOptionText);
                X.GetCmp<TextField>("txtFieldOptionText").Text = "";
                //X.GetCmp<TextField>("txtFieldOptionValue").Text = "";
            }
            var ss = (List<FieldOptionDTO>)Session["FieldOptions"];

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

        protected void SelectField(object sender, DirectEventArgs e)
        {

            //store the selected field properties
            var selectedValue = cbxFieldList.Value.ToString();
            Session["SelectedFieldIndex"] = cbxFieldList.SelectedItem.Index;
            Session["SelectedFieldValue"] = selectedValue;

            // cbxFieldList.RemoveByIndex(v);
            //var selectedValue = cbxFieldList.Value.ToString();

            //Enable cancel button
            //btnCancel.Hidden = false;

            if (Session["FieldList"] != null)
            {
                FieldList = (List<EmailTemplateFieldDTO>)Session["FieldList"];
            }

            //  FieldList.RemoveAll(f => f.FieldName == selectedValue);

            //get the selected field to edit
            var selectedField = FieldList.Where(f => f.FieldName == selectedValue).Select(f => f).ToList().FirstOrDefault();

            //store the field type of selected field
            FieldType = selectedField.FieldType;
            Session["FieldType"] = FieldType;
            FormPanelFieldData.Title = FieldType + " Field";



            //reset form
            EnableFieldDataForm(false);

            //enable delete button if existing field is selected and count of fields > 1
            if (FieldList != null && FieldList.Count > 1)
            {
                btnDelete.Hidden = false;
            }


            if (selectedField.FieldOptions != null)
            {
                //get field options
                var fieldOptions = selectedField.FieldOptions;
                //set fieldoptions on field selection to edit
                Session["FieldOptions"] = fieldOptions;

                //bind with fieldOption list
                cbxFieldOptions.Store[0].DataSource = fieldOptions;
                cbxFieldOptions.Store[0].DataBind();
            }



            //set the field values for selected field in UI
            FormPanelFieldData.SetValues(new
            {
                FieldName = selectedField.FieldName,
                DisplayName = selectedField.DisplayName,
                IsAllowBlank = selectedField.IsAllowBlank,
                MaxLength = selectedField.MaxLength,
                DataType = selectedField.DataType,
                FieldOrder = selectedField.FieldOrder,
                DefaultValue = selectedField.DefaultValue
                // FieldOptions = selectedField.FieldOptions
            });

        }

        #endregion

    }

}