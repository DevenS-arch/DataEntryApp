<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Request.ascx.cs" Inherits="TechTicket.DataEntry.UserControls.Request" %>

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

        var editRequest = function (editor, e) {
            // Call DirectMethod
            //if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
            App.direct.UC.EditRequest(e.field, e.originalValue, e.value, e.record.data);
            //}
        };

        var OnAddRequest = function () {
            var grid = #{ RequestPanel },
                record;
            grid.editingPlugin.cancelEdit();

            record = grid.store.insert(0, {
                DivisionName: '',
                RequestName: ''
            });
            grid.editingPlugin.startEdit(record[0]);
        };


</script>

</ext:XScript>


<ext:Panel
    runat="server"
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
                <ext:Panel
                    runat="server"
                    Closable="false"
                    Width="500"
                    Collapsible="true"
                    Title="Requests"
                    Maximizable="true"
                    Layout="Fit">
                    <Items>
                        <ext:GridPanel ID="RequestPanel" runat="server" Border="false"
                            Height="480">
                            <Store>
                                <ext:Store ID="RequestStore" runat="server" PageSize="10">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="Id">
                                            <Fields>
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
                                            <ext:ComboBox ID="DivisionComboBox" runat="Server"
                                                MaxWidth="250"
                                                Text="Select Division"
                                                ValueField="Id"
                                                DisplayField="DivisionName"
                                                Editable="false"
                                                AllowBlank="false">
                                                <Store>
                                                    <ext:Store ID="ReqDivisionStore" runat="server">
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
                                    <ext:CommandColumn runat="server" Width="33px">
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
                                </Columns>
                            </ColumnModel>
                            <Plugins>
                                <ext:RowEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editRequest" />
                                    </Listeners>
                                </ext:RowEditing>
                            </Plugins>
                            <BottomBar>
                                <ext:PagingToolbar runat="server" HideRefresh="True">
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
            </Items>

        </ext:FormPanel>
    </Items>
</ext:Panel>

