<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/RecordCollection.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RecordCollection.Pages.RecordPages.List" %>

                <%--HUVUD--%>
<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

                 <%--INNEHÅLL--%>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

<asp:ListView ID="ListView1" runat="server"
    ItemType="RecordCollection.Model.Record"
    SelectMethod="ListView1_GetData"
    DataKeyNames="RecordID">
    
    <%--Mall för layouten--%>
    <LayoutTemplate>


        <%--Platshållare för skivor--%>
        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>

        </table>

    </LayoutTemplate>

    <ItemTemplate>       
       
        <dl class="Recordinfo">

            <dt>
                        
                <asp:HyperLink runat="server" NavigateUrl='<%#: "~/Pages/RecordPages/Details.aspx?id="+ Item.RecordID %>' Text='<%#: Item.Title %>'/>
            </dt>
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
            

        </dl>
          

    </ItemTemplate>

    <EmptyDataTemplate>

        <p>Skivor Saknas.</p>

    </EmptyDataTemplate>


</asp:ListView>





</asp:Content>

