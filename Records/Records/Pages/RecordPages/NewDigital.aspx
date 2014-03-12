<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="NewDigital.aspx.cs" Inherits="Records.Pages.RecordPages.NewDigital"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>Ny Digital Skiva</h1>
   
    <%--Skiva--%>

    <%--SelectMethod="FormView2_GetItem"--%>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:FormView ID="FormView2" runat="server"
        ItemType="Records.Model.Record"
        DataKeyNames="RecordID"        
        InsertMethod="FormView2_InsertItem"
        SelectMethod="FormView2_GetItem"       
        DefaultMode="Insert"        
        ViewStateMode="Enabled"
        RenderOuterTable="false">    

        <ItemTemplate>

            <%#: Item.Title %>
            <%#: Item.Artist %>
            <%#: Item.Playtime %>
            <%#: Item.Releasedate %>
            <%#: Item.Recordlabel %>

        </ItemTemplate>
       
        <InsertItemTemplate>

            <%-- TITEL --%>

            <asp:Label runat="server" AssociatedControlID="TitleTextBox" Text="Titel"></asp:Label>
            <br />
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%#: BindItem.Title %>' MaxLength="30"></asp:TextBox>
            
            <br />
            <br />

             <%-- Artist --%>

            <asp:Label runat="server" AssociatedControlID="ArtistTextBox" Text="Artist"></asp:Label>
            <br />
            <asp:TextBox ID="ArtistTextBox" runat="server" Text='<%#: BindItem.Artist %>' MaxLength="20"></asp:TextBox>

            <br />
            <br />

             <%-- Speltid --%>

            <asp:Label runat="server" AssociatedControlID="PlaytimeTextBox" Text="Speltid"></asp:Label>
            <br />
            <asp:TextBox ID="PlaytimeTextBox" runat="server" Text='<%#: BindItem.Playtime %>' MaxLength="6"></asp:TextBox>

            <br />
            <br />

            <%-- ReleaseDatum --%>

            <asp:Label runat="server" AssociatedControlID="ReleaseDateTextBox" Text="ReleaseDatum"></asp:Label>
            <br />
            <asp:TextBox ID="ReleaseDateTextBox" runat="server" Text='<%#: BindItem.Releasedate%>' MaxLength="10"></asp:TextBox>

            <br />
            <br />

            <%-- Skivbolag--%>

            <asp:Label runat="server" AssociatedControlID="RecordLabelTextBox" Text="Skivbolag"></asp:Label>
            <br />
            <asp:TextBox ID="RecordLabelTextBox" runat="server" Text='<%#: BindItem.Recordlabel %>' MaxLength="20"></asp:TextBox>

            <br />
            <br />

             <asp:LinkButton runat="server" CommandName="Insert" Text="Spara"/>

            
            <br />
            <br />
        </InsertItemTemplate>

        <ItemTemplate>

        </ItemTemplate>

    </asp:FormView>
    

    <%--Digital--%>

     <%-- SelectMethod="FormView1_GetItem"--%>

    <asp:FormView ID="FormView1" runat="server"
        ItemType="Records.Model.DigitalRecord"
        DataKeyNames="RecordID"
      
        InsertMethod="FormView1_InsertItem"
        DefaultMode="Insert"
        RenderOuterTable="false"
        Enabled="false">

        <InsertItemTemplate>

            <%-- Skivbolag--%>

            <asp:Label ID="Label1" runat="server" AssociatedControlID="RecordLabelTextBox" Text="Storlek"></asp:Label>
            <br />
            <asp:TextBox ID="RecordLabelTextBox" runat="server" Text='<%#: BindItem.DiscSize %>' MaxLength="6"></asp:TextBox>
            <br />
            <br />
        
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Spara"/>
        </InsertItemTemplate>

    </asp:FormView>

</asp:Content>


