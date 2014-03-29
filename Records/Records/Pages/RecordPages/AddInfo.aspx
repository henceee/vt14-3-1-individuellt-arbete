<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="AddInfo.aspx.cs" Inherits="Records.Pages.RecordPages.AddInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="contentdiv">
    <h1>   <asp:Literal ID="AddInfoHeaderLiteral" runat="server" Text="Lägg till som fysisk skiva"></asp:Literal> </h1>
    
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:FormView ID="FormView2" runat="server"
         ItemType="Records.Model.Record"
         DataKeyNames="RecordID"
         SelectMethod="FormView2_GetItem"
         DefaultMode="ReadOnly">

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
        
                                  <%-- Digital --%>

    <asp:FormView ID="FormView1" runat="server"
        ItemType="Records.Model.DigitalRecord"
        DataKeyNames="RecordID"
        InsertMethod="FormView1_InsertItem"
        DefaultMode="Insert"
        SelectMethod="FormView1_GetItem">
               
        <InsertItemTemplate>
                                  <%-- Storlek --%>            

            <fieldset>
            <legend>Digital Skiva</legend>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="DiscSizeTextBox" Text="Storlek"></asp:Label><br />
            
            <asp:TextBox ID="DiscSizeTextBox" runat="server" MaxLength="6" Text='<%# BindItem.DiscSize %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DiscSizeTextBox" Text="*" ErrorMessage="Storlek måste anges"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="DiscSizeTextBox" Text="*"
                ErrorMessage="Ange storlek i rätt format! T.ex 1 gb, eller 1gb"
                ValidationExpression='^[1-9][0-9]?[0-9]?\s?[a-z]{2}$'></asp:RegularExpressionValidator>
            
             <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Spara"/>
             </fieldset>
        </InsertItemTemplate>

        
   </asp:FormView>

                   

        <asp:FormView ID="FormView3" runat="server"
            ItemType="Records.Model.PhysicalRecord"
            DataKeyNames="RecordID"
            InsertMethod="FormView3_InsertItem"
            DefaultMode="Insert">

            <InsertItemTemplate>
            
                <fieldset>
                <label> Fysisk skiva</label> <br /><br />
                    
                            <%-- Inköpspris --%>

            <asp:Label ID="Label6" runat="server" AssociatedControlID="PriceTextBox" Text="Inköpspris"></asp:Label> <br />

            <asp:TextBox ID="PriceTextBox" runat="server" MaxLength="6"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PriceTextBox" Text="*"
                ErrorMessage="Ange ett inköpspris"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PriceTextBox" Text="*"
                ErrorMessage="Ange inköpspriset som ett flytal med högst 4 tal följt av två decimaler" ValidationExpression="^[0-9]{1,4}[.][0-9]{2}$"></asp:RegularExpressionValidator>
            
                            <%-- Inköpsdatum --%>

            <asp:Label ID="Label7" runat="server" AssociatedControlID="PurchaseDateTextBox" Text="Inköpsdatum"></asp:Label>

            <asp:TextBox ID="PurchaseDateTextBox" runat="server" Text='<%# BindItem.DateofPurchase %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="PurchaseDateTextBox" Text="*"
                ErrorMessage=""></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator2" runat="server"
                Text="*" ErrorMessage="Inköpsdatum måste kunna tolkas som ett giltigt datum."
                ControlToValidate="PurchaseDateTextBox" Operator="DataTypeCheck" Type="Date"/>       

            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Insert" Text="Spara"/>
                </fieldset>
        </InsertItemTemplate>

        </asp:FormView>

    
        
        
  </div>
</asp:Content>
