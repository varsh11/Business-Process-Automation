<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ADMINRepGen.aspx.cs" Inherits="BPA_Varsh.ADMINRepGen" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <link rel="Stylesheet" href="css/styles.css" type="text/css" />

    <div>
        <br />
        <br />
        <br />
        <br />
    </div>
    <div>
            <asp:Button ID="LogOutBTN" runat="server" Text="Log Out" OnClick="LogOutBTN_Click" CssClass="buttonC" style="float:right" />
        </div>
    <div>
         <asp:Label ID="Label1" runat="server" Text="Choose report type: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlR1" runat="server" CssClass="dropdown" AutoPostBack="True" Width="90">
            <asp:ListItem Text="---Select Type---" Value=""></asp:ListItem>
            <asp:ListItem Text="Total Profit by" Value="D1"></asp:ListItem>
            <asp:ListItem Text="Efficiency by" Value="D2"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlR2" runat="server" CssClass="dropdown" AutoPostBack="true" Visible="false" Width="90" >
            <asp:ListItem Text="---Select Type--" Value=""></asp:ListItem>
            <asp:ListItem Text="Financial year" Value="A1"></asp:ListItem>
            <asp:ListItem Text="Project Id" Value="A2"></asp:ListItem>
            <asp:ListItem Text="Project Manager" Value="A3"></asp:ListItem>
            <asp:ListItem Text="Location" Value="A4"></asp:ListItem>
            <asp:ListItem Text="Partner Name" Value="A5"></asp:ListItem>
            <asp:ListItem Text="Domain" Value="A6"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlR3" runat="server" CssClass="dropdown" AutoPostBack="true" Visible="false" Width="90" >
            <asp:ListItem Text="---Select Type--" Value=""></asp:ListItem>
            <asp:ListItem Text="Departments" Value="A7"></asp:ListItem>
            <asp:ListItem Text="Type of work" Value="A8"></asp:ListItem>
            <asp:ListItem Text="Project Id" Value="A9"></asp:ListItem>
            <asp:ListItem Text="Employee Id" Value="A10"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPrjCode" runat="server" Visible="false" CssClass="dropdown" AutoPostBack="true" Width="150px" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="PrjCode" DataValueField="PrjCode">
            <asp:ListItem Text="---Select Project---" Value="FIRST"></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT [PrjCode] FROM [fmst]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:TextBox ID="tb1" runat="server" Visible="false"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="OK!" Visible="false" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:LinkButton ID="lbAllPrjDetails" runat="server" OnClick="lbAllPrjDetails_Click">View all Project Details</asp:LinkButton>
        <br />
    </div>
    <div>
        <asp:Panel ID="imgPanel" runat="server" Visible="false">
            <asp:Image ID="Image1" runat="server" ImageAlign="Middle" />
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" Height="1202px" ToolPanelWidth="200px" Width="1104px" ToolPanelView="None" />

            <CR:CrystalReportSource ID="crsE" runat="server"></CR:CrystalReportSource>
            <br />
            <br />
            <div style="align-content:center">
                            <asp:Button ID="CloseReportsBTN" runat="server" Text="Close Reports" CssClass="buttonC" Visible="true" OnClick="CloseReportsBTN_Click" />

            </div>

        </asp:Panel>
        
    </div>
</asp:Content>
