<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTemplate.ascx.cs" Inherits="DataEntryApp.UserControls.AddTemplate" %>

<ext:XScript runat="server" ID="XScript">
    <script>
        function validate() {
            var isValid = #{ fieldForm }.getForm().isValid();
            return isValid;
        }
        function changePanel() {
            //alert(4545);
            //var value = #{ rdRadioGroup }.getValue().RadioGroup;
            //console.log(#{ FormPanelFieldData }.title);
            //#{ FormPanelFieldData }.title = value;
            //console.log(value)
            //alert(value);

        }
    </script>
</ext:XScript>

<ext:Window
    ID="Window1"
    runat="server"
    Title="Add Email Template"
    Width="800"
    Height="200"
    BodyPadding="10"
    Y="40">
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
                    Title="Select Template Field"
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
                    ID="btnSaveTemplate"
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
                                <ext:TextField runat="server" ID="txFieldName" FieldLabel="Field Name" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side">
                                    <Listeners>
                                        <Change Handler="this.setIndicatorIconCls('validation-indicator');this.setIndicatorTip('Validating...');"></Change>
                                    </Listeners>
                                </ext:TextField>


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
                        <ext:Panel ID="pnlFieldOptions" runat="server" Border="true" Layout="ColumnLayout" ColumnWidth="1" LabelAlign="Top" Cls="exito-panel" Hidden="true">
                            <Items>

                                <ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".4" LabelAlign="Top">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtFieldOptionText" FieldLabel="Option Text" AnchorHorizontal="90%" MsgTarget="Side"></ext:TextField>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".4" LabelAlign="Top">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtFieldOptionValue" FieldLabel="Option Value" AnchorHorizontal="90%" MsgTarget="Side"></ext:TextField>
                                    </Items>
                                </ext:Panel>

                                <ext:Panel runat="server" Border="false" Layout="FormLayout" ColumnWidth=".2" LabelAlign="Top">
                                    <Items>
                                        <ext:HyperlinkButton runat="server" Icon="Add" Text="Add Option">
                                            <DirectEvents>
                                                <Click OnEvent="AddFieldOption"></Click>
                                            </DirectEvents>
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
                                            Editable="false" ColumnWidth=".5">
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
                    <BottomBar>
                        <ext:StatusBar runat="server" />
                    </BottomBar>
                    <Listeners>
                        <ValidityChange Handler="this.dockedItems.get(1).setStatus({
                                                     text : valid ? 'Form is valid' : 'Form is invalid',
                                                     iconCls: valid ? 'icon-accept' : 'icon-exclamation'
                                                 });
                                                 #{btnSaveField}.setDisabled(!valid);" />
                    </Listeners>
                    <Buttons>
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

