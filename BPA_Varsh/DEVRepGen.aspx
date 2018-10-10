<%@ Page Title="Developer Report Generation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DEVRepGen.aspx.cs" Inherits="BPA_Varsh.DEVRepGen" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="Stylesheet" href="css/styles.css" type="text/css" />
    <div>
        <br />
        <br />
        <br />
        <br />
        <div>
            <asp:Button ID="LogOutBTN" runat="server" Text="Log Out" OnClick="LogOutBTN_Click" CssClass="buttonC" style="float:right" />
        </div>
        
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Choose report type: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlReportType" runat="server" AutoPostBack="True" CssClass="dropdown">
            <asp:ListItem Text="---Select Type---" Value=""></asp:ListItem>
            <asp:ListItem Text="Project Details" Value="e1"></asp:ListItem>
            <asp:ListItem Text="Personal Details" Value="e2"></asp:ListItem>
            <asp:ListItem Text="Working Hours" Value="e3"></asp:ListItem>
            <asp:ListItem Text="Efficiency Report" Value="e4"></asp:ListItem>
            <asp:ListItem Text="Most Active Day" Value="e5"></asp:ListItem>
            <asp:ListItem Text="Most Lazy Day" Value="e6"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" Height="1202px" ToolPanelWidth="200px" Width="1104px" ToolPanelView="None" />

            <CR:CrystalReportSource runat="server" ID="crsE">
            </CR:CrystalReportSource>
            <br />
            <br />
            <asp:Button ID="CloseReportsBTN" runat="server" Text="Close Reports" CssClass="buttonC" Visible="false" OnClick="CloseReportsBTN_Click" />

        </asp:Panel>
    </div>
</asp:Content>
