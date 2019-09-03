<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateList.ascx.cs" Inherits="DataEntryApp.UserControls.TemplateList" %>

<ext:XScript runat="server" ID="XScript">
    <script>
        function validate() {
            var isValid = #{ emailTicketForm }.getForm().isValid();
            return isValid;
        }
    </script>
</ext:XScript>


<ext:Viewport ID="emailTicketWindow" runat="server" Layout="BorderLayout" Padding="10" BodyPadding="5">
    <Items>
        <ext:FormPanel
            ID="emailTicketForm"
            Flex="1"
            runat="server"
            AutoScroll="true"
            BodyStyle="padding:10px 20px;"
            DefaultAllowBlank="false"
            Title="Technical request"
            Region="Center" Layout="ColumnLayout"
            BodyPadding="5">
            <Items>
                <ext:Panel ID="pnlTop"
                    runat="server"
                    IDMode="Static"
                    Border="false"
                    Header="false"
                    ColumnWidth="0.501"
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
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel1"
                    runat="server"
                    IDMode="Static"
                    Border="false"
                    Header="false"
                    ColumnWidth="0.501"
                    Layout="Form"
                    LabelAlign="Top">
                    <Items>

                        <ext:Button ID="btnEmail" runat="server" UI="Primary" Icon="Add" Text="Add">
                            <DirectEvents>
                                <Click OnEvent="OnAddClick" Before="return validate()"></Click>
                            </DirectEvents>
                        </ext:Button>

                    </Items>
                </ext:Panel>
            </Items>

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
