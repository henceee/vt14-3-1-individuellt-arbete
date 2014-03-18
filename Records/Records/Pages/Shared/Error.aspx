<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Records.Pages.Shared.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <div id="error">

    <p> Oops! Något gick fel. Vänligen försök igen!</p>

    
    <asp:HyperLink runat="server" NavigateUrl=' <%$ RouteUrl: routename=Records %>' Text="Tillbaka" />
    </div>
</asp:Content>
