<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechTicketTabPanel.aspx.cs" Inherits="DataEntryApp.Web.EmailTemplateList" %>

<%@ Register TagName="Template" TagPrefix="Tlist" Src="~/UserControls/TemplateFieldControls/TemplateList.ascx" %>
<%@ Register TagName="AddTemplate" TagPrefix="AT" Src="~/UserControls/TemplateFieldControls/AddTemplate.ascx" %>

<%@ Register TagName="Division" TagPrefix="DList" Src="~/UserControls/DivisionControls/Division.ascx" %>
<%@ Register TagName="Request" TagPrefix="RList" src="~/UserControls/RequestControls/Request.ascx" %>
<!DOCTYPE html>

<ext:XScript runat="server" ID="XScript">
</ext:XScript>

<ext:ResourceManager runat="server"></ext:ResourceManager>

<ext:TabPanel
    runat="server"
    Width="1400"
    Height="800"
     Scrollable="Disabled"
    MarginSpec="0 0 20 0">
    <Items>
        
        <ext:Panel runat="server" Title="Divisions">
            <Content>
                <DList:Division ID="DivisionData" runat="Server"></DList:Division>
            </Content>
        </ext:Panel>
         <ext:Panel runat="server" Title="Requests">
            <Content>
                <RList:Request ID="RequestData" runat="Server"></RList:Request>
            </Content>
        </ext:Panel>
        <ext:Panel runat="server" Title="Template">
            <Content>
                <Tlist:Template ID="fieldTemplateData" runat="Server"></Tlist:Template>
            </Content>
        </ext:Panel>
       
    </Items>
</ext:TabPanel>
<%--
<AT:AddTemplate ID="Template1" runat="Server" ></AT:AddTemplate>--%>
