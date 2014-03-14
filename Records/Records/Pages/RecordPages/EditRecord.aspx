<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Records.Master" AutoEventWireup="true" CodeBehind="EditRecord.aspx.cs" Inherits="Records.Pages.RecordPages.EditRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    <asp:Panel ID="UppdateMessagePanel" runat="server" Visible="false">
            <p><asp:Literal ID="UppdateMessage" runat="server"> {0}</asp:Literal></p>
        </asp:Panel>

       <asp:FormView ID="FormView1" runat="server"
        ItemType="Records.Model.Record"
        DataKeyNames="RecordID"      
        DefaultMode="Edit"
        UpdateMethod="FormView1_UpdateItem"
        SelectMethod="FormView1_GetItem"
        RenderOuterTable="false"
        >

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
          
            <asp:TextBox ID="ReleaseDateTextBox" runat="server" Text='<%#: Item.Releasedate.ToShortDateString()  %>' MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ReleaseDateTextBox" Text="*" ErrorMessage="Releasedatum måste anges!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Text="*" ErrorMessage="Releasedatum måste kunna tolkas som ett giltigt datum." ControlToValidate="ReleaseDateTextBox"
                ValidationExpression="^(19|20)\d\d([-/.])(0?[1-9]|1[012])\2(0?[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>
            

            <%-- Skivbolag--%>

            <asp:Label ID="Label5" runat="server" AssociatedControlID="RecordLabelTextBox" Text="Skivbolag"></asp:Label>
            
            <asp:TextBox ID="RecordLabelTextBox" runat="server" Text='<%#: BindItem.Recordlabel %>' MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ErrorMessage="Skivbolag måste anges!" ControlToValidate="RecordLabelTextBox"></asp:RequiredFieldValidator>

             <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara" CausesValidation="false" />

        </EditItemTemplate>

    </asp:FormView>

    <fieldset>
            <legend>Övriga Uppgifter</legend>

        <asp:FormView ID="FormView2" runat="server"
        ItemType="Records.Model.DigitalRecord"
        DataKeyNames="RecordID"
        UpdateMethod="FormView2_UpdateItem"
        SelectMethod="FormView2_GetItem"
        >

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
              
            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Redigera"/>
        </ItemTemplate>

        <EditItemTemplate>
            <b>  <asp:Literal ID="Literal1" runat="server">Skivtyp:</asp:Literal> </b>
          
                
            <asp:Literal ID="Literal2"  runat="server"> Digital Skiva </asp:Literal>            

            <asp:Label ID="Label6" runat="server" AssociatedControlID="" Text="Storlek på disken:"></asp:Label>            
               
            <asp:TextBox ID="DiscSizeTextBox" runat="server" Text='<%#: BindItem.DiscSize %>' MaxLength="6"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DiscSizeTextBox" Text="*" ErrorMessage="Storlek måste anges"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="DiscSizeTextBox" Text="*"
                ErrorMessage="Ange storlek i rätt format! T.ex 1 gb, eller 1gb"
                ValidationExpression='^[1-9][0-9]?[0-9]?\s?[a-z]{2}$'></asp:RegularExpressionValidator> 

            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara" CausesValidation="false" />
        </EditItemTemplate>
           
            

    </asp:FormView>


      <asp:FormView ID="FormView3" runat="server"
        ItemType="Records.Model.PhysicalRecord"
        DataKeyNames="RecordID"
        UpdateMethod="FormView3_UpdateItem"
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

                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Redigera"/>
            </ItemTemplate>

            <EditItemTemplate>

                 <%-- Inköpspris --%>

        
             <asp:Label ID="Label6" runat="server" AssociatedControlID="PriceTextBox" Text="Inköpspris"></asp:Label>

             <asp:TextBox ID="PriceTextBox" runat="server" MaxLength="6" Text='<%#: Item.PriceAtPurchase %>'></asp:TextBox>

             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="PriceTextBox" Text="*"
                 ErrorMessage="Ange ett inköpspris"></asp:RequiredFieldValidator>
            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="PriceTextBox" Text="*"
                 ErrorMessage="Ange inköpspriset som ett flytal med högst 4 tal följt av två decimaler" ValidationExpression="^[0-9]{1,4}[.][0-9]{2}$"></asp:RegularExpressionValidator>--%>
            
              <%-- Inköpsdatum --%> 

             <asp:Label ID="Label7" runat="server" AssociatedControlID="PurchaseDateTextBox"> </asp:Label>

             <asp:TextBox ID="PurchaseDateTextBox" runat="server" Text='<%#: Item.DateofPurchase.ToShortDateString() %>'></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="PurchaseDateTextBox" Text="*"
                 ErrorMessage=""></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Text="*"
                  ErrorMessage="Inköpsdatum måste kunna tolkas som ett giltigt datum." ControlToValidate="PurchaseDateTextBox"
                ValidationExpression="^(19|20)\d\d([-/.])(0?[1-9]|1[012])\2(0?[1-9]|[12][0-9]|3[01])$"></asp:RegularExpressionValidator>

                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara" CausesValidation="false" />
               
            </EditItemTemplate>

        </asp:FormView>
        

    </fieldset>

</asp:Content>
