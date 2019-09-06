<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateList.aspx.cs" Inherits="DataEntryApp.Web.EmailTemplateList" %>

<%@ Register TagName="Template" TagPrefix="Tlist" Src="~/UserControls/TemplateFieldControls/TemplateList.ascx" %>
<%@ Register TagName="AddTemplate" TagPrefix="AT" Src="~/UserControls/TemplateFieldControls/AddTemplate.ascx" %>
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
        <ext:Panel runat="server" Title="Template">
            <Content>
                <Tlist:Template ID="fieldTemplateData" runat="Server"></Tlist:Template>
            </Content>
        </ext:Panel>
    </Items>
</ext:TabPanel>
<%--
<AT:AddTemplate ID="Template1" runat="Server" ></AT:AddTemplate>--%>
