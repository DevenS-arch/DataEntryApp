using DataEntryApp.BL;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DataEntryApp.UserControls
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

            if (DivisionId!=null)
            {
                var requests = new RequestBLL().GetRequests();
                strRequests.DataSource = requests;
                strRequests.DataBind();
            }

        }

        protected void OnRequestSelected(object sender, DirectEventArgs e)
        {
            if (RequestId!=null)
            {
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

        //private void DisplayEmailPreview(List<Tuple<string, string>> emailData, EmailTemplateDTO emailTemplate)
        //{
        //    if (emailData.IsCollectionValid())
        //    {
        //        var message = $"<b>To:</b> {emailTemplate.To.Aggregate((first, sec) => string.Format("{0}; {1}", first, sec))}<br>";
        //        message += $"<b>CC:</b> <br>";
        //        message += $"<b>BCC:</b> <br><br>";
        //        message += $"<b>Subject:</b> {GetEmailSubject(emailTemplate)}<br><br>";
        //        message += $"<b>Body:</b> <br>";
        //        message += string.Join("<br>", emailData.Select(d => $"{d.Item1}:    {d.Item2}"));
        //        message = $"<br>{message}<br><br>";
        //        X.Msg.Alert("Email preview", message).Show();
        //    }
        //}

        //private void GenerateEmailTemplate(int requestId)
        //{
        //    var emailTemplate = new EmailTemplateBLL().GetEmailTemplate(requestId);

        //    if (emailTemplate != null)
        //        Set(string.Format(EMAIL_TEMPLATE_BY_REQUEST, requestId), emailTemplate);

        //    GenerateFormControls(requestId);
        //    AssignEventHandlers();
        //}

        //private void AssignEventHandlers()
        //{
        //}

        //private void GenerateFormControls(int requestId)
        //{
        //    ClearControls();

        //    var emailTemplate = Get<EmailTemplateDTO>(string.Format(EMAIL_TEMPLATE_BY_REQUEST, RequestId));

        //    if (!(emailTemplate != null && emailTemplate.Fields != null && emailTemplate.Fields.Count > 0))
        //        return;

        //    var leftCtrls = emailTemplate.Fields
        //                                 .Where((field, index) => index % 2 == 0)
        //                                 .ToList();

        //    var rightCtrls = emailTemplate.Fields
        //                                 .Where((field, index) => index % 2 != 0)
        //                                 .ToList();

        //    AddControlsToPanel(pnlLeft, leftCtrls);
        //    AddControlsToPanel(pnlRight, rightCtrls);
        //    pnlFields.Show();
        //}

        //private void ClearControls()
        //{
        //    pnlLeft.ContentControls.Clear();
        //    pnlRight.ContentControls.Clear();
        //    pnlFields.Hide();
        //    pnlLeft.UpdateContent();
        //    pnlRight.UpdateContent();
        //}

        //private void AddControlsToPanel(Ext.Net.Panel panel, List<EmailTemplateFieldDTO> fields)
        //{

        //    foreach (var field in fields)
        //    {
        //        var control = GetControl(field);

        //        if (control != null)
        //            panel.ContentControls.Add(control);

        //    }

        //    panel.UpdateContent();
        //}

        //private Control GetControl(EmailTemplateFieldDTO field)
        //{

        //    switch (field.FieldType)
        //    {
        //        case TEXT_BOX:
        //            if (field.DataType.Equals(INT, StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                var textField = new NumberField()
        //                {
        //                    ID = field.FieldName,
        //                    FieldLabel = field.DisplayName,
        //                    TabIndex = (short)field.FieldOrder,
        //                    AllowBlank = field.IsAllowBlank,
        //                    Text = field.DefaultValue
        //                };

        //                if (!string.IsNullOrEmpty(field.FormatRegEx))
        //                    textField.Regex = textField.MaskRe = field.FormatRegEx;

        //                return textField;
        //            }
        //            else
        //            {
        //                var textField = new TextField()
        //                {
        //                    ID = field.FieldName,
        //                    FieldLabel = field.DisplayName,
        //                    TabIndex = (short)field.FieldOrder,
        //                    AllowBlank = field.IsAllowBlank,
        //                    Text = field.DefaultValue
        //                };

        //                if (!string.IsNullOrEmpty(field.FormatRegEx))
        //                    textField.Regex = textField.MaskRe = field.FormatRegEx;

        //                return textField;
        //            }

        //        case DROP_DOWN:
        //            var comboBox = new ComboBox()
        //            {
        //                ID = field.FieldName,
        //                FieldLabel = field.DisplayName,
        //                Text = $"Select {field.DisplayName}",
        //                Editable = false,
        //                TabIndex = (short)field.FieldOrder,
        //                AllowBlank = field.IsAllowBlank
        //            };

        //            if (field.FieldOptions != null && field.FieldOptions.Count > 0)
        //            {
        //                field.FieldOptions.ForEach((fo) => comboBox.Items.Add(new Ext.Net.ListItem() { Text = fo.DisplayName, Value = fo.Value }));
        //            }

        //            return comboBox;

        //        case CHECK_BOX:
        //            var checkbox = new Checkbox()
        //            {
        //                ID = field.FieldName,
        //                FieldLabel = field.DisplayName,
        //                TabIndex = (short)field.FieldOrder,
        //            };

        //            return checkbox;

        //        default:
        //            return null;

        //    }

        //}

        //private List<Tuple<string, string>> GetData(int requestId, EmailTemplateDTO emailTemplate)
        //{
        //    //var controls = new List<Control>();
        //    //var leftPanelCtrls = pnlLeft.ContentControls.Cast<Control>();

        //    //if (leftPanelCtrls.Any())
        //    //    controls.AddRange(leftPanelCtrls);

        //    //var rightPanelCtrls = pnlRight.ContentControls.Cast<Control>();

        //    //if (rightPanelCtrls.Any())
        //    //    controls.AddRange(rightPanelCtrls);



        //    if (emailTemplate.IsNull() || !emailTemplate.Fields.IsCollectionValid())
        //        return new List<Tuple<string, string>>();

        //    var data = new List<Tuple<string, string>>();

        //    data.AddRange(emailTemplate.Fields.Select((field) =>
        //    {

        //        if (field.FieldType == TEXT_BOX)
        //            return Tuple.Create(field.DisplayName, X.GetCmp<TextField>(field.FieldName).Text);
        //        else if (field.FieldType == DROP_DOWN)
        //        {
        //            var selectedValue = X.GetCmp<ComboBox>(field.FieldName).SelectedItem.Value;

        //            if (!string.IsNullOrEmpty(selectedValue) && !selectedValue.StartsWith("Select ", StringComparison.InvariantCultureIgnoreCase))
        //                return Tuple.Create(field.DisplayName, selectedValue);
        //        }
        //        else if (field.FieldType == CHECK_BOX)
        //        {
        //            return Tuple.Create(field.DisplayName, X.GetCmp<Checkbox>(field.FieldName).Checked ? "Yes" : "No");
        //        }

        //        return Tuple.Create(field.DisplayName, string.Empty);
        //    })
        //    .ToList());

        //    data.Add(Tuple.Create("Attachment", fuAttachments.HasFile ? fuAttachments.FileName : string.Empty));
        //    return data;
        //}

        //private string GetEmailSubject(EmailTemplateDTO emailTemplate)
        //{
        //    var userId = "PTM";

        //    if (emailTemplate.Fields.IsCollectionValid() &&
        //        emailTemplate.Fields.Exists(ef => ef.FieldName.Equals("ClaimNumber", StringComparison.InvariantCultureIgnoreCase)))
        //        return $"{RequestName} {X.GetCmp<TextField>("ClaimNumber").Text} {userId}";
        //    else
        //        return $"{RequestName} {userId}";

        //}

        #endregion
    }

}