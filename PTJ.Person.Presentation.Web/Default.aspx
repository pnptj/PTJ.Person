<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Sök Person"></asp:Label>
    
    </div>
        <asp:TextBox ID="txtSearchPerson" runat="server" Width="470px"></asp:TextBox>
        <p>
            <asp:Button ID="btnSearch" runat="server" Text="Button" Width="117px" OnClick="btnSearch_Click" />
        </p>
        <p>
        <asp:Label ID="lblPersonResult" runat="server" Text="Results Persons"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="gvPersoner" 
                runat="server" 
                Height="210px" 
                Width="1023px" 
                AutoGenerateColumns="false"
                AutoGenerateSelectButton="true" 
                OnSelectedIndexChanged="gvPersoner_SelectedIndexChanged" BackColor="#CCFFCC">
                         <Columns>
             <asp:BoundField DataField="Id" 
                 HeaderText="Id" 
                 InsertVisible="False" ReadOnly="True" 
                 SortExpression="Id" />
              <asp:BoundField DataField="PersonNummer" 
                 HeaderText="PersonNummer" 
                 SortExpression="PersonNummer" />
              <asp:BoundField DataField="Efternamn" 
                 HeaderText="Efternamn" 
                 SortExpression="Efternamn" />
             <asp:BoundField DataField="MellanNamn" 
                 HeaderText="MellanNamn" 
                 SortExpression="MellanNamn" />
             <asp:BoundField DataField="FörNamn" 
                 HeaderText="FörNamn" 
                 SortExpression="FörNamn" />
         </Columns>
                         <HeaderStyle Height="5px" />
                         <RowStyle Height="5px" />
            </asp:GridView>
        </p>
        <asp:Label ID="lblResult" runat="server" Text="Results"></asp:Label>
        <p>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <asp:Label ID="lblGatuAdress" runat="server" Text="GatuAdresser"></asp:Label>
        </p>
             <asp:GridView ID="gvGatuAdresser" 
                runat="server" 
                Height="210px" 
                Width="1023px" 
                AutoGenerateColumns="false"
                AutoGenerateSelectButton="true" BackColor="#CCFFCC">
                         <Columns>
             <asp:BoundField DataField="Key.Id" 
                 HeaderText="Id" 
                 InsertVisible="False" ReadOnly="True" 
                 SortExpression="Id" />
              <asp:BoundField DataField="Value.Variant" 
                 HeaderText="Adress Variant" 
                 SortExpression="AdressRad1" />
              <asp:BoundField DataField="Key.AdressRad1" 
                 HeaderText="AdressRad1" 
                 SortExpression="AdressRad1" />
              <asp:BoundField DataField="Key.AdressRad2" 
                 HeaderText="AdressRad2" 
                 SortExpression="AdressRad2" />
              <asp:BoundField DataField="Key.AdressRad3" 
                 HeaderText="AdressRad3" 
                 SortExpression="AdressRad3" />              
              <asp:BoundField DataField="Key.AdressRad4" 
                 HeaderText="AdressRad4" 
                 SortExpression="AdressRad4" />              
              <asp:BoundField DataField="Key.AdressRad5" 
                 HeaderText="AdressRad5" 
                 SortExpression="AdressRad5" />               
              <asp:BoundField DataField="Key.Postnummer" 
                 HeaderText="Postnummer" 
                 SortExpression="Postnummer" />
             <asp:BoundField DataField="Key.Stad" 
                 HeaderText="Stad" 
                 SortExpression="Stad" />
             <asp:BoundField DataField="Key.Land" 
                 HeaderText="Land" 
                 SortExpression="Land" />
         </Columns>
                         <HeaderStyle Height="5px" />
                         <RowStyle Height="5px" />
       </asp:GridView>
        <%--<asp:ListBox ID="lbGatuAdresser" runat="server" Height="212px" Width="889px"></asp:ListBox>--%>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        <asp:Label ID="lblTelefon" runat="server" Text="TelefonNummer"></asp:Label>
        <br />
             <asp:GridView ID="gvTelefonNummer" 
                runat="server" 
                Height="210px" 
                Width="1023px" 
                AutoGenerateColumns="false"
                AutoGenerateSelectButton="true" BackColor="#CCFFCC">
           <Columns>
             <asp:BoundField DataField="Key.Id" 
                 HeaderText="Id" 
                 InsertVisible="False" ReadOnly="True" 
                 SortExpression="Id" />
              <asp:BoundField DataField="Value.Variant" 
                 HeaderText="Adress Variant" 
                 InsertVisible="False" ReadOnly="True" 
                 SortExpression="Variant" />
             <asp:BoundField DataField="Key.TelefonNummer" 
                 HeaderText="TelefonNummer" 
                 SortExpression="TelefonNummer" />
         </Columns>
                 <HeaderStyle Height="5px" />
                 <RowStyle Height="5px" />
       </asp:GridView>
        <%--<asp:ListBox ID="lbTelefonNummer" runat="server" Height="212px" Width="889px"></asp:ListBox>--%>
        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
        <asp:Label ID="lblMail" runat="server" Text="MailAdresser"></asp:Label>
        <br />
            <asp:GridView ID="gvMailAdresser" 
                runat="server" 
                Height="210px" 
                Width="1023px" 
                AutoGenerateColumns="false"
                AutoGenerateSelectButton="true" BackColor="#CCFFCC">
                         <Columns>
             <asp:BoundField DataField="Key.Id" 
                 HeaderText="Id" 
                 InsertVisible="False" ReadOnly="True" 
                 SortExpression="Id" />
              <asp:BoundField DataField="Value.Variant" 
                 HeaderText="Adress Variant" 
                 InsertVisible="False" ReadOnly="True" 
                 SortExpression="Variant" />
              <asp:BoundField DataField="Key.MailAdress" 
                 HeaderText="MailAdress" 
                 SortExpression="MailAdress" />
         </Columns>
                         <HeaderStyle Height="5px" />
                         <RowStyle Height="5px" />
       </asp:GridView>
        <%--<asp:ListBox ID="lbMailAdresser" runat="server" Height="212px" Width="889px"></asp:ListBox>--%>
    </form>
</body>
</html>
