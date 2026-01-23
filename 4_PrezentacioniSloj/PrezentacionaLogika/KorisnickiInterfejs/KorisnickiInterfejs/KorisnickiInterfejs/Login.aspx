<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KorisnickiInterfejs.LoginPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Izbor prijave</title>
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
        .container {
            background: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
            text-align: center;
        }
        h2 {
            color: #333;
            margin-bottom: 30px;
        }
        .btn-container {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }
        .login-btn {
            padding: 15px 30px;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: all 0.3s;
        }
        .btn-korisnik {
            background-color: #4CAF50;
            color: white;
        }
        .btn-korisnik:hover {
            background-color: #45a049;
        }
        .btn-trener {
            background-color: #2196F3;
            color: white;
        }
        .btn-trener:hover {
            background-color: #0b7dda;
        }
        .btn-admin {
            background-color: #f44336;
            color: white;
        }
        .btn-admin:hover {
            background-color: #da190b;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Izaberite tip prijave</h2>
            <div class="btn-container">
                <asp:Button ID="btnKorisnik" runat="server" Text="Prijava kao Korisnik" 
                    CssClass="login-btn btn-korisnik" OnClick="btnKorisnik_Click" />
                
                <asp:Button ID="btnTrener" runat="server" Text="Prijava kao Trener" 
                    CssClass="login-btn btn-trener" OnClick="btnTrener_Click" />
                
                <asp:Button ID="btnAdmin" runat="server" Text="Prijava kao Admin" 
                    CssClass="login-btn btn-admin" OnClick="btnAdmin_Click" />
            </div>
        </div>
    </form>
</body>
</html>