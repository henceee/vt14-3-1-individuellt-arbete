<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="NewDigital.aspx.cs" Inherits="Records.Pages.RecordPages.NewDigital"   %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>Ny Digital Skiva</h1>
   
    <%--Skiva--%>
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    
        
    <asp:FormView ID="FormView2" runat="server"
        ItemType="Records.Model.Record"
        DataKeyNames="RecordID"           
        InsertMethod="FormView2_InsertItem"  
        DefaultMode="Insert"           
        RenderOuterTable="false">    
       
       
        <InsertItemTemplate>

            <%-- TITEL --%>

            <asp:Label runat="server" AssociatedControlID="TitleTextBox" Text="Titel"></asp:Label><br />
           
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%#: BindItem.Title %>' MaxLength="30" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TitleTextBox" Text="*" ErrorMessage="Titel måste Anges"></asp:RequiredFieldValidator>
          
          
             <%-- Artist --%>

            <asp:Label runat="server" AssociatedControlID="ArtistTextBox" Text="Artist"></asp:Label>
           
            <asp:TextBox ID="ArtistTextBox" runat="server" Text='<%#: BindItem.Artist %>' MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ArtistTextBox" Text="*" ErrorMessage="Artist måste Anges"></asp:RequiredFieldValidator>
            

             <%-- Speltid --%>

            <asp:Label runat="server" AssociatedControlID="PlaytimeTextBox" Text="Speltid"></asp:Label>
            
            <asp:TextBox ID="PlaytimeTextBox" runat="server" Text='<%#: BindItem.Playtime %>' MaxLength="6"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="PlaytimeTextBox" Text="*" ErrorMessage="Speltid måste Anges"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" Text="*" ErrorMessage="Ange speltid i formatet MM:SS eller MMM:SS" ControlToValidate="PlaytimeTextBox"
                ValidationExpression="^[0-9]{2}[0-9]?[:][0-5][0-9]$"></asp:RegularExpressionValidator>
            

            <%-- ReleaseDatum --%>

            <asp:Label runat="server" AssociatedControlID="ReleaseDateTextBox" Text="ReleaseDatum"></asp:Label>
          
            <asp:TextBox ID="ReleaseDateTextBox" runat="server" Text='<%#: BindItem.Releasedate%>' MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ReleaseDateTextBox" Text="*" ErrorMessage="Releasedatum måste anges!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" Text="*" ErrorMessage="Releasedatum måste kunna tolkas som ett giltigt datum." ControlToValidate="ReleaseDateTextBox"
                ValidationExpression="^(19|20)\d\d([-/.])(0?[1-9]|1[012])\2(0?[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>
            

            <%-- Skivbolag--%>

            <asp:Label runat="server" AssociatedControlID="RecordLabelTextBox" Text="Skivbolag"></asp:Label>
            
            <asp:TextBox ID="RecordLabelTextBox" runat="server" Text='<%#: BindItem.Recordlabel %>' MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" Text="*" ErrorMessage="Skivbolag måste anges!" ControlToValidate="RecordLabelTextBox"></asp:RequiredFieldValidator>

            

            <%-- Storlek --%>

            <asp:Label ID="Label1" runat="server" AssociatedControlID="RecordLabelTextBox" Text="Storlek"></asp:Label>
            
            <asp:TextBox ID="DiscSizeTextBox" runat="server" MaxLength="6"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="DiscSizeTextBox" Text="*" ErrorMessage="Storlek måste anges"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="DiscSizeTextBox" Text="*"
                ErrorMessage="Ange storlek i rätt format! T.ex 1 gb, eller 1gb"
                ValidationExpression='^[1-9][0-9]?[0-9]?\s?[a-z]{2}$'></asp:RegularExpressionValidator>
            
             <asp:LinkButton runat="server" CommandName="Insert" Text="Spara"/>

                
        </InsertItemTemplate>

        <ItemTemplate>

        </ItemTemplate>

    </asp:FormView>
    



</asp:Content>


