<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Records.Pages.RecordPages.List" %>

<asp:Content ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div id="contentdiv">

    <h1>Skivor</h1>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:Panel ID="UppdateMessagePanel" runat="server" Visible="false">
            <p><asp:Literal ID="UppdateMessage" runat="server">Kontakten {0}</asp:Literal></p>
        </asp:Panel>
    
<br />
<asp:ListView ID="ListView1" runat="server"
    ItemType="Records.Model.Record"
    SelectMethod="ListView1_GetData1"
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
                        
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("RecordDetails", new {id =Item.RecordID }) %>' Text='<%#: Item.Title %>'/>
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
            <br />
            <dd>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#: GetRouteUrl("RecordDetails", new {id =Item.RecordID }) %>' Text="Mer Info"/>
            </dd>
        </dl>
          

    </ItemTemplate>

    <EmptyDataTemplate>

        <p>Skivor Saknas.</p>

    </EmptyDataTemplate>


</asp:ListView>
        </div>
</asp:Content>
