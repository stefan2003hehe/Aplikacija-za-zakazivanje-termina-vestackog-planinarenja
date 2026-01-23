<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KorisnikZakazi.aspx.cs" Inherits="KorisnickiInterfejs.KorisnikZakazi" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zakaži termin</title>
    <style>
        body { font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }
        .form-container { background: #fff; padding: 20px; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); max-width: 500px; margin: auto; }
        label { display: block; margin-top: 10px; }
        input, select { width: 100%; padding: 8px; margin-top: 5px; border-radius: 5px; border: 1px solid #ccc; }
        .btn { margin-top: 20px; padding: 10px; background: #4CAF50; color: white; border: none; cursor: pointer; width: 100%; border-radius: 5px; }
        .btn:hover { background: #45a049; }
        #divPrint { margin-top: 20px; padding: 15px; background: #e2e2e2; border-radius: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Zakaži termin</h2>

            <label for="ddlTrener">Trener:</label>
            <asp:DropDownList ID="ddlTrener" runat="server" onchange="updateCena()"></asp:DropDownList>

            <label for="txtDatumVreme">Datum i vreme:</label>
            <asp:TextBox ID="txtDatumVreme" runat="server" placeholder="yyyy-MM-dd HH:mm"></asp:TextBox>

            <label for="txtTrajanje">Trajanje (sati):</label>
            <asp:TextBox ID="txtTrajanje" runat="server" oninput="updateCena()"></asp:TextBox>

            <label for="txtRuta">Ruta:</label>
            <asp:TextBox ID="txtRuta" runat="server"></asp:TextBox>

            <label for="txtTezina">Težina:</label>
            <asp:TextBox ID="txtTezina" runat="server"></asp:TextBox>

            <label for="txtCena">Cena:</label>
            <asp:TextBox ID="txtCena" runat="server" ReadOnly="true"></asp:TextBox>

            <asp:Button ID="btnZakazi" runat="server" Text="Zakaži termin" CssClass="btn" OnClick="btnZakazi_Click" />
            <asp:Button ID="btnPrint" runat="server" Text="Štampa" CssClass="btn" OnClientClick="printDiv(); return false;" />

            <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
            <div id="divPrint" runat="server"></div>
        </div>
    </form>

    <script type="text/javascript">
        function updateCena() {
            var ddl = document.getElementById('<%= ddlTrener.ClientID %>');
            var trajanje = parseFloat(document.getElementById('<%= txtTrajanje.ClientID %>').value);
            var cenaInput = document.getElementById('<%= txtCena.ClientID %>');

            if (ddl.selectedIndex > 0 && !isNaN(trajanje) && trajanje > 0) {
                var satnica = parseFloat(ddl.options[ddl.selectedIndex].getAttribute('data-satnica'));
                var cena = satnica * trajanje;
                cenaInput.value = cena.toFixed(2);
            } else {
                cenaInput.value = '';
            }
        }

        function printDiv() {
            var divContents = document.getElementById('<%= divPrint.ClientID %>').innerHTML;
            var printWindow = window.open('', '', 'height=600,width=800');
            printWindow.document.write('<html><head><title>Štampa termina</title></head><body>');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }
    </script>
</body>
</html>
