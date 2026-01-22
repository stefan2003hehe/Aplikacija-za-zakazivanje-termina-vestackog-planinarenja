<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminKorisnici.aspx.cs" Inherits="KorisnickiInterfejs.AdminKorisnici" %>

<!DOCTYPE html>
<html lang="sr">
<head runat="server">
    <meta charset="utf-8" />
    <link href="Styles.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <h2>Upravljanje korisnicima</h2>

            <!-- 🔍 FILTER PO IMENU -->
            <asp:TextBox ID="txtFilterIme" runat="server" Placeholder="Unesite ime za filtriranje" />
            <asp:Button ID="btnFilter" runat="server" Text="Filtriraj" OnClick="btnFilter_Click" />
            <asp:Button ID="btnPrikaziSve" runat="server" Text="Prikaži sve" OnClick="btnPrikaziSve_Click" /><br /><br />

            <!-- 🔽 DROPDOWN ZA POL -->
            <asp:DropDownList ID="ddlPol" runat="server">
                <asp:ListItem Text="-- Izaberite pol --" Value="" />
                <asp:ListItem Text="M" Value="M" />
                <asp:ListItem Text="Ž" Value="Ž" />
            </asp:DropDownList>

            <!-- Dugme za parametarsku štampu -->
            <asp:Button ID="btnStampajPoPolu" runat="server" Text="Štampaj po polu" OnClick="btnStampajPoPolu_Click" /><br /><br />

            <!-- 🔢 TABELA KORISNIKA -->
            <asp:GridView ID="gvKorisnici" runat="server" ClientIDMode="Static"
                AutoGenerateColumns="False" DataKeyNames="IDKorisnik"
                OnRowEditing="gvKorisnici_RowEditing"
                OnRowUpdating="gvKorisnici_RowUpdating"
                OnRowCancelingEdit="gvKorisnici_RowCancelingEdit"
                OnRowDeleting="gvKorisnici_RowDeleting"
                AllowPaging="True" PageSize="10">
                <Columns>
                    <asp:BoundField DataField="IDKorisnik" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Ime" HeaderText="Ime" />
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                    <asp:BoundField DataField="Pol" HeaderText="Pol" />
                    <asp:BoundField DataField="BrojTelefona" HeaderText="Telefon" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="KorisnickoIme" HeaderText="Korisničko ime" />
                    <asp:BoundField DataField="DatumRodjenja" HeaderText="Datum rođenja" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <h3>Dodaj korisnika</h3>
            <asp:TextBox ID="txtIme" runat="server" Placeholder="Ime" /><br />
            <asp:TextBox ID="txtPrezime" runat="server" Placeholder="Prezime" /><br />
            <asp:TextBox ID="txtPol" runat="server" Placeholder="Pol (M/Ž)" /><br />
            <asp:TextBox ID="txtTelefon" runat="server" Placeholder="Telefon" /><br />
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" /><br />
            <asp:TextBox ID="txtKorisnickoIme" runat="server" Placeholder="Korisničko ime" /><br />
            <asp:TextBox ID="txtSifra" runat="server" TextMode="Password" Placeholder="Šifra" /><br />
            <asp:TextBox ID="txtDatumRodjenja" runat="server" Placeholder="Datum rođenja (yyyy-MM-dd)" /><br />
            <asp:Button ID="btnDodajKorisnika" runat="server" Text="Dodaj korisnika" OnClick="btnDodajKorisnika_Click" /><br /><br />

            <asp:Label ID="lblStatus" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
