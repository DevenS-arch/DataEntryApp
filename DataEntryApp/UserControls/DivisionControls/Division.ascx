<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Division.ascx.cs" Inherits="DataEntryApp.UserControls.Division" %>

<ext:XScript runat="server" ID="XScript">
    <script>
        function validate() {
            var isValid = #{ divisionWindow }.getForm().isValid();
            return isValid;
        }


</script>

  
</ext:XScript>

<ext:ResourceManager runat="server"></ext:ResourceManager>

<ext:Viewport ID="divisionWindow" runat="server" Layout="BorderLayout" Padding="10" BodyPadding="5">
    <Items>
        <ext:TabPanel
            runat="server"
            Width="2000"
            Height="2000"
            MarginSpec="0 0 20 0">
            <Defaults>
                <ext:Parameter Name="bodyPadding" Value="10" Mode="Raw" />
                <ext:Parameter Name="autoScroll" Value="true" Mode="Raw" />
            </Defaults>
            <Items>
                <ext:Panel
                    runat="server"
                    Title="Division"
                    AutoDataBind="true">
                    <Items>
                        <ext:FormPanel
                            ID="divisionForm"
                            Flex="1"
                            runat="server"
                            AutoScroll="true"
                            BodyStyle="padding:10px 20px;"
                            DefaultAllowBlank="false"
                            Title="Fields request"
                            Region="Center" Layout="FormLayout"
                            BodyPadding="5">
                            <Items>
                                <ext:Panel ID="pnlTop"
                                    runat="server"
                                    IDMode="Static"
                                    Width="400"
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
                                                <Click OnEvent="OnEmail"></Click>
                                            </DirectEvents>
                                        </ext:Button>

                                    </Items>
                                </ext:Panel>

                                <ext:Panel
                                    runat="server"
                                    Closable="false"
                                    Width="800"
                                    Collapsible="true"
                                    Title="Template Fields"
                                    Maximizable="true"
                                    Layout="Fit">
                                    <Items>
                                        <ext:GridPanel ID="GridPanel1" runat="server" Border="false" Width="800"
                                            Height="400">
                                            <Store>
                                                <ext:Store ID="Store1" runat="server" PageSize="10">
                                                    <Model>
                                                        <ext:Model runat="server" IDProperty="Id">
                                                            <Fields>
                                                                <ext:ModelField Name="DisplayName" Type="String" />
                                                                <ext:ModelField Name="FieldName" Type="String" />
                                                                <ext:ModelField Name="FieldType" Type="String" />
                                                                <ext:ModelField Name="DataType" Type="String" />
                                                                <ext:ModelField Name="Actions" Type="Auto" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:Column ID="DisplayNameColumn" runat="server" Text="Display Name" DataIndex="DisplayName" Flex="1">
                                                    </ext:Column>
                                                    <ext:Column ID="FieldNameColumn" runat="server" Text="Field Name" DataIndex="FieldName" Flex="1">
                                                    </ext:Column>
                                                    <ext:Column ID="FieldTypeColumn" runat="server" Text="Field Type" DataIndex="FieldType" Flex="1">
                                                    </ext:Column>
                                                    <ext:Column ID="DataTypeColumn" runat="server" Text="Data Type" DataIndex="DataType" Flex="1">
                                                    </ext:Column>

                                                    <ext:WidgetColumn ID="ActionsColumn" runat="server" DataIndex="Actions" Text="Actions" Flex="1">
                                                        <Widget>
                                                            <ext:Button runat="server" Width="30" Icon="FeedAdd" Handler="Ext.Msg.alert('Button clicked', 'Hey! ' + this.getWidgetRecord().get('name'));" />
                                                        </Widget>

                                                    </ext:WidgetColumn>
                                                    <ext:WidgetColumn ID="WidgetColumn1" runat="server" DataIndex="Actions" Text="Actions" Flex="1">
                                                        <Widget>
                                                            <ext:Button runat="server" Width="30" Icon="Add" Handler="Ext.Msg.alert('Button clicked', 'Hey! ' + this.getWidgetRecord().get('name'));" />
                                                        </Widget>

                                                    </ext:WidgetColumn>
                                                </Columns>
                                            </ColumnModel>
                                            <Plugins>
                                                <ext:GridFilters runat="server" />
                                            </Plugins>
                                            <BottomBar>
                                                <ext:PagingToolbar runat="server" HideRefresh="True">
                                                    <Items>
                                                    </Items>
                                                </ext:PagingToolbar>
                                            </BottomBar>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>


                            </Items>

                        </ext:FormPanel>
                    </Items>
                </ext:Panel>

                <ext:Panel
                    runat="server"
                    Title="Requests"
                    Html=""
                    AutoDataBind="true" />

                <ext:Panel
                    runat="server"
                    Title="EmailTemplates"
                    Html=""
                    AutoDataBind="true" />
            </Items>
        </ext:TabPanel>
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
