﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Records.Pages.RecordPages.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
   

    <asp:FormView ID="FormView1" runat="server"
        ItemType="Records.Model.Record"
        DataKeyNames="RecordID"
        SelectMethod="FormView1_GetItem">

        <ItemTemplate>

            <h1> <%#: Item.Title %> </h1>

             <dd>
                <b>Artist:</b>
            </dd>
            <dd>
                <%#: Item.Artist %>
              
            </dd>
            <dd>
               <b>Speltid:</b> 
            </dd>
            <dd>
                <%#: Item.Playtime %>
                 
            </dd>
            <dd>
               <b>Releasedatum:</b> 
            </dd>
             <dd>
                 <%#: Item.Releasedate.ToShortDateString() %>
                 
            </dd>
            <dd>
                <b>Skivbolag:</b>
            </dd>
             <dd>
                 <%#: Item.Recordlabel %>
                 
            </dd>
          <%--  <asp:HyperLink ID="DeleteHyperLink" NavigateURL='<%#: GetRouteUrl("RecordDelete", new {id = Item.RecordID} %>' runat="server">Ta bort</asp:HyperLink>--%>
        </ItemTemplate>

    </asp:FormView>

</asp:Content>


