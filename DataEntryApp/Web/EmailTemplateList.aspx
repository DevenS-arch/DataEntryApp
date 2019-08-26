<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateList.aspx.cs" Inherits="DataEntryApp.Web.EmailTemplateList" %>
<%@ Register TagName="Template" TagPrefix="Tlist" src="~/UserControls/TemplateFieldControls/TemplateList.ascx" %>
<!DOCTYPE html>

<ext:XScript runat="server" ID="XScript">
</ext:XScript>

<Tlist:Template ID="fieldData" runat="Server" ></Tlist:Template>
