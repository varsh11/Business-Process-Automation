<%@ Page Title="New Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProjectDetails.aspx.cs" Inherits="BPA_Varsh.NewProjectDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #E1FEFB">
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script src="Scripts/scripts.js" language="javascript" type="text/javascript"></script>
        <link rel="Stylesheet" href="css/styles.css" type="text/css" />
        <div>
        <br />
        <br />
        <br />
        <br />
    </div>
        <div>
            <asp:Table ID="Table1" runat="server" CellPadding="6" CellSpacing="0">
                
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label35" runat="server" Text="Project ID: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="AZ001"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label10" runat="server" Text="_"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="tbPrjID1" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="Label11" runat="server" Text="_"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="tbPrjID2" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label1" runat="server" Text="Project Name: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbPrjName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label12" runat="server" Text="Project Code Segment: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbPrjSegment" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label2" runat="server" Text="Project Strength: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbPrjStrength" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label4" runat="server" Text="Project Manager: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPrjMngr" runat="server" AppendDataBoundItems="true" CssClass ="dropdown" Width="150" DataSourceID="SqlDataSource2" DataTextField="FName" DataValueField="EmpID">
                            <asp:ListItem Text="--Select Manager--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label3" runat="server" Text="Start Date: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlDay1" runat="server" CssClass="dropdown" Width="90">
                            <asp:ListItem Text="--Day--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlMonth1" runat="server" AutoPostBack="False" CssClass ="dropdown" Width="100">
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
                        <asp:Label ID="Label5" runat="server" Text="Approx. End Date: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlDay2" runat="server" CssClass="dropdown" Width="90">
                            <asp:ListItem Text="--Day--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlMonth2" runat="server" AutoPostBack="False" CssClass ="dropdown" Width="100">
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
                        <asp:DropDownList ID="ddlYear2" runat="server" CssClass="dropdown" Width="90">
                            <asp:ListItem Text="--Year--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label41" runat="server" Text="Partner Name: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbPName" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label6" runat="server" Text="Partner Country: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPCountry" runat="server" AppendDataBoundItems="true" CssClass ="dropdown" Width="150" DataSourceID="SqlDataSource3" DataTextField="name" DataValueField="name">
                            <asp:ListItem Text="--Select Country--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label7" runat="server" Text="Project Country: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPrjCountry" runat="server" AppendDataBoundItems="true" CssClass ="dropdown" Width="150" DataSourceID="SqlDataSource3" DataTextField="name" DataValueField="name">
                            <asp:ListItem Text="--Select Country--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label8" runat="server" Text="Project Location: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlLoc2" runat="server" AppendDataBoundItems="true" CssClass ="dropdown" Width="150" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="Location">
                            <asp:ListItem Text="--Select Location--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                        <asp:LinkButton ID="addLoc2LinkBtn" runat="server" OnClick="addLoc2LinkBtn_Click">Add Location</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TBaddLoc2" runat="server" Visible="false"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BaddLoc2" runat="server" Text="Add" OnClick="addLoc2Btn_Click" Visible="False" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT [Location] FROM [Location1]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [FName],[EmpID] FROM [mstEmp] WHERE (([EmpType] = @EmpType) OR ([EmpType] = @EmpType2))">
            <SelectParameters>
                <asp:QueryStringParameter QueryStringField="C1" DefaultValue="C1" Name="EmpType" Type="String"></asp:QueryStringParameter>
                <asp:QueryStringParameter QueryStringField="C2" DefaultValue="C2" Name="EmpType2" Type="String"></asp:QueryStringParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [name] FROM [Country]"></asp:SqlDataSource>
        </div>
</asp:Content>
