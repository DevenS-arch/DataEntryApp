<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DivisionList.aspx.cs" Inherits="DataEntryApp.Web.DivisionList" MasterPageFile="~/Site.Master" %>

<%@ Register TagName="Division" TagPrefix="DList" Src="~/UserControls/DivisionControls/Division.ascx" %>




<asp:Content ID="divisionContent" ContentPlaceHolderID="divisionCPH" runat="server">
    <DList:Division ID="divisionData" runat="Server" ></DList:Division>
</asp:Content>

<%--<asp:content id="Content1" contentplaceholderid="MainContent" runat="server"> 
    <ext:XScript runat="server" ID="XScript">
</ext:XScript>

    <DList:Division ID="divisionData" runat="Server" ></DList:Division>
</asp:content>--%>

