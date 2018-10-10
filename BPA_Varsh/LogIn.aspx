<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BPA_Varsh.LogIn" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="Stylesheet" href="css/Login.css" type="text/css" />
    <link rel="Stylesheet" href="css/styles.css" type="text/css" />
    <div>
        <br />
        <br />
        <br />
        <br />
    </div>
    <div class="login">
        <br />
        <asp:TextBox ID="tbID" runat="server" placeholder="Azure ID" CssClass="login"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbPass" runat="server" placeholder="Password" CssClass="login" TextMode="Password"></asp:TextBox>
        <br /> 
        <asp:LinkButton ID="lbFrgtPass" runat="server" CssClass="forgot" OnClick="lbFrgtPass_Click" >Forgot password?</asp:LinkButton>
        <asp:Button ID="btnLogIn" runat="server" Text="Log In" CssClass="buttonS" OnClick="btnLogIn_Click" />
</div>
</asp:Content>
