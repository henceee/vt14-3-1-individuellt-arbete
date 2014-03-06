<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/RecordCollection.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RecordCollection.Pages.RecordPages.List" %>

                <%--HUVUD--%>
<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

                 <%--INNEHÅLL--%>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



<asp:ListView ID="ListView1" runat="server"
    ItemType="RecordCollection.Model.Record"
    SelectMethod="ListView1_GetData"
    DataKeyNames="RecordID">
    
    <%--Mall för layouten--%>
    <LayoutTemplate>

        <table>
        <tr>
            <th>
                Titel
            </th>
            <th>
                Artist
            </th>
            <th>
                Speltid
            </th>            
            <th>
                Releasedatum
            </th>
            <th>
                Skivbolag
            </th>
        </tr>

        <%--Platshållare för skivor--%>
        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>

        </table>

    </LayoutTemplate>

    <ItemTemplate>
       
           <tr>
               <td>
                   <asp:Label ID="TitleLabel" runat="server" Text="<%#: Item.Title %>"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="ArtistLabel" runat="server" Text="<%#: Item.Artist %>"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="PlaytimeLabel" runat="server" Text="<%#: Item.Playtime %>"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="ReleaseDateLabel" runat="server" Text="<%#: Item.Releasedate %>"></asp:Label>
               </td>
               <td>
                   <asp:Label ID="RecordlabelLabel" runat="server" Text="<%#: Item.Recordlabel %>"></asp:Label>
               </td>
           </tr>      

    </ItemTemplate>

    <EmptyDataTemplate>

        <p>Skivor Saknas.</p>

    </EmptyDataTemplate>


</asp:ListView>





</asp:Content>

