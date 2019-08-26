<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DivisionList.aspx.cs" Inherits="DataEntryApp.Web.DivisionList" %>
<%@ Register TagName="Division" TagPrefix="DList" src="~/UserControls/DivisionControls/Division.ascx" %>

<ext:XScript runat="server" ID="XScript">
</ext:XScript>

<DList:Division ID="divisionData" runat="Server" ></DList:Division>

