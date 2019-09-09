<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Division.ascx.cs" Inherits="TechTicket.DataEntry.UserControls.Division" %>

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


        var edit = function (editor, e) {
            // Call DirectMethod
            //if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
            App.direct.UC.EditDivision(e.field, e.originalValue, e.value, e.record.data);
            // }
        };


        var OnAddDivision = function () {
            var grid = #{ DivisionPanel },
                record;
            grid.editingPlugin.cancelEdit();

            record = grid.store.insert(0, {
                DivisionName: '',
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
            ID="divisionForm"
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
                    Title="Divisions"
                    Maximizable="true"
                    Layout="FormLayout">
                    <Items>
                        <ext:GridPanel ID="DivisionPanel" runat="server" Border="false"
                            Height="480">
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
                    App.direct.UC.OnDeleteDivision(record.data);
                }
            }, this);" />
                                        </Listeners>
                                    </ext:CommandColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" Mode="Single" />
                            </SelectionModel>
                            <Plugins>
                                <ext:RowEditing runat="server" ClicksToEdit="1">
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

<%--<form runat="server">
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
</form>--%>
