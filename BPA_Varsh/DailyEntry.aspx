<%@ Page Title="Daily Entry" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyEntry.aspx.cs" Inherits="BPA_Varsh.DailyEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
    </div>
    <div style="background-color: #E1FEFB">
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script src="Scripts/scripts.js" language="javascript" type="text/javascript"></script>
        <link rel="Stylesheet" href="css/styles.css" type="text/css" />

        <div>
            <asp:Table ID="Table1" runat="server" CellPadding="6" CellSpacing="0">
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label2" runat="server" Text="Employee ID: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Text="AZ_EMP_000"></asp:Label>
                        <asp:TextBox ID="tbEmpID" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label1" runat="server" Text="Department ID: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblDeptID" runat="server" Text="" Visible="false"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                        <asp:LinkButton ID="getDeptIDlnkbtn" runat="server" OnClick="getDeptIDlnkbtn_Click">Get Department ID</asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label35" runat="server" Text="Project ID: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPrjID" runat="server" CssClass="dropdown" Width="100" DataSourceID="SqlDataSource3" DataTextField="PrjID" DataValueField="PrjID"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                        <asp:LinkButton ID="lbtnNewProject" runat="server" OnClick="lbtnNewProject_Click">Add New Project</asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label36" runat="server" Text="Type of Work: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlTWrk" runat="server" CssClass="dropdown" Width="100">
                            <asp:ListItem Text="---Select Type---"></asp:ListItem>
                            <asp:ListItem Text="Software" Value="Software"></asp:ListItem>
                            <asp:ListItem Text="Hardware" Value="Hardware"></asp:ListItem>
                            <asp:ListItem Text="Survey" Value="Survey"></asp:ListItem>
                            <asp:ListItem Text="Call Center" Value="Call Center"></asp:ListItem>
                            <asp:ListItem Text="Development" Value="Development"></asp:ListItem>
                            <asp:ListItem Text="Android Dept" Value="Android Dept"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label37" runat="server" Text="Quality of Work: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbQWrk" runat="server" ForeColor="Black" TextMode="Number"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label38" runat="server" Text="Hours of Work: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbHrsW" runat="server" ForeColor="Black" TextMode="Number"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label39" runat="server" Text="Hours in Office: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbHrsO" runat="server" ForeColor="Black" TextMode="Number"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label3" runat="server" Text="Date: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlDay1" runat="server" CssClass="dropdown" Width="90">
                            <asp:ListItem Text="--Day--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlMonth1" runat="server" AutoPostBack="False" CssClass="dropdown" Width="100">
                            <asp:ListItem Text="--Month--" Value=""></asp:ListItem>
                            <asp:ListItem Text="January" Value="01"></asp:ListItem>
                            <asp:ListItem Text="February" Value="02"></asp:ListItem>
                            <asp:ListItem Text="March" Value="03"></asp:ListItem>
                            <asp:ListItem Text="April" Value="04"></asp:ListItem>
                            <asp:ListItem Text="May" Value="05"></asp:ListItem>
                            <asp:ListItem Text="June" Value="06"></asp:ListItem>
                            <asp:ListItem Text="July" Value="07"></asp:ListItem>
                            <asp:ListItem Text="August" Value="08"></asp:ListItem>
                            <asp:ListItem Text="September" Value="09"></asp:ListItem>
                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlYear1" runat="server" CssClass="dropdown" Width="90">
                            <asp:ListItem Text="--Year--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label40" runat="server" Text="Day: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlDay" runat="server" CssClass="dropdown" Width="100">
                            <asp:ListItem Text="---Select Day---"></asp:ListItem>
                            <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                            <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                            <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                            <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                            <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                            <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                            <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label41" runat="server" Text="Time Stamp: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbTStamp" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                        <asp:LinkButton ID="lbtnUTime" runat="server" OnClick="lbtnUTime_Click">Update Time</asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3">
                        <div align="center">
                            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="buttonS" OnClick="SubmitButton_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="buttonC" OnClick="CancelButton_Click" />
                        </div>
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
        <div class="loading" align="center">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Ellipsis.gif" />
        </div>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [EmpID] FROM [mstEmp]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [PrjID] FROM [mstProjects]"></asp:SqlDataSource>
    </div>
</asp:Content>
