<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestList.aspx.cs" Inherits="DataEntryApp.Web.RequestList" %>

<%@ Register TagName="Request" TagPrefix="RList" src="~/UserControls/RequestControls/Request.ascx" %>


<asp:Content ID="requestContent" ContentPlaceHolderID="requestCPH" runat="server">
    <RList:Request ID="requestData" runat="Server" ></RList:Request>
</asp:Content>
