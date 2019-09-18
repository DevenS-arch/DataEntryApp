<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateList.ascx.cs" Inherits="TechTicket.DataEntry.UserControls.TemplateList" %>

<ext:XScript runat="server" ID="XScript">
    <script>
        //function validate() {
        //    var isValid = #{ emailTicketForm }.getForm().isValid();
        //    return isValid;
        //}

        function showWindow() {
            #{ Window1 }.show();
            #{ Window1 }.setTitle("Add " + #{ Window1 }.getTitle());
        }
        function editTemplate() {
            #{ Window1 }.show();
            #{ Window1 }.setTitle("Edit Email Template");
            App.direct.fieldTemplateData.EditTemplate();
        }
        function previewTemplate() {
            var v = #{ Store1 }.data.items;
            console.log(v);
            App.direct.fieldTemplateData.PreviewTemplate();
        }

    </script>
</ext:XScript>

<ext:Panel runat="server" Padding="10" BodyPadding="5" Layout="ColumnLayout">
    <Items>
        <ext:FormPanel
            ID="templateForm"
            Flex="1"
            runat="server"
            BodyStyle="padding:10px 20px;"
            DefaultAllowBlank="false"
            Title="Template"
            Region="Center" Layout="FormLayout"
            BodyPadding="5"
            Width="600"
            Height="600">
            <Items>
                <ext:Panel ID="pnlTop"
                    runat="server"
                    IDMode="Static"
                    Border="false"
                    Header="false"
                    ColumnWidth=".5"
                    Layout="Form"
                    LabelAlign="Top">
                    <Items>
                        <ext:ComboBox ID="cboxDivision" runat="Server"
                            MaxWidth="250"
                            FieldLabel="Division"
                            Text="Select Division"
                            ValueField="Id"
                            DisplayField="DivisionName"
                            Editable="false">
                            <DirectEvents>
                                <Select OnEvent="OnDivisionSelected"></Select>
                            </DirectEvents>
                            <Store>
                                <ext:Store ID="strDivsion" runat="server">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="Id" />
                                                <ext:ModelField Name="DivisionName" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cboxRequest" runat="Server"
                            MaxWidth="250"
                            FieldLabel="Request"
                            Text="Select Request"
                            ValueField="Id"
                            DisplayField="RequestName"
                            Editable="false">
                            <DirectEvents>
                                <Select OnEvent="OnRequestSelected"></Select>
                            </DirectEvents>
                            <Store>
                                <ext:Store ID="strRequests" runat="server">

                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="Id" />
                                                <ext:ModelField Name="RequestName" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>

                        <%--   <ext:GridPanel ID="TemplatePanel" runat="server" Border="false" Visible="false"
                                            Height="480">
                                            <Store>
                                                <ext:Store ID="TemplateStore" runat="server" PageSize="10">
                                                    <Model>
                                                        <ext:Model runat="server" IDProperty="Id">
                                                            <Fields>
                                                                <ext:ModelField Name="Id" Type="String" />
                                                                <ext:ModelField Name="TemplateName" Type="String" />
                                                                <ext:ModelField Name="Actions" Type="Auto" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:Column ID="TemplateIdColumn" runat="server" Text="Template Id" DataIndex="Id" Visible="false" Flex="1">
                                                    </ext:Column>
                                                    <ext:Column ID="TemplateNameColumn" runat="server" Text="Template Name" DataIndex="TemplateName" Flex="1">
                                                        <Editor>
                                                            <ext:TextField runat="server" AllowBlank="false" />
                                                        </Editor>
                                                    </ext:Column>
                                                    <ext:CommandColumn runat="server" Width="33px">
                                                        <Commands>
                                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                                <ToolTip Text="Edit" />
                                                            </ext:GridCommand>
                                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                                <ToolTip Text="Delete" />
                                                            </ext:GridCommand>
                                                        </Commands>
                                                    </ext:CommandColumn>
                                                </Columns>
                                            </ColumnModel>
                                           
                                           
                                           
                                        </ext:GridPanel>--%>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="pnlAddTemplateButton"
                    runat="server"
                    IDMode="Static"
                    Border="false"
                    Header="false"
                    ColumnWidth="0.501"
                    Layout="Form"
                    LabelAlign="Top"
                    Hidden="true">
                    <Items>

                        <ext:Button ID="btnAddTemplate" runat="server" UI="Primary" Icon="Add" Text="Add Template">
                            <Listeners>
                                <Click Fn="showWindow"></Click>
                            </Listeners>
                        </ext:Button>

                    </Items>
                </ext:Panel>
                <ext:Container runat="server" Padding="10" Hidden="true" ID="cntLabel">
                    <Items>
                        <ext:Label runat="server" Text="No Records to display!" ID="lblEmptyTemplate"></ext:Label>
                    </Items>
                </ext:Container>

                <ext:Panel ID="pnlTemplateGrid"
                    runat="server"
                    IDMode="Static"
                    Border="false"
                    Header="false"
                    ColumnWidth="0.501"
                    Layout="FitLayout"
                    LabelAlign="Top"
                    Hidden="true">
                    <Items>
                        <ext:GridPanel
                            ID="grdTemplateList"
                            runat="server"
                            Border="true">
                            <Store>
                                <ext:Store ID="Store1" runat="server">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="Id" />
                                                <ext:ModelField Name="TemplateName" Type="String" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:Column runat="server" Text="Company" DataIndex="Id" Flex="1" Visible="false">
                                    </ext:Column>
                                    <ext:Column runat="server" Text="Template Name" DataIndex="TemplateName" Flex="1">
                                    </ext:Column>
                                    <ext:ImageCommandColumn runat="server" Width="70px">

                                        <Commands>
                                            <ext:ImageCommand Icon="FolderPicture" CommandName="Preview" Text="Preview">
                                                <ToolTip Text="Preview" />

                                            </ext:ImageCommand>
                                        </Commands>

                                        <Listeners>
                                            <Command Fn="previewTemplate" />
                                        </Listeners>
                                    </ext:ImageCommandColumn>
                                    <ext:ImageCommandColumn runat="server" Width="70px">

                                        <Commands>
                                            <ext:ImageCommand Icon="NoteEdit" CommandName="Edit" Text="Edit">
                                                <ToolTip Text="Edit" />

                                            </ext:ImageCommand>
                                        </Commands>

                                        <Listeners>
                                            <Command Fn="editTemplate" />
                                        </Listeners>
                                    </ext:ImageCommandColumn>
                                    <ext:ImageCommandColumn runat="server" Width="70px">

                                        <Commands>
                                            <ext:ImageCommand Icon="Delete" CommandName="Delete" Text="Delete">
                                                <ToolTip Text="Delete" />

                                            </ext:ImageCommand>
                                        </Commands>

                                        <Listeners>
                                            <Command Handler="
                                Ext.MessageBox.confirm('Delete', 'Are you sure ?', function(btn){
   if(btn === 'yes'){
                               // alert(record.data.TemplateName);
      App.direct.fieldTemplateData.DeleteTemplate();
                              //  #{DirectMethods}.delete(record.data);
   }
 });" />
                                        </Listeners>
                                    </ext:ImageCommandColumn>

                                </Columns>
                            </ColumnModel>
                        </ext:GridPanel>

                    </Items>
                </ext:Panel>

                <ext:Window
                    ID="Window1"
                    runat="server"
                    Title="Email Template"
                    Width="800"
                    Height="200"
                    BodyPadding="10"
                    Y="-85"
                    X="150"
                    Hidden="true">
                    <Tools>
                    </Tools>
                    <Items>
                        <ext:FormPanel
                            ID="FormPanelRadioGroup"
                            runat="server"
                            BodyPadding="5"
                            ButtonAlign="Right">
                            <Items>
                                <ext:FieldSet
                                    runat="server"
                                    Title="Select Field"
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
                                                <ext:Radio runat="server" BoxLabel="Textbox" InputValue="Textbox">
                                                </ext:Radio>
                                                <%--<ext:Radio runat="server" BoxLabel="Checkbox" InputValue="Checkbox" />
                                <ext:Radio runat="server" BoxLabel="RadioButton" InputValue="RadioButton" />--%>
                                                <ext:Radio runat="server" BoxLabel="Dropdown" InputValue="Dropdown" />
                                                <ext:Radio runat="server" BoxLabel="TextArea" InputValue="TextArea" />
                                                <ext:Radio runat="server" ID="rdHidden" BoxLabel="Reset" InputValue="Reset" Hidden="true" />
                                            </Items>
                                            <DirectEvents>
                                                <Change OnEvent="Select_RadioButton"></Change>
                                            </DirectEvents>
                                        </ext:RadioGroup>
                                        <ext:Panel runat="server" Layout="ColumnLayout">
                                            <Items>
                                                <ext:ComboBox
                                                    ID="cbxFieldList"
                                                    runat="server"
                                                    Editable="false"
                                                    QueryMode="Local"
                                                    TriggerAction="All"
                                                    EmptyText="Field List"
                                                    FieldLabel="Added Fields"
                                                    MsgTarget="Side"
                                                    Hidden="true"
                                                    DefaultAnchor="92%"
                                                    ColumnWidth=".5"
                                                    ValueField="FieldName"
                                                    DisplayField="FieldName">
                                                    <Items>
                                                    </Items>
                                                    <Store>
                                                        <ext:Store ID="strFieldList" runat="server">
                                                            <Model>
                                                                <ext:Model runat="server" IDProperty="Value">
                                                                    <Fields>
                                                                        <ext:ModelField Name="FieldName" />
                                                                        <ext:ModelField Name="FieldName" />
                                                                    </Fields>
                                                                </ext:Model>
                                                            </Model>
                                                        </ext:Store>
                                                    </Store>
                                                    <DirectEvents>
                                                        <Select OnEvent="SelectField">
                                                        </Select>

                                                    </DirectEvents>

                                                </ext:ComboBox>

                                            </Items>
                                        </ext:Panel>

                                    </Items>
                                </ext:FieldSet>
                            </Items>
                            <Buttons>
                                <ext:Button
                                    ID="btnCancelTemplate"
                                    runat="server"
                                    Text="Cancel">
                                    <DirectEvents>
                                        <Click OnEvent="CancelTemplate">
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button
                                    ID="btnSaveTemplate"
                                    runat="server"
                                    Text="Save Template"
                                    Disabled="true"
                                    Hidden="true">
                                    <DirectEvents>
                                        <Click OnEvent="SaveTemplate">
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Buttons>
                        </ext:FormPanel>

                        <ext:Panel
                            ID="panelFieldData"
                            runat="server"
                            Layout="FitLayout"
                            Hidden="true"
                            Scrollable="Vertical">
                            <Items>
                                <ext:FormPanel
                                    ID="FormPanelFieldData"
                                    runat="server"
                                    Title="TextBox Field"
                                    BodyPadding="5"
                                    ButtonAlign="Right"
                                    Scrollable="Vertical"
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
                                                <ext:TextField runat="server" ID="txFieldName" Regex="/[\w]/" MaskRe="/[\w]/" FieldLabel="Field Name" TabIndex="1"
                                                    Name="FieldName" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side">
                                                    <Listeners>
                                                        <Change Handler="this.setIndicatorIconCls('validation-indicator');this.setIndicatorTip('Validating...');"></Change>
                                                    </Listeners>
                                                </ext:TextField>


                                                <ext:TextField runat="server" ID="txDisplayName" Name="DisplayName" FieldLabel="Display Name" TabIndex="3" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                                <ext:ComboBox
                                                    ID="cbxAllowBlank"
                                                    runat="server"
                                                    Editable="false"
                                                    QueryMode="Local"
                                                    TriggerAction="All"
                                                    EmptyText="Is Required"
                                                    FieldLabel="Is Required"
                                                    MsgTarget="Side"
                                                    AllowBlank="false"
                                                    TabIndex="5"
                                                    Name="IsAllowBlank">
                                                    <Items>
                                                        <ext:ListItem Text="True" Value="false" />
                                                        <ext:ListItem Text="False" Value="true" />
                                                    </Items>
                                                </ext:ComboBox>
                                                <ext:NumberField runat="server" ID="txtMaxLength" Name="MaxLength" FieldLabel="Max Length" TabIndex="7" AnchorHorizontal="92%" MsgTarget="Side" />

                                                <%--<ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".5" LabelAlign="Top">
                                    <Items>
                                        <ext:TextField runat="server" ID="txFieldOptionValue" FieldLabel="Option Value" AnchorHorizontal="30%" AllowBlank="false" MsgTarget="Side"></ext:TextField>
                                        <ext:TextField runat="server" ID="txtFieldOptionId" FieldLabel="Option Id" AnchorHorizontal="30%" AllowBlank="false" MsgTarget="Side"></ext:TextField>

                                    </Items>
                                </ext:Panel>--%>
                                            </Items>
                                        </ext:Panel>
                                        <ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".5" LabelAlign="Top">
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
                                                    AllowBlank="false"
                                                    TabIndex="2"
                                                    Name="DataType">
                                                    <Items>
                                                        <ext:ListItem Text="Alphanumeric Text" Value="string" />
                                                        <ext:ListItem Text="Currency" Value="currency" />
                                                        <ext:ListItem Text="Decimal Number" Value="double" />
                                                        <ext:ListItem Text="Number" Value="int" />
                                                        <ext:ListItem Text="Text" Value="string" />
                                                        <ext:ListItem Text="Yes/No" Value="Bool" />
                                                    </Items>
                                                </ext:ComboBox>
                                                <ext:NumberField runat="server" ID="txFieldOrder" Name="FieldOrder" FieldLabel="Field Order" TabIndex="4" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                                <ext:TextField runat="server" ID="txDefaultValue" Name="DefaultValue" FieldLabel="Default Value" TabIndex="6" AnchorHorizontal="92%" MsgTarget="Side" />


                                            </Items>
                                        </ext:Panel>
                                        <ext:Panel ID="pnlFieldOptions" runat="server" Border="true" Layout="ColumnLayout" ColumnWidth="1" LabelAlign="Top" Cls="exito-panel" Hidden="true">
                                            <Items>

                                                <ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".4" LabelAlign="Top">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtFieldOptionText" Name="FieldOptionText" FieldLabel="Option Text" TabIndex="8" AnchorHorizontal="90%" MsgTarget="Side"></ext:TextField>
                                                    </Items>
                                                </ext:Panel>
                                                <%--<ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".4" LabelAlign="Top">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtFieldOptionValue" FieldLabel="Option Value" AnchorHorizontal="90%" MsgTarget="Side"></ext:TextField>
                                                    </Items>
                                                </ext:Panel>--%>

                                                <ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".2" LabelAlign="Top">
                                                    <Items>
                                                        <ext:HyperlinkButton runat="server" Icon="Add" Text="Add Option">
                                                            <DirectEvents>
                                                                <Click OnEvent="AddFieldOption"></Click>
                                                            </DirectEvents>
                                                            <%--<Listeners>
                                                                <Click Handler=" //console.log(#{strFieldOptions}.data.items);
                                                                    var length = #{strFieldOptions}.data.items.length;
                                                                    var value = #{txtFieldOptionText}.value;
                                                                    if(value!='')
                                                                    {
                                                                   // alert(length);
                                                               }
                                                                    #{txtFieldOptionText}.clear();"></Click>
                                                            </Listeners>--%>
                                                        </ext:HyperlinkButton>
                                                    </Items>
                                                </ext:Panel>
                                                <ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".4" LabelAlign="Top">
                                                    <Items>
                                                        <ext:ComboBox
                                                            ID="cbxFieldOptions"
                                                            runat="server"
                                                            DisplayField="DisplayName"
                                                            ValueField="Value"
                                                            QueryMode="Local"
                                                            EmptyText="Field Options"
                                                            FieldLabel="Field Options"
                                                            Editable="false" ColumnWidth=".5"
                                                            Name="FieldOptions">
                                                            <Store>
                                                                <ext:Store ID="strFieldOptions" runat="server">
                                                                    <Model>
                                                                        <ext:Model runat="server" IDProperty="Value">
                                                                            <Fields>
                                                                                <ext:ModelField Name="DisplayName" />
                                                                                <ext:ModelField Name="Value" />
                                                                            </Fields>
                                                                        </ext:Model>
                                                                    </Model>
                                                                </ext:Store>
                                                            </Store>

                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" QTip="Remove selected" />
                                                            </Triggers>
                                                            <DirectEvents>
                                                                <TriggerClick OnEvent="RemoveOption"></TriggerClick>
                                                            </DirectEvents>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Panel>

                                            </Items>

                                        </ext:Panel>
                                    </Items>
                                    <%-- <BottomBar>
                                        <ext:StatusBar runat="server" />
                                    </BottomBar>--%>
                                    <Listeners>
                                        <ValidityChange Handler="
                                            #{btnSaveField}.setDisabled(!valid);
                                            " />
                                        <FieldChange Handler="">
                                        </FieldChange>

                                    </Listeners>
                                    <Buttons>
                                        <ext:Button
                                            ID="btnDelete"
                                            runat="server"
                                            Text="Delete"
                                            Hidden="true">
                                            <DirectEvents>
                                                <Click OnEvent="DeleteField">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button
                                            ID="btnCancel"
                                            runat="server"
                                            Text="Cancel">
                                            <DirectEvents>
                                                <Click OnEvent="CancelField">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button
                                            ID="btnSaveField"
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
            </Items>

        </ext:FormPanel>
    </Items>
</ext:Panel>

