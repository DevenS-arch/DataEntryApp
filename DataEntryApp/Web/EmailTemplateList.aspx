<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateList.aspx.cs" Inherits="DataEntryApp.Web.EmailTemplateList" %>
<%@ Register TagName="Template" TagPrefix="Tlist" src="~/UserControls/TemplateFieldControls/TemplateList.ascx" %>
<%@ Register TagName="AddTemplate" TagPrefix="AT" src="~/UserControls/TemplateFieldControls/AddTemplate.ascx" %>
<!DOCTYPE html>

<ext:XScript runat="server" ID="XScript">
</ext:XScript>

<ext:ResourceManager runat="server"></ext:ResourceManager>
<%--<Tlist:Template ID="fieldData" runat="Server" ></Tlist:Template>--%>

<AT:AddTemplate ID="Template1" runat="Server" ></AT:AddTemplate>
