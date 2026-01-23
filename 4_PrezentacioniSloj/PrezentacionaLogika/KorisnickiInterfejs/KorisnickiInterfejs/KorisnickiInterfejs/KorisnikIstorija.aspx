<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KorisnikIstorija.aspx.cs" Inherits="KorisnickiInterfejs.KorisnikIstorija" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Istorija termina</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .grid { margin-top: 20px; border-collapse: collapse; width: 100%; }
        .grid th, .grid td { border: 1px solid #ccc; padding: 8px; text-align: left; }
        .grid th { background-color: #f2f2f2; }
        #lblPoruka { color: red; margin-top: 10px; display: block; }
        #lblKorisnik { font-weight: bold; font-size: 1.2em; margin-bottom: 10px; display: block; }
        #btnPocetna { margin-top: 15px; padding: 5px 15px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblKorisnik" runat="server" />
        <asp:GridView ID="gvIstorija" runat="server" AutoGenerateColumns="true" CssClass="grid" />
        <asp:Label ID="lblPoruka" runat="server" />
        <br />
        <asp:Button ID="btnPocetna" runat="server" Text="Početna" OnClick="btnPocetna_Click" />
    </form>
</body>
</html>
