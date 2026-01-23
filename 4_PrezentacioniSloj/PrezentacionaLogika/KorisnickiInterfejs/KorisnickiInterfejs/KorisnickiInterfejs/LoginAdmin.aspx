<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="KorisnickiInterfejs.LoginAdmin" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Prijava - Administrator</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        .login-container {
            background: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
            width: 350px;
        }
        h2 {
            color: #f44336;
            text-align: center;
            margin-bottom: 30px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            color: #555;
            font-weight: bold;
        }
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .btn {
            width: 100%;
            padding: 12px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin-bottom: 10px;
        }
        .btn-primary {
            background-color: #f44336;
            color: white;
        }
        .btn-primary:hover {
            background-color: #da190b;
        }
        .btn-secondary {
            background-color: #999;
            color: white;
        }
        .btn-secondary:hover {
            background-color: #777;
        }
        .error {
            color: red;
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Prijava - Administrator</h2>
            
            <label>Korisničko ime:</label>
            <asp:TextBox ID="txtKorisnickoIme" runat="server"></asp:TextBox>
            
            <label>Šifra:</label>
            <asp:TextBox ID="txtSifra" runat="server" TextMode="Password"></asp:TextBox>
            
            <asp:Button ID="btnPrijaviSe" runat="server" Text="Prijavi se" 
                CssClass="btn btn-primary" OnClick="btnPrijaviSe_Click" />
            
            <asp:Button ID="btnNazad" runat="server" Text="Nazad" 
                CssClass="btn btn-secondary" OnClick="btnNazad_Click" CausesValidation="false" />
            
            <asp:Label ID="lblStatus" runat="server" CssClass="error"></asp:Label>
        </div>
    </form>
</body>
</html>