<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTrener.aspx.cs" Inherits="KorisnickiInterfejs.AdminTrener" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administracija Trenera</title>
    <style>
        .form-input { margin-bottom: 10px; }
        label { display: inline-block; width: 120px; }
        input[type=text], input[type=number] { width: 200px; }
        .btn { margin-top: 10px; }
        .status { margin-top: 10px; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Dodavanje Trenera</h2>
        <div class="form-input">
            <label>Ime:</label>
            <asp:TextBox ID="txtIme" runat="server" />
        </div>
        <div class="form-input">
            <label>Prezime:</label>
            <asp:TextBox ID="txtPrezime" runat="server" />
        </div>
        <div class="form-input">
            <label>Pol:</label>
            <asp:TextBox ID="txtPol" runat="server" />
        </div>
        <div class="form-input">
            <label>Telefon:</label>
            <asp:TextBox ID="txtTelefon" runat="server" />
        </div>
        <div class="form-input">
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" />
        </div>
        <div class="form-input">
            <label>Sertifikati:</label>
            <asp:TextBox ID="txtSertifikati" runat="server" />
        </div>
        <div class="form-input">
            <label>Satnica:</label>
            <asp:TextBox ID="txtSatnica" runat="server" />
        </div>
        <div class="form-input">
            <label>Korisničko ime:</label>
            <asp:TextBox ID="txtKorisnickoIme" runat="server" />
        </div>
        <div class="form-input">
            <label>Šifra:</label>
            <asp:TextBox ID="txtSifra" runat="server" TextMode="Password" />
        </div>
        <div class="form-input">
            <asp:Button ID="btnDodajTrenera" runat="server" Text="Dodaj Trenera" OnClick="btnDodajTrenera_Click" CssClass="btn" />
        </div>
        <div class="status">
            <asp:Label ID="lblStatus" runat="server" />
        </div>

        <h2>Lista Trenera</h2>
        <asp:GridView ID="gvTreneri" runat="server" AutoGenerateColumns="False" DataKeyNames="IDTrener"
            OnRowEditing="gvTreneri_RowEditing"
            OnRowCancelingEdit="gvTreneri_RowCancelingEdit"
            OnRowUpdating="gvTreneri_RowUpdating"
            OnRowDeleting="gvTreneri_RowDeleting">
            <Columns>
                <asp:BoundField DataField="IDTrener" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Ime">
                    <ItemTemplate><%# Eval("Ime") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditIme" runat="server" Text='<%# Bind("Ime") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prezime">
                    <ItemTemplate><%# Eval("Prezime") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditPrezime" runat="server" Text='<%# Bind("Prezime") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pol">
                    <ItemTemplate><%# Eval("Pol") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditPol" runat="server" Text='<%# Bind("Pol") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telefon">
                    <ItemTemplate><%# Eval("BrojTelefona") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditTelefon" runat="server" Text='<%# Bind("BrojTelefona") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate><%# Eval("Email") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sertifikati">
                    <ItemTemplate><%# Eval("Sertifikati") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditSertifikati" runat="server" Text='<%# Bind("Sertifikati") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Satnica">
                    <ItemTemplate><%# Eval("Satnica") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditSatnica" runat="server" Text='<%# Bind("Satnica") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Korisničko ime">
                    <ItemTemplate><%# Eval("KorisnickoIme") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditKorisnickoIme" runat="server" Text='<%# Bind("KorisnickoIme") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Šifra">
                    <ItemTemplate><%# Eval("Sifra") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEditSifra" runat="server" Text='<%# Bind("Sifra") %>' /></EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
