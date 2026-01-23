<%@ Page Title="Početna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="KorisnickiInterfejs._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        body {
            background-color: #000000;
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', sans-serif;
        }

        .hero-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 85vh;
            text-align: center;
            background-color: #000000;
            color: white;
        }

        .hero-box {
            max-width: 800px;
            padding: 40px;
            border-radius: 10px;
            animation: fadeInUp 1s ease-in-out;
        }

        .hero-box h1 {
            font-size: 48px;
            font-weight: bold;
            color: #ffffff;
            margin-bottom: 20px;
        }

        .hero-box p {
            font-size: 20px;
            color: #cccccc;
            margin-bottom: 30px;
        }

        .status-label {
            background-color: #ffffff;
            color: #000000;
            padding: 10px 25px;
            border-radius: 25px;
            font-weight: bold;
            display: inline-block;
            box-shadow: 0px 4px 12px rgba(255, 255, 255, 0.1);
        }

        @keyframes fadeInUp {
            from {
                opacity: 0;
                transform: translateY(40px);
            }
            to {
                opacity: 1;
                transform: translateY(0);
            }
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="hero-container">
        <div class="hero-box">
            <h1><strong>Dobrodošli u sistem Veštačkog planinarenja</strong></h1>
            <p>Upravljajte svojim nalogom, pratite termine i povežite se sa trenerima brzo i lako.</p>
            <asp:Label ID="lblStatusKonekcije" runat="server" CssClass="status-label" Text="Status konekcije: " />
        </div>
    </div>
</asp:Content>
