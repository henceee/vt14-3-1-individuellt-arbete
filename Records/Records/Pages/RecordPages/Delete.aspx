<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Records.Pages.RecordPages.Delete" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:Panel ID="ConfirmPanel" runat="server">
    <p> Är du säker på att du vill ta bort skivan <b> <%-- Namnet på skivan i literal nedan --%>
        <asp:Literal ID="RecordTitleLiteral" runat="server" ViewStateMode="Enabled"></asp:Literal> </b>?</p>
    
    </asp:Panel>
    
        <asp:LinkButton ID="DeleteLinkButton" runat="server" Text="Ja, Ta bort skivan"
            OnCommand="DeleteLinkButton_Command" CommandArgument ='<%$ Routevalue:ID %>'/>
        <asp:HyperLink ID="CancelLinkButton" runat="server" Text="Avbryt"/>
        

</asp:Content>



