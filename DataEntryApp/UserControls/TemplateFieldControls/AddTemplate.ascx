<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTemplate.ascx.cs" Inherits="DataEntryApp.UserControls.AddTemplate" %>
<%@ Assembly Name="DataEntryApp" %>
<%--<%@ Import %>--%>
<ext:XScript runat="server" ID="XScript">
    <script>
        function validate() {
            var isValid = #{ fieldForm }.getForm().isValid();
            return isValid;
        }
        function changePanel() {
            //alert(4545);
            //var value = #{ rdRadioGroup }.getValue().RadioGroup;
            //console.log(#{ FormPanel1 }.title);
            //#{ FormPanel1 }.title = value;
            //console.log(value)
            //alert(value);

        }
    </script>
</ext:XScript>
<script>



    function callMe() {
        <%--var valueCount = '<%=(List<DataEntryApp.Entities.EmailTemplateFieldDTO>)Session["FieldList"]%>';
           alert(valueCount);
        if (valueCount != null && valueCount.length>0) {
            alert(valueCount[0].Id);
        }--%>
    }

</script>

<ext:Window
    ID="Window1"
    runat="server"
    Title="Email Template"
    Width="700"
    Height="200"
    BodyPadding="10"
    Y="100">
    <Tools>
    </Tools>
    <Items>
        <ext:FormPanel
            ID="FormPanel3"
            runat="server"
            BodyPadding="5"
            ButtonAlign="Right">
            <Items>
                <ext:FieldSet
                    runat="server"
                    Title="Template Fields"
                    Layout="AnchorLayout"
                    Collapsible="false"
                    DefaultAnchor="100%">
                    <Items>
                        <ext:RadioGroup
                            ID="rdRadioGroup"
                            runat="server"
                            GroupName="RadioGroup"
                            ColumnsNumber="3"
                            Cls="x-check-group-alt">
                            <Items>
                                <ext:Radio runat="server" BoxLabel="Textbox" InputValue="Textbox" />
                                <%--<ext:Radio runat="server" BoxLabel="Checkbox" InputValue="Checkbox" />
                                <ext:Radio runat="server" BoxLabel="RadioButton" InputValue="RadioButton" />--%>
                                <ext:Radio runat="server" BoxLabel="Dropdown" InputValue="Dropdown" />
                                <ext:Radio runat="server" BoxLabel="TextArea" InputValue="TextArea" />
                            </Items>
                            <DirectEvents>
                                <Change OnEvent="Select_RadioButton"></Change>
                            </DirectEvents>
                        </ext:RadioGroup>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button
                    ID="Button2"
                    runat="server"
                    Text="Save Template"
                    Disabled="true"
                    FormBind="true"
                    Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="SaveTemplate">
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:FormPanel>

        <ext:Panel
            ID="panel1"
            runat="server"
            Layout="FitLayout"
            Width="676"
            Height="260"
            Hidden="true">
            <Items>
                <ext:FormPanel
                    ID="FormPanel1"
                    runat="server"
                    Title="TextBox Field"
                    BodyPadding="5"
                    ButtonAlign="Right"
                    Layout="ColumnLayout">
                    <Items>
                        <ext:Panel
                            runat="server"
                            Border="false"
                            Header="false"
                            ColumnWidth=".5"
                            Layout="Form"
                            LabelAlign="Top">
                            <Items>
                                <ext:TextField runat="server" ID="txFieldName" FieldLabel="Field Name" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                <ext:TextField runat="server" ID="txDisplayName" FieldLabel="Display Name" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                <ext:ComboBox
                                    ID="cbxAllowBlank"
                                    runat="server"
                                    Editable="false"
                                    QueryMode="Local"
                                    TriggerAction="All"
                                    EmptyText="Is Allow Blank"
                                    FieldLabel="Is Allow Blank"
                                    MsgTarget="Side"
                                    AllowBlank="false">
                                    <Items>
                                        <ext:ListItem Text="True" Value="true" />
                                        <ext:ListItem Text="False" Value="false" />
                                    </Items>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Border="false" Layout="Form" ColumnWidth=".5" LabelAlign="Top">
                            <Items>
                                <ext:ComboBox
                                    ID="cbxDataType"
                                    runat="server"
                                    Editable="false"
                                    QueryMode="Local"
                                    TriggerAction="All"
                                    EmptyText="Select data type"
                                    FieldLabel="Data Type"
                                    MsgTarget="Side"
                                    AllowBlank="false">
                                    <Items>
                                        <ext:ListItem Text="Boolean" Value="Bool" />
                                        <ext:ListItem Text="Integer" Value="Int" />
                                        <ext:ListItem Text="String" Value="String" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="txFieldOrder" Regex="^\d+$" FieldLabel="Field Order" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                <ext:TextField runat="server" ID="txDefaultValue" FieldLabel="Default Value" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                            </Items>
                        </ext:Panel>

                    </Items>
                    <BottomBar>
                        <ext:StatusBar runat="server" />
                    </BottomBar>
                    <Listeners>
                        <ValidityChange Handler="this.dockedItems.get(1).setStatus({
                                                     text : valid ? 'Form is valid' : 'Form is invalid',
                                                     iconCls: valid ? 'icon-accept' : 'icon-exclamation'
                                                 });
                                                 #{Button1}.setDisabled(!valid);" />
                    </Listeners>
                    <Buttons>
                        <ext:Button
                            ID="Button1"
                            runat="server"
                            Text="Save Field"
                            Disabled="true"
                            FormBind="true">
                            <DirectEvents>
                                <Click OnEvent="SaveField">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>

        </ext:Panel>
    </Items>
    <DirectEvents>
        <BeforeClose OnEvent="OnCloseWindow"></BeforeClose>
    </DirectEvents>
</ext:Window>

