<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bilety.aspx.cs" Inherits="BiletyWeb.Bilety" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bilety MPK</title>
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
        .newStyle1 {
            border: thin solid #000000;
            table-layout: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>Witamy w aplikacji Bilety MPK!</h1>
    </div>
        

        
        <table align="center" class="newStyle1">
            <tr>
                <td class="auto-style2">
        

        
        <asp:Label ID="lblUczelnia" runat="server" Text="Uczelnia"></asp:Label></td>
                <td class="auto-style2"><asp:DropDownList ID="ddlUczelnia" runat="server"> 
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblNumerAlbumu" runat="server" Text="Numer albumu:"></asp:Label></td>
                <td> <asp:TextBox ID="tbNumerAlbumu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="lblMailUzytkownika" runat="server" Text="Adres email:"></asp:Label></td>
                <td> <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
         <asp:Label ID="lblDataWaznosci" runat="server" Text="Data ważności:"></asp:Label></td>
                <td> <asp:TextBox ID="tbDataWaznosci" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
         <asp:Label ID="lblDni" runat="server" Text="Dni do końca:"></asp:Label></td>
                <td> <asp:TextBox ID="tbDni" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:Button ID="btnSprawdz" runat="server" Text="Sprawdź" OnClick="btnSprawdz_Click" style="text-align: center" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:Button ID="btnDodaj0" runat="server" Text="Dodaj do bazy" OnClick="btnDodaj0_Click" style="text-align: center" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:Button ID="btnSprawdzWszystkie" runat="server" Text="Sprawdź wszystkie" OnClick="btnSprawdzWszystkie_Click" style="text-align: center" />
                </td>
            </tr>
        </table>
        <br />
        &nbsp;<br/>
        &nbsp; 
        <br/>
        &nbsp; 
        <br/>
         &nbsp; 
        <br/>
         &nbsp; 
        <br/>
        <br />
        <br />
    </form>
</body>
</html>
