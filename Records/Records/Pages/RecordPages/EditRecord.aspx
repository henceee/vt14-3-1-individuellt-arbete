<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="EditRecord.aspx.cs" Inherits="Records.Pages.RecordPages.EditRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <asp:FormView ID="FormView1" runat="server"
        ItemType="Records.Model.Record"
        DataKeyNames="RecordID"      
        DefaultMode="Edit"
        UpdateMethod="FormView1_UpdateItem" 
        RenderOuterTable="false">

        <EditItemTemplate>

              <%-- TITEL --%>

            <asp:Label ID="Label1" runat="server" AssociatedControlID="TitleTextBox" Text="Titel"></asp:Label><br />
           
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%#: BindItem.Title %>' MaxLength="30" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TitleTextBox" Text="*" ErrorMessage="Titel måste Anges"></asp:RequiredFieldValidator>
          
          
             <%-- Artist --%>

            <asp:Label ID="Label2" runat="server" AssociatedControlID="ArtistTextBox" Text="Artist"></asp:Label>
           
            <asp:TextBox ID="ArtistTextBox" runat="server" Text='<%#: BindItem.Artist %>' MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ArtistTextBox" Text="*" ErrorMessage="Artist måste Anges"></asp:RequiredFieldValidator>
            

             <%-- Speltid --%>

            <asp:Label ID="Label3" runat="server" AssociatedControlID="PlaytimeTextBox" Text="Speltid"></asp:Label>
            
            <asp:TextBox ID="PlaytimeTextBox" runat="server" Text='<%#: BindItem.Playtime %>' MaxLength="6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PlaytimeTextBox" Text="*" ErrorMessage="Speltid måste Anges"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*" ErrorMessage="Ange speltid i formatet MM:SS eller MMM:SS" ControlToValidate="PlaytimeTextBox"
                ValidationExpression="^[0-9]{2}[0-9]?[:][0-5][0-9]$"></asp:RegularExpressionValidator>
            

            <%-- ReleaseDatum --%>

            <asp:Label ID="Label4" runat="server" AssociatedControlID="ReleaseDateTextBox" Text="ReleaseDatum"></asp:Label>
          
            <asp:TextBox ID="ReleaseDateTextBox" runat="server" Text='<%#: BindItem.Releasedate%>' MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ReleaseDateTextBox" Text="*" ErrorMessage="Releasedatum måste anges!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Text="*" ErrorMessage="Releasedatum måste kunna tolkas som ett giltigt datum." ControlToValidate="ReleaseDateTextBox"
                ValidationExpression="^(19|20)\d\d([-/.])(0?[1-9]|1[012])\2(0?[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>
            

            <%-- Skivbolag--%>

            <asp:Label ID="Label5" runat="server" AssociatedControlID="RecordLabelTextBox" Text="Skivbolag"></asp:Label>
            
            <asp:TextBox ID="RecordLabelTextBox" runat="server" Text='<%#: BindItem.Recordlabel %>' MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ErrorMessage="Skivbolag måste anges!" ControlToValidate="RecordLabelTextBox"></asp:RequiredFieldValidator>

        </EditItemTemplate>

    </asp:FormView>

    <fieldset>
            <legend>Övriga uppgifter</legend>

        <asp:FormView ID="FormView2" runat="server"></asp:FormView>

    </fieldset>

</asp:Content>
