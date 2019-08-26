<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditField.ascx.cs" Inherits="DataEntryApp.UserControls.EditField" %>

<ext:XScript runat="server" ID="XScript">
    <script>
        function validate() {
            var isValid = #{ fieldForm }.getForm().isValid();
            return isValid;
        }
    </script>
</ext:XScript>

<ext:ResourceManager runat="server"></ext:ResourceManager>

<ext:Viewport ID="fieldOptionWindow" runat="server" Layout="BorderLayout" Padding="10" BodyPadding="5">
    <Items>
        <ext:FormPanel
            ID="fieldForm"
            Flex="1"
            runat="server"
            AutoScroll="true"
            BodyStyle="padding:10px 20px;"
            DefaultAllowBlank="false"
            Title="Technical request"
            Region="Center" Layout="ColumnLayout"
            BodyPadding="5">
            <Items>

                <ext:Panel ID="pnlFields" runat="server"
                    IDMode="Static"
                    Border="true"
                    Header="false"
                    Hidden="true"
                    ColumnWidth="1"
                    Layout="ColumnLayout"
                    LabelAlign="Top">
                    <Items>
                        <ext:Panel ID="pnlLeft"
                            runat="server"
                            IDMode="Static"
                            Border="false"
                            Header="false"
                            ColumnWidth=".5"
                            Layout="Form"
                            LabelAlign="Top">
                        </ext:Panel>
                        <ext:Panel ID="pnlRight"
                            runat="server"
                            IDMode="Static"
                            Border="false"
                            Header="false"
                            ColumnWidth=".5"
                            Layout="Form"
                            LabelAlign="Top">
                        </ext:Panel>

                        <ext:Panel ID="pnlDown"
                            runat="server"
                            IDMode="Static"
                            Border="false"
                            Header="false"
                            ColumnWidth="0.5"
                            Layout="Form"
                            LabelAlign="Top">
                            <Items>
                                <%--  <ext:Button ID="btnSaveDiary" runat="server" UI="Primary" Icon="Disk" Text="Save "   >
                 <Listeners>
                    <Click Fn="addDiary"  ></Click>
                </Listeners>
            </ext:Button>--%>
                                <ext:FileUploadField FieldLabel="Attachment" ID="fuAttachments" Name="Attachment" AllowBlank="true" runat="server" />
                            </Items>
                        </ext:Panel>

                    </Items>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button ID="btnSave" runat="server" UI="Primary" Icon="Email" Text="Save">
                    <DirectEvents>
                        <Click OnEvent="OnSave" Before="return validate()"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCancel" runat="server" UI="Primary" Icon="Email" Text="Cancel">
                    <DirectEvents>
                        <Click OnEvent="OnCancel" Before="return validate()"></Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:FormPanel>
        <ext:StatusBar ID="sbButtons" Region="South" StatusAlign="Right" runat="server">
            <Items>
                <%--  <ext:Button ID="btnSaveDiary" runat="server" UI="Primary" Icon="Disk" Text="Save "   >
                 <Listeners>
                    <Click Fn="addDiary"  ></Click>
                </Listeners>
            </ext:Button>--%>
                <%--<ext:Button ID="btnEmail" runat="server" UI="Primary" Icon="Email" Text="Email">
                    <DirectEvents>
                        <Click OnEvent="OnEmail"></Click>
                    </DirectEvents>
                </ext:Button>--%>
            </Items>

        </ext:StatusBar>
    </Items>
</ext:Viewport>

<ext:Window
    ID="Window1"
    runat="server"
    Title="Email Template"
    Width="700"
    Height="470"
    BodyPadding="10">
    <Tools>
    </Tools>
    <Items>
        <ext:FieldSet
            runat="server"
            Title="Template Fields"
            Layout="AnchorLayout"
            Collapsible="false"
            DefaultAnchor="100%">
            <Items>
                <ext:RadioGroup
                    ID="RadioGroup3"
                    runat="server"
                    GroupName="RadioGroup3"
                    ColumnsNumber="3"
                    Cls="x-check-group-alt">
                    <Items>
                        <ext:Radio runat="server" BoxLabel="Textbox" InputValue="1" />
                        <ext:Radio runat="server" BoxLabel="Checkbox" InputValue="2" Checked="true" />
                        <ext:Radio runat="server" BoxLabel="RadioButton" InputValue="3" />
                        <ext:Radio runat="server" BoxLabel="Label" InputValue="4" />
                        <ext:Radio runat="server" BoxLabel="Dropdown" InputValue="5" />
                    </Items>
                </ext:RadioGroup>
            </Items>
        </ext:FieldSet>
        <ext:Panel
            runat="server"
            Layout="FitLayout"
            Width="676"
            Height="240">
            <Items>

                <ext:FormPanel
                    ID="FormPanel1"
                    runat="server"
                    Title="TextBox Field"
                    BodyPadding="5"
                    ButtonAlign="Right"
                    Layout="Column">
                    <Items>
                        <ext:Panel
                            runat="server"
                            Border="false"
                            Header="false"
                            ColumnWidth=".5"
                            Layout="Form"
                            LabelAlign="Top">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Field Name" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                <ext:TextField runat="server" FieldLabel="Display Name" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                <ext:TextField runat="server" FieldLabel="Is Allow Blank" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Border="false" Layout="Form" ColumnWidth=".5" LabelAlign="Top">
                            <Items>
                                <ext:SelectBox
                                    ID="SelectBox1"
                                    runat="server"
                                    DisplayField="DivisionName"
                                    ValueField="Id"
                                    EmptyText="Select data type"
                                    FieldLabel="Data Type"
                                    AllowBlank="false"
                                    MsgTarget="Side"
                                    Editable="false">
                                    <Store>
                                        <ext:Store ID="strDivsion" runat="server">
                                            <Model>
                                                <ext:Model runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="Id" />
                                                        <ext:ModelField Name="DataType" />

                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>
                                <ext:TextField runat="server" FieldLabel="Field Order" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
                                <ext:TextField runat="server" FieldLabel="Default Value" AnchorHorizontal="92%" AllowBlank="false" MsgTarget="Side" />
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
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button
                    ID="Button1"
                    runat="server"
                    Text="Save"
                    Disabled="true"
                    FormBind="true">
                    <%--<Listeners>
                        <Click Handler="if (#{FormPanel1}.getForm().isValid()) {Ext.Msg.alert('Submit', 'Saved!');}else{Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'FormPanel is incorrect', buttons:Ext.Msg.OK});}" />
                    </Listeners>--%>
                </ext:Button>
            </Buttons>
        </ext:Panel>
    </Items>
</ext:Window>
