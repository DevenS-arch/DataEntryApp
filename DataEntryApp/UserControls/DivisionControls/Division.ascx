<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Division.ascx.cs" Inherits="DataEntryApp.UserControls.Division" %>

<style>
    .actionBtn {
        background-color: transparent;
        border-style: none
    }

    .icon-exclamation {
        padding-left: 25px !important;
        background: url(/icons/exclamation-png/ext.axd) no-repeat 3px 0px !important;
    }

    .icon-accept {
        padding-left: 25px !important;
        background: url(/icons/accept-png/ext.axd) no-repeat 3px 0px !important;
    }
</style>

<ext:XScript runat="server" ID="XScript">
    <script>
        function validate() {
            var isValid = #{ divisionWindow }.getForm().isValid();
            return isValid;
        }

        function confirm(command, e) {

            Ext.Msg.confirm('Confirm', 'Are you sure?', function (btnText) {
                if (btnText === 'no') {
                    return false;
                }
                else if (btnText === 'yes') {

                    App.direct.UC.OnDeleteDivision(e.record.data, {
                        success: function (result) {
                            Ext.Msg.alert('Delete Successful');
                        }
                    });
                }
            }, this);
        }


        var edit = function (editor, e) {
            // Call DirectMethod
            //if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
                App.direct.UC.EditDivision(e.field, e.originalValue, e.value, e.record.data);
           // }
        };

        var editRequest = function (editor, e) {           
            // Call DirectMethod
            //if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
                App.direct.UC.EditRequest(e.field, e.originalValue, e.value,e.record.data);
            //}
        };

         var OnAddDivision = function () {
           var grid = #{DivisionPanel},
                    record;
                grid.editingPlugin.cancelEdit();

                record = grid.store.insert(0, {
                    DivisionName: '',                    
                });
             grid.editingPlugin.startEdit(record[0]);

             App.direct.UC.OnAddDivision();
        };

        var OnAddRequest = function () {
            var grid = App.RequestPanel,
                store = grid.getStore();

            grid.editingPlugin.cancelEdit();

            store.getSorters().removeAll(); // We have to remove sorting to avoid auto-sorting on insert
            grid.getView().headerCt.setSortState(); // To update columns sort UI

            store.insert(0, {
                name: 'New Guy',
                email: 'new@ext.net',
                start: Ext.Date.clearTime(new Date()),
                salary: 50000,
                active: true
            });

            grid.editingPlugin.startEdit(0, 0);
        };

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
                            Region="Center" Layout="FormLayout"
                            BodyPadding="5">
                            <Items>
                                <%--<ext:Panel ID="Panel1"
                                    runat="server"
                                    IDMode="Static"
                                    Border="false"
                                    Header="false"
                                    ColumnWidth="0.501"
                                    Layout="Form"
                                    LabelAlign="Top">
                                    <Items>

                                        <ext:Button ID="btnAdd" runat="server" UI="Primary" Icon="Add" Text="Add Division">
                                            <DirectEvents>
                                                <Click OnEvent="OnAddDivision"></Click>
                                            </DirectEvents>
                                        </ext:Button>

                                    </Items>
                                </ext:Panel>--%>

                                <ext:Panel
                                    runat="server"
                                    Closable="false"
                                    Width="400"
                                    Collapsible="true"
                                    Title="Divisions"
                                    Maximizable="true"
                                    Layout="Fit">
                                    <Items>
                                        <ext:GridPanel ID="DivisionPanel" runat="server" Border="false" Width="400"
                                            Height="400">
                                            <Store>
                                                <ext:Store ID="DivisionStore" runat="server" PageSize="10">

                                                    <Model>
                                                        <ext:Model runat="server" IDProperty="Id">
                                                            <Fields>
                                                                <ext:ModelField Name="Id" Type="String" />
                                                                <ext:ModelField Name="DivisionName" Type="String" />
                                                                <ext:ModelField Name="Actions" Type="Auto" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <TopBar>
                                                <ext:Toolbar runat="server">
                                                    <Items>
                                                        <ext:Button runat="server" Text="Add Division" Icon="Add">
                                                            <Listeners>
                                                                <Click Fn="OnAddDivision" />
                                                            </Listeners>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </TopBar>
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:Column ID="DivisionIdColumn" runat="server" Text="Division Id" DataIndex="Id" Visible="false" Flex="1">
                                                    </ext:Column>

                                                    <ext:Column ID="DivisionNameColumn" runat="server" Text="Division Name" DataIndex="DivisionName" Flex="1">
                                                        <Editor>
                                                            <ext:TextField runat="server" AllowBlank="false" />
                                                        </Editor>
                                                    </ext:Column>

                                                    <ext:CommandColumn runat="server">
                                                        <Commands>
                                                            
                                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                                <ToolTip Text="Delete" />
                                                            </ext:GridCommand>
                                                        </Commands>
                                                        <Listeners>
                                                            <Command Handler="Ext.Msg.confirm('Delete', 'Are you sure?', function (btnText) {
                if (btnText === 'no') {
                    return false;
                }
                else if (btnText === 'yes') {
                    App.direct.UC.OnDeleteDivision(record.data);
                }
            }, this);" />
                                                        </Listeners>
                                                    </ext:CommandColumn>
                                                    <%-- <ext:WidgetColumn ID="WidgetColumn1" runat="server" DataIndex="Actions" Text="Actions" Flex="1">
                                                        <Widget>
                                                            <ext:Button runat="server" Cls="actionBtn" Text="Delete" Icon="Delete">
                                                                <Listeners>
                                                                    <Click Fn="confirm" />
                                                                </Listeners>
                                                            </ext:Button>

                                                        </Widget>
                                                    </ext:WidgetColumn>--%>
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel runat="server" Mode="Single" />
                                            </SelectionModel>

                                            <Plugins>
                                                <ext:RowEditing runat="server">
                                                    <Listeners>
                                                        <Edit Fn="edit" />
                                                    </Listeners>
                                                </ext:RowEditing>
                                            </Plugins>
                                            <BottomBar>
                                                <ext:PagingToolbar runat="server" HideRefresh="True" />
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
                    AutoDataBind="true">
                    <Items>
                        <ext:FormPanel
                            ID="requestForm"
                            Flex="1"
                            runat="server"
                            AutoScroll="true"
                            BodyStyle="padding:10px 20px;"
                            DefaultAllowBlank="false"
                            Region="Center" Layout="FormLayout"
                            BodyPadding="5">
                            <Items>
                                <%--<ext:Panel ID="pnlTop"
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
                                    </Items>
                                </ext:Panel>--%>

                               <%-- <ext:Panel ID="Panel2"
                                    runat="server"
                                    IDMode="Static"
                                    Border="false"
                                    Header="false"
                                    ColumnWidth="0.501"
                                    Layout="Form"
                                    LabelAlign="Top">
                                    <Items>

                                        <ext:Button ID="btnAddRequest" runat="server" UI="Primary" Icon="Add" Text="Add Request">
                                            <DirectEvents>
                                                <Click OnEvent="OnAddRequest"></Click>
                                            </DirectEvents>
                                        </ext:Button>

                                    </Items>
                                </ext:Panel>--%>

                                <ext:Panel
                                    runat="server"
                                    Closable="false"
                                    Width="400"
                                    Collapsible="true"
                                    Title="Requests"
                                    Maximizable="true"
                                    Layout="Fit">
                                    <Items>
                                        <ext:GridPanel ID="RequestPanel" runat="server" Border="false" Width="400"
                                            Height="400">
                                            <Store>
                                                <ext:Store ID="RequestStore" runat="server" PageSize="10">
                                                    <Model>
                                                        <ext:Model runat="server" IDProperty="Id">
                                                            <Fields>
                                                                <%--<ext:ModelField Name="DivisionId" ServerMapping="Division.DivisionId" Type="String" />--%>
                                                                <ext:ModelField Name="DivisionId" ServerMapping="Division.DivisionName" Type="String" />
                                                                <ext:ModelField Name="RequestName" Type="String" />                    
                                                                <ext:ModelField Name="Actions" Type="Auto" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>
                                                </ext:Store>
                                            </Store>
                                            <TopBar>
                                                <ext:Toolbar runat="server">
                                                    <Items>
                                                        <ext:Button runat="server" Text="Add Request" Icon="Add">
                                                            <Listeners>
                                                                <Click Fn="OnAddRequest" />
                                                            </Listeners>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </TopBar>
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:Column ID="RequestIdColumn" runat="server" Text="Request Id" DataIndex="RequestId" Visible="false" Flex="1">
                                                    </ext:Column>

                                                    <ext:Column ID="DivisionColumn" runat="server" Text="Division Name" DataIndex="DivisionId" Flex="1">
                                                        <Editor>
                                                            <ext:ComboBox ID="ComboBox1" runat="Server"
                                                                MaxWidth="250"
                                                                Text="Select Division"
                                                                ValueField="Id"
                                                                DisplayField="DivisionName"
                                                                Editable="false">

                                                                <Store>
                                                                    <ext:Store ID="Store1" runat="server">
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
                                                        </Editor>
                                                    </ext:Column>

                                                    <ext:Column ID="RequestNameColumn" runat="server" Text="Request Name" DataIndex="RequestName" Flex="1">
                                                        <Editor>
                                                            <ext:TextField runat="server" AllowBlank="false" />
                                                        </Editor>
                                                    </ext:Column>

                                                    <ext:CommandColumn runat="server">
                                                        <Commands>                                                           
                                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                                <ToolTip Text="Delete" />
                                                            </ext:GridCommand>
                                                        </Commands>
                                                        <Listeners>
                                                            <Command Handler="Ext.Msg.confirm('Delete', 'Are you sure?', function (btnText) {
                if (btnText === 'no') {
                    return false;
                }
                else if (btnText === 'yes') {
                    App.direct.UC.OnDeleteRequest(record.data);
                }
            }, this);" />
                                                        </Listeners>
                                                    </ext:CommandColumn>

                                                    <%--<ext:WidgetColumn ID="WidgetColumn2" runat="server" DataIndex="Actions" Text="Actions" Flex="1">
                                                        <Widget>
                                                            <ext:Button runat="server" Cls="actionBtn" Text="Delete" Icon="Delete" Handler="confirm();" />

                                                        </Widget>
                                                    </ext:WidgetColumn>--%>
                                                </Columns>
                                            </ColumnModel>
                                            <Plugins>
                                                <ext:RowEditing runat="server">
                                                    <Listeners>
                                                        <Edit Fn="editRequest" />
                                                    </Listeners>
                                                </ext:RowEditing>
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
                    Title="EmailTemplates"
                    Html=""
                    AutoDataBind="true" />
            </Items>
        </ext:TabPanel>

    </Items>
</ext:Viewport>

<form runat="server">
    <ext:Window
        ID="Window"
        runat="server"
        Title="Add Division"
        Height="215"
        Width="350"
        Frame="true"
        Collapsible="true"
        Cls="box"
        BodyPadding="5"
        DefaultButton="0"
        Layout="AnchorLayout"
        DefaultAnchor="100%">
        <Items>
            <ext:FormPanel
                ID="FormPanel1"
                runat="server"
                ButtonAlign="Right"
                Layout="Column">
                <Items>
                    <ext:Panel
                        runat="server"
                        Border="false"
                        Header="false"
                        Layout="Form"
                        LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:TextField ID="dvName" runat="server" FieldLabel="Division Name" />

                        </Items>
                    </ext:Panel>

                </Items>
                <BottomBar>
                    <ext:StatusBar runat="server" />
                </BottomBar>
                <Listeners>
                    <ValidityChange Handler="#{saveDivision}.setDisabled(!valid);" />
                </Listeners>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button
                ID="saveDivision"
                runat="server"
                Text="Save"
                Icon="Accept"
                Disabled="true">
                <DirectEvents>
                    <Click OnEvent="OnSaveDivision"></Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button
                ID="cancel"
                runat="server"
                Text="Cancel"
                Icon="Cancel">
                <DirectEvents>
                </DirectEvents>
            </ext:Button>

        </Buttons>
    </ext:Window>
</form>
