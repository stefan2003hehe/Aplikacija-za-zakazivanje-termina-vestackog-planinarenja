<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTermin.aspx.cs" Inherits="KorisnickiInterfejs.AdminTermin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administracija Termina</title>
    <style>
        .form-input { margin-bottom: 10px; }
        label { display: inline-block; width: 120px; }
        input[type=text], input[type=number], input[type=datetime-local] { width: 200px; }
        .btn { margin-top: 10px; }
        .status { margin-top: 10px; font-weight: bold; }
    </style>
    <script type="text/javascript">
        function izracunajCenu() {
            __doPostBack('IzracunajCenu', '');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Dodavanje Termina</h2>
        <div class="form-input">
            <label>Korisnik ID:</label>
            <asp:TextBox ID="txtIDKorisnik" runat="server" />
        </div>
        <div class="form-input">
            <label>Trener ID:</label>
            <asp:TextBox ID="txtIDTrener" runat="server" onchange="izracunajCenu()" />
        </div>
        <div class="form-input">
            <label>Datum i vreme:</label>
            <asp:TextBox ID="txtDatumVreme" runat="server" TextMode="DateTimeLocal" />
        </div>
        <div class="form-input">
            <label>Trajanje (sati):</label>
            <asp:TextBox ID="txtTrajanjeSati" runat="server" onchange="izracunajCenu()" />
        </div>
        <div class="form-input">
            <label>Ruta:</label>
            <asp:TextBox ID="txtRuta" runat="server" />
        </div>
        <div class="form-input">
            <label>Težina:</label>
            <asp:TextBox ID="txtTezina" runat="server" />
        </div>
        <div class="form-input">
            <label>Cena:</label>
            <asp:TextBox ID="txtCena" runat="server" ReadOnly="true" />
        </div>
        <div class="form-input">
            <asp:Button ID="btnDodajTermin" runat="server" Text="Dodaj Termin" OnClick="btnDodajTermin_Click" CssClass="btn" />
        </div>
        <div class="status">
            <asp:Label ID="lblStatus" runat="server" />
        </div>

        <h2>Lista Termina</h2>

        <asp:GridView ID="gvTermini" runat="server" AutoGenerateColumns="False" DataKeyNames="IDTermin"
            OnRowEditing="gvTermini_RowEditing"
            OnRowCancelingEdit="gvTermini_RowCancelingEdit"
            OnRowUpdating="gvTermini_RowUpdating"
            OnRowDeleting="gvTermini_RowDeleting">
            <Columns>
                <asp:BoundField DataField="IDTermin" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Korisnik">
                    <ItemTemplate>
                        <%# Eval("IDKorisnik") %> - <%# Eval("ImeKorisnika") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditIDKorisnik" runat="server" Text='<%# Bind("IDKorisnik") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trener">
                    <ItemTemplate>
                        <%# Eval("IDTrener") %> - <%# Eval("ImeTrenera") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditIDTrener" runat="server" Text='<%# Bind("IDTrener") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Datum i vreme">
                    <ItemTemplate>
                        <%# Eval("DatumVreme") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditDatumVreme" runat="server"
                            Text='<%# Bind("DatumVreme", "yyyy-MM-ddTHH:mm") %>' TextMode="DateTimeLocal" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trajanje sati">
                    <ItemTemplate>
                        <%# Eval("TrajanjeSati") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditTrajanjeSati" runat="server" Text='<%# Bind("TrajanjeSati") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ruta">
                    <ItemTemplate>
                        <%# Eval("Ruta") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditRuta" runat="server" Text='<%# Bind("Ruta") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Težina">
                    <ItemTemplate>
                        <%# Eval("Tezina") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditTezina" runat="server" Text='<%# Bind("Tezina") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cena">
                    <ItemTemplate>
                        <%# Eval("Cena") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditCena" runat="server" Text='<%# Bind("Cena") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
