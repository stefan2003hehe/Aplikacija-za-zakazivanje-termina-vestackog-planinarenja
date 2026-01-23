<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KorisnikPrikaziT.aspx.cs" Inherits="KorisnickiInterfejs.KorisnikPrikaziT" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prikaz trenera</title>
    <style>
        body { font-family: Arial, sans-serif; background: #f5f5f5; padding: 40px; }
        h2 { color: #333; }
        .table { width: 90%; border-collapse: collapse; background: white; border: 1px solid #ccc; }
        .table th, .table td { padding: 8px 10px; border: 1px solid #ccc; }
        .table th { background: #eee; }
        .poruka { color: red; font-weight: bold; margin-top: 10px; display: block; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Lista trenera</h2>

            <asp:Label ID="lblPoruka" runat="server" CssClass="poruka"></asp:Label>

            <asp:GridView
                ID="gvTreneri"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table"
                EmptyDataText="Nema trenera u bazi."
                OnRowDataBound="gvTreneri_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="IDTrener" HeaderText="ID" />
                    <asp:BoundField DataField="Ime" HeaderText="Ime" />
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                    <asp:BoundField DataField="Pol" HeaderText="Pol" />
                    <asp:BoundField DataField="BrojTelefona" HeaderText="Telefon" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Sertifikati" HeaderText="Sertifikati" />
                    <asp:BoundField DataField="Satnica" HeaderText="Satnica (RSD)" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
