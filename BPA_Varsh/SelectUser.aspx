<%@ Page Title="Select User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectUser.aspx.cs" Inherits="BPA_Varsh.SelectUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
    </div>
    <div>
        <link rel="Stylesheet" href="css/styles.css" type="text/css" />
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" CellPadding="35">
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="3">
                    <div style="align-content: center">
                        <asp:Label ID="Label1" runat="server" Text="Select the type of login" CssClass="headings1"></asp:Label>
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ID="ibAdminLogin" runat="server" ImageUrl="~/images/AdminLogin.png" ImageAlign="Middle" OnClick="ibAdminLogin_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ID="ibPrjMngrLogin" runat="server" ImageUrl="~/images/PrjMngrLogin.png" ImageAlign="Middle" OnClick="ibPrjMngrLogin_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ID="ibDeveloperLogin" runat="server" ImageUrl="~/images/DeveloperLogin.png" ImageAlign="Middle" OnClick="ibDeveloperLogin_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                        <p>
                            Admin
                        </p>
                </asp:TableCell>
                <asp:TableCell>
                        <p>
                            Project Manager
                        </p>
                </asp:TableCell>
                <asp:TableCell>
                        <p>
                            Employee
                        </p>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </div>

</asp:Content>
