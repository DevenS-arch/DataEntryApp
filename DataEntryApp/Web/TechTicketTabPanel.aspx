<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechTicketTabPanel.aspx.cs" Inherits="DataEntryApp.Web.EmailTemplateList" %>

<%@ Register TagName="Template" TagPrefix="Tlist" Src="~/UserControls/TemplateFieldControls/TemplateList.ascx" %>
<%@ Register TagName="AddTemplate" TagPrefix="AT" Src="~/UserControls/TemplateFieldControls/AddTemplate.ascx" %>

<%@ Register TagName="Division" TagPrefix="DList" Src="~/UserControls/DivisionControls/Division.ascx" %>
<%@ Register TagName="Request" TagPrefix="RList" src="~/UserControls/RequestControls/Request.ascx" %>
<!DOCTYPE html>

<ext:XScript runat="server" ID="XScript">
</ext:XScript>

<ext:ResourceManager runat="server"></ext:ResourceManager>
<script>
    function Fun(a, panel) {
        alert(a.id+' '+panel.id);
    }
</script>
<ext:TabPanel
    runat="server"
    Width="1400"
    Height="800"
     Scrollable="Disabled"
    MarginSpec="0 0 20 0">
    <Items>
        
        <ext:Panel runat="server" Title="Divisions" ID="DivisionPanel">
            <Content>
                <DList:Division ID="DivisionData" runat="Server"></DList:Division>
            </Content>
        </ext:Panel>
         <ext:Panel runat="server" Title="Requests" ID="RequestPanel">
            <Content>
                <RList:Request ID="RequestData" runat="Server"></RList:Request>
            </Content>
        </ext:Panel>
        <ext:Panel runat="server" Title="Template" ID="TemplatePanel">
            <Content>
                <Tlist:Template ID="fieldTemplateData" runat="Server"></Tlist:Template>
            </Content>
        </ext:Panel>
       
    </Items>
   <Listeners>
       <%-- <TabChange Handler="function(a, pnl){
            //alert(pnl.id);
            App.direct.OnTabChange(pnl.id);
            }" />--%>
    </Listeners>
</ext:TabPanel>
<%--
<AT:AddTemplate ID="Template1" runat="Server" ></AT:AddTemplate>--%>
