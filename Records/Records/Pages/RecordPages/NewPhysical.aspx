<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="NewPhysical.aspx.cs" Inherits="Records.Pages.RecordPages.NewPhysical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id ="newrecord">
<h1>Ny Fysisk Skiva</h1>
     
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:FormView ID="FormView1" runat="server"
        ItemType="Records.Model.Record"
        DataKeyNames="RecordID"
        InsertMethod="FormView1_InsertItem"
        DefaultMode="Insert" 
        RenderOuterTable="false">

         <InsertItemTemplate>

            <%-- TITEL --%>

            <asp:Label ID="Label1" runat="server" AssociatedControlID="TitleTextBox" Text="Titel"></asp:Label><br />
           
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' MaxLength="30" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TitleTextBox" Text="*" ErrorMessage="Titel måste Anges"></asp:RequiredFieldValidator>
          
          
             <%-- Artist --%>

            <asp:Label ID="Label2" runat="server" AssociatedControlID="ArtistTextBox" Text="Artist"></asp:Label>
           
            <asp:TextBox ID="ArtistTextBox" runat="server" Text='<%# BindItem.Artist %>' MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ArtistTextBox" Text="*" ErrorMessage="Artist måste Anges"></asp:RequiredFieldValidator>
            

             <%-- Speltid --%>

            <asp:Label ID="Label3" runat="server" AssociatedControlID="PlaytimeTextBox" Text="Speltid"></asp:Label>
            
            <asp:TextBox ID="PlaytimeTextBox" runat="server" Text='<%# BindItem.Playtime %>' MaxLength="6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PlaytimeTextBox" Text="*" ErrorMessage="Speltid måste Anges"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*" ErrorMessage="Ange speltid i formatet MM:SS eller MMM:SS" ControlToValidate="PlaytimeTextBox"
                ValidationExpression="^[0-9]{2}[0-9]?[:][0-5][0-9]$"></asp:RegularExpressionValidator>
            

            <%-- ReleaseDatum --%>

            <asp:Label ID="Label4" runat="server" AssociatedControlID="ReleaseDateTextBox" Text="ReleaseDatum"></asp:Label>
          
            <asp:TextBox ID="ReleaseDateTextBox" runat="server" Text='<%# BindItem.Releasedate%>' MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ReleaseDateTextBox" Text="*" ErrorMessage="Releasedatum måste anges!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Text="*" ErrorMessage="Releasedatum måste kunna tolkas som ett giltigt datum." ControlToValidate="ReleaseDateTextBox"
                ValidationExpression="^(19|20)\d\d([-/.])(0?[1-9]|1[012])\2(0?[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>
            

            <%-- Skivbolag--%>

            <asp:Label ID="Label5" runat="server" AssociatedControlID="RecordLabelTextBox" Text="Skivbolag"></asp:Label>
            
            <asp:TextBox ID="RecordLabelTextBox" runat="server" Text='<%# BindItem.Recordlabel %>' MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ErrorMessage="Skivbolag måste anges!" ControlToValidate="RecordLabelTextBox"></asp:RequiredFieldValidator>



             <%-- Inköpspris --%>

             <asp:Label ID="Label6" runat="server" AssociatedControlID="PriceTextBox" Text="Inköpspris"></asp:Label>

             <asp:TextBox ID="PriceTextBox" runat="server" MaxLength="6"></asp:TextBox>

             <asp:RequiredFieldValidator runat="server" ControlToValidate="PriceTextBox" Text="*"
                 ErrorMessage="Ange ett inköpspris"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator runat="server" ControlToValidate="PriceTextBox" Text="*"
                 ErrorMessage="Ange inköpspriset som ett flytal med högst 4 tal följt av två decimaler" ValidationExpression="^[0-9]{1,4}[.][0-9]{2}$"></asp:RegularExpressionValidator>
            
              <%-- Inköpsdatum --%>

             <asp:Label ID="Label7" runat="server" AssociatedControlID="PurchaseDateTextBox" Text="Inköpsdatum"></asp:Label>

             <asp:TextBox ID="PurchaseDateTextBox" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="PurchaseDateTextBox" Text="*"
                 ErrorMessage=""></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Text="*"
                  ErrorMessage="Inköpsdatum måste kunna tolkas som ett giltigt datum." ControlToValidate="PurchaseDateTextBox"
                ValidationExpression="^(19|20)\d\d([-/.])(0?[1-9]|1[012])\2(0?[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>

              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Spara"/>
                          
             </InsertItemTemplate>

    </asp:FormView>

         </div>
</asp:Content>
