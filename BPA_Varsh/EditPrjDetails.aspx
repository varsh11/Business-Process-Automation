<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPrjDetails.aspx.cs" Inherits="BPA_Varsh.EditPrjDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" style="background-color: #E1FEFB">
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

        <asp:Label ID="Label1" runat="server" Text="Project ID: " Font-Bold="True" Font-Size="Large"></asp:Label>
        <asp:DropDownList ID="DropDownList1" CssClass="dropdown" Width="150" runat="server" DataSourceID="PrjIDsqldatasource" DataTextField="PrjID" DataValueField="PrjID" AutoPostBack="True" AppendDataBoundItems="true">
            <asp:ListItem Text="---Select ID---" Value=""></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PrjID" DataSourceID="SqlDataSourceGridView" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="10">
            <Columns>
                <asp:BoundField DataField="PrjID" HeaderText="PrjID" ReadOnly="True" SortExpression="PrjID"></asp:BoundField>
                <asp:BoundField DataField="PrjName" HeaderText="PrjName" SortExpression="PrjName"></asp:BoundField>
                <asp:BoundField DataField="PrjSegment" HeaderText="PrjSegment" SortExpression="PrjSegment"></asp:BoundField>
                <asp:BoundField DataField="PrjStrength" HeaderText="PrjStrength" SortExpression="PrjStrength"></asp:BoundField>
                <asp:BoundField DataField="PrjMngr" HeaderText="PrjMngr" SortExpression="PrjMngr"></asp:BoundField>
                <asp:BoundField DataField="PrjCountry" HeaderText="PrjCountry" SortExpression="PrjCountry"></asp:BoundField>
                <asp:BoundField DataField="SDate" HeaderText="SDate" SortExpression="SDate"></asp:BoundField>
                <asp:BoundField DataField="EDate" HeaderText="EDate" SortExpression="EDate"></asp:BoundField>
                <asp:BoundField DataField="PName" HeaderText="PName" SortExpression="PName"></asp:BoundField>
                <asp:BoundField DataField="PCountry" HeaderText="PCountry" SortExpression="PCountry"></asp:BoundField>
                <asp:BoundField DataField="Location2" HeaderText="Location2" SortExpression="Location2"></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" Font-Italic="True" Font-Names="Adobe Kaiti Std R" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Large"></HeaderStyle>

            <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" VerticalAlign="Middle"></RowStyle>

            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
        </asp:GridView>
        <asp:SqlDataSource ID="PrjIDsqldatasource" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT [PrjID] FROM [mstProjects]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceGridView" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT * FROM [mstProjects] WHERE ([PrjID] = @PrjID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="PrjID" Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <asp:LinkButton ID="EditPrjlb" runat="server" Visible="false" OnClick="EditPrjlb_Click">Edit Project Details</asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <asp:Label ID="Label2" runat="server" Text="Select all the items you want to edit."></asp:Label>
            <br />
            <asp:CheckBox ID="cbPrjStrength" runat="server" Text="Project Strength" AutoPostBack="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbPrjStrength" runat="server" Visible="false"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPrjStrength" runat="server" Text="Update" Visible="false" OnClick="btnPrjStrength_Click" />
            <br />
            <asp:CheckBox ID="cbPrjMngr" runat="server" Text="Project Manager" AutoPostBack="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPrjMngr" runat="server" Visible="false" AppendDataBoundItems="true" CssClass="dropdown" Width="150px" DataSourceID="dqldsPrjMngr" DataTextField="FName" DataValueField="EmpID">
                <asp:ListItem Text="---Project Manager---"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPrjMngr" runat="server" Text="Update" Visible="false" OnClick="btnPrjMngr_Click" />
            <br />
            <asp:CheckBox ID="cbPrjCountry" runat="server" Text="Project Country" AutoPostBack="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPrjCountry" runat="server" Visible="false" AppendDataBoundItems="true" CssClass="dropdown" Width="150px" DataSourceID="sqldsCountry" DataTextField="name" DataValueField="name">
                <asp:ListItem Text="---Project Country---"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPrjCountry" runat="server" Text="Update" Visible="false" OnClick="btnPrjCountry_Click" />
            <br />
            <asp:CheckBox ID="cbEDate" runat="server" Text="End Date" AutoPostBack="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbEDate" runat="server" Visible="false"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEDate" runat="server" Text="Update" Visible="false" OnClick="btnEDate_Click" />
            <br />
            <asp:CheckBox ID="cbPName" runat="server" Text="Partner Name" AutoPostBack="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbPName" runat="server" Visible="false"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPName" runat="server" Text="Update" Visible="false" OnClick="btnPName_Click" />
            <br />
            <asp:CheckBox ID="cbPCountry" runat="server" Text="Partner Country" AutoPostBack="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPCountry" runat="server" Visible="false" AppendDataBoundItems="true" CssClass="dropdown" Width="150px" DataSourceID="sqldsCountry" DataTextField="name" DataValueField="name">
                <asp:ListItem Text="---Partner Country---"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPcountry" runat="server" Text="Update" Visible="false" OnClick="btnPcountry_Click" />
            <br />
            <asp:CheckBox ID="cbLocation2" runat="server" Text="Location" AutoPostBack="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocation2" runat="server" Visible="false" AppendDataBoundItems="true" CssClass="dropdown" Width="150px" DataSourceID="sqldsLocation2" DataTextField="Location" DataValueField="Location">
                <asp:ListItem Text="---Location---"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLocation2" runat="server" Text="Update" Visible="false" OnClick="btnLocation2_Click" />
            <br />
            <br />
            <asp:SqlDataSource ID="sqldsCountry" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT [name] FROM [Country]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="sqldsLocation2" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT [Location] FROM [Location1]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dqldsPrjMngr" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [FName],[EmpID] FROM [mstEmp] WHERE (([EmpType] = @EmpType) OR ([EmpType] = @EmpType2))">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="C1" DefaultValue="C1" Name="EmpType" Type="String"></asp:QueryStringParameter>
                    <asp:QueryStringParameter QueryStringField="C2" DefaultValue="C2" Name="EmpType2" Type="String"></asp:QueryStringParameter>
                </SelectParameters>
            </asp:SqlDataSource>
            <div align="center">
                            <asp:Button ID="btnDone" runat="server" Text="Done Edits" CssClass="buttonS" OnClick="btnDone_Click" />
                        </div>
        </asp:PlaceHolder>
        
    </div>

</asp:Content>
