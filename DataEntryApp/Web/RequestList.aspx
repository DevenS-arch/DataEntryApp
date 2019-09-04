<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestList.aspx.cs" Inherits="DataEntryApp.Web.RequestList" %>

<%@ Register TagName="Request" TagPrefix="RList" src="~/UserControls/RequestControls/Request.ascx" %>

<ext:XScript runat="server" ID="XScript">
</ext:XScript>

<RList:Request ID="requestData" runat="Server" ></RList:Request>