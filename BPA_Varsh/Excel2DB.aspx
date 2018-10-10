<%@ Page Title="Excel 2 DataBase" Language="C#" AutoEventWireup="true" CodeBehind="Excel2DB.aspx.cs" Inherits="BPA_Varsh.Excel2DB" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="Stylesheet" href="css/E2DBStyle.css" type="text/css" />
    <div>
        <br />
        <br />
        <br />
        <br />
    </div>

    <div>

        <asp:Label ID="Label1" runat="server" Text="Excel To Database" Font-Bold="True" Font-Size="XX-Large" ForeColor="#000066"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    </div>
    <div class="form-style-7">
            <ul>
                <li>
                    <label for="name">Path to .xls file</label>
<asp:TextBox ID="tbFilePath" runat="server" Width="100%"></asp:TextBox>
                    <span>Use *.xls file. Insert '/'/ escape sequence to path</span>
                </li>
                <li>
                    <label for="email">Worksheet Name</label>
<asp:TextBox ID="tbWrkSheetName" runat="server" CssClass="tbNew" Width="100%"></asp:TextBox>
                    <span>Enter the worskeet name from excel file</span>
                </li>
                <li>
                    <label for="url">Database Table to Store</label>
<asp:TextBox ID="tbDBName" runat="server" Width="100%"></asp:TextBox>
                    <span>Create DB first with same header row as attributes</span>
                </li>
                <li>
        <asp:Button ID="btnUpload" runat="server" Text="Execute" OnClick="btnUpload_Click" />
                </li>
            </ul>
    </div>
</asp:Content>
