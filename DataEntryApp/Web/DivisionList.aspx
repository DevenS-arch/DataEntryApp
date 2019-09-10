<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DivisionList.aspx.cs" Inherits="TechTicket.DataEntry.Web.DivisionList" MasterPageFile="~/Site.Master" %>

<%@ Register TagName="Division" TagPrefix="DList" Src="~/UserControls/DivisionControls/Division.ascx" %>
<%@ Register TagName="Request" TagPrefix="RList" src="~/UserControls/RequestControls/Request.ascx" %>


<asp:Content ID="requestContent" ContentPlaceHolderID="requestCPH" runat="server">
    <RList:Request ID="requestData" runat="Server" ></RList:Request>
</asp:Content>


<asp:Content ID="divisionContent" ContentPlaceHolderID="divisionCPH" runat="server">
    <DList:Division ID="divisionData" runat="Server" ></DList:Division>
</asp:Content>


