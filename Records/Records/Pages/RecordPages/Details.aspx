<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Records.Pages.RecordPages.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="contentdiv">
     <asp:Panel ID="UppdateMessagePanel" runat="server" Visible="false">
            <p><asp:Literal ID="UppdateMessage" runat="server">Skivan {0}</asp:Literal></p>
        </asp:Panel>

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

            
        </ItemTemplate>
    </asp:FormView>

    <fieldset>
            <legend>Övriga uppgifter</legend>

    <asp:FormView ID="FormView2" runat="server"
        ItemType="Records.Model.DigitalRecord"
        DataKeyNames="RecordID"
        SelectMethod="FormView2_GetItem">

        <ItemTemplate>
            
            

            <dd>
                <b>Skivtyp:</b>
            </dd>
            <dd>
                Digital Skiva
            </dd>
            <dd>
                <b>Storlek på disken:</b>
            </dd>
            <dd>
                <%#: Item.DiscSize %>
              
            </dd>
            
            
            
        </ItemTemplate>
  

    </asp:FormView>


    <asp:FormView ID="FormView3" runat="server"
        ItemType="Records.Model.PhysicalRecord"
        DataKeyNames="RecordID"
        SelectMethod="FormView3_GetItem">

        <ItemTemplate>
            
             <dd>
                <b>Skivtyp:</b>
            </dd>
            <dd>
                Fysisk Skiva
            </dd>
            <dd>
                <b>InköpsPris</b>
            </dd>
            <dd>
                <%#: Item.PriceAtPurchase %>
                              
            </dd>
            <dd>
                <b>Inköpsdatum</b>
            </dd>
            <dd>
                <%#: Item.DateofPurchase.ToShortDateString() %>
                              
            </dd>            
            
        </ItemTemplate>

    </asp:FormView>

    </fieldset>

        <ul id="options">
            <li>    <asp:HyperLink ID="DeleteHyperLink" runat="server" Text="Ta bort"/>             </li>
            <li>    <asp:HyperLink ID="ReturnHyperLink" runat="server"  Text="Tillbaka"/>           </li>
            <li>    <asp:HyperLink ID="EditHyperLink" runat="server" Text="Redigera" />             </li>
            <li>    <asp:HyperLink ID="AddInfoHyperLink" runat="server" Text="Lägg till som {0}"/>  </li>    
           
                    
        </ul>                

                
                
                
            </div>
    
</asp:Content>


