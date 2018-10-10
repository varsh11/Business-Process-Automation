<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportMain.aspx.cs" Inherits="BPA_Varsh.ReportMain" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <link rel="Stylesheet" href="css/styles.css" type="text/css" />

    <div>
        <br />
        <br />
        <br />
        <br />
    </div>
    <div>
        Generate Reports:

        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Reconcillation Year: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown" ForeColor="Black">
            <asp:ListItem Text="--Select Year--" Value=""></asp:ListItem>
        </asp:DropDownList>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Get all data by Reconcillation Year.</asp:LinkButton>


        <br />
        <br />
        Generate Chart By:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlMonth" runat="server" Width="156px" AutoPostBack="True">
            <asp:ListItem>---Select Category---</asp:ListItem>
            <asp:ListItem Value="RYear">Reconcillation Year</asp:ListItem>
            <asp:ListItem Value="Yr">Year</asp:ListItem>
            <asp:ListItem Value="Domain">Domain</asp:ListItem>
            <asp:ListItem Value="Location1">Location</asp:ListItem>
            <asp:ListItem Value="AccOwner">Account Owner</asp:ListItem>
            <asp:ListItem Value="Segment">Segment</asp:ListItem>
            <asp:ListItem Value="Country">Country</asp:ListItem>
            <asp:ListItem Value="ClientType">Client Type</asp:ListItem>
            <asp:ListItem Value="PartnerName">Partner Name</asp:ListItem>
            <asp:ListItem Value="PrjManager">Project Manager</asp:ListItem>
        </asp:DropDownList>


        <br />
        <br />
        Country:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="name" DataValueField="name">
        </asp:DropDownList>


    </div>
    <div>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Visible="False" AutoGenerateColumns="False" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="RYear" HeaderText="RYear" SortExpression="RYear" />
                <asp:BoundField DataField="Month" HeaderText="Month" SortExpression="Month" />
                <asp:BoundField DataField="Yr" HeaderText="Yr" SortExpression="Yr" />
                <asp:BoundField DataField="RDate" HeaderText="RDate" SortExpression="RDate" />
                <asp:BoundField DataField="Domain" HeaderText="Domain" SortExpression="Domain" />
                <asp:BoundField DataField="Location1" HeaderText="Location1" SortExpression="Location1" />
                <asp:BoundField DataField="Consideration" HeaderText="Consideration" SortExpression="Consideration" />
                <asp:BoundField DataField="PrjCode" HeaderText="PrjCode" SortExpression="PrjCode" />
                <asp:BoundField DataField="MPrjCode1" HeaderText="MPrjCode1" SortExpression="MPrjCode1" />
                <asp:BoundField DataField="MPrjCode2" HeaderText="MPrjCode2" SortExpression="MPrjCode2" />
                <asp:BoundField DataField="PrjCodeSegment" HeaderText="PrjCodeSegment" SortExpression="PrjCodeSegment" />
                <asp:BoundField DataField="AccName" HeaderText="AccName" SortExpression="AccName" />
                <asp:BoundField DataField="AccOwner" HeaderText="AccOwner" SortExpression="AccOwner" />
                <asp:BoundField DataField="Study" HeaderText="Study" SortExpression="Study" />
                <asp:BoundField DataField="Segment" HeaderText="Segment" SortExpression="Segment" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="StudyType" HeaderText="StudyType" SortExpression="StudyType" />
                <asp:BoundField DataField="ClientType" HeaderText="ClientType" SortExpression="ClientType" />
                <asp:BoundField DataField="ClientCountry" HeaderText="ClientCountry" SortExpression="ClientCountry" />
                <asp:BoundField DataField="PartnerName" HeaderText="PartnerName" SortExpression="PartnerName" />
                <asp:BoundField DataField="PartnerCountry" HeaderText="PartnerCountry" SortExpression="PartnerCountry" />
                <asp:BoundField DataField="PrjManager" HeaderText="PrjManager" SortExpression="PrjManager" />
                <asp:BoundField DataField="BTR" HeaderText="BTR" SortExpression="BTR" />
                <asp:BoundField DataField="CCPI" HeaderText="CCPI" SortExpression="CCPI" />
                <asp:BoundField DataField="PCPI" HeaderText="PCPI" SortExpression="PCPI" />
                <asp:BoundField DataField="PlannedRes" HeaderText="PlannedRes" SortExpression="PlannedRes" />
                <asp:BoundField DataField="Target" HeaderText="Target" SortExpression="Target" />
                <asp:BoundField DataField="PlannedRevenue" HeaderText="PlannedRevenue" SortExpression="PlannedRevenue" />
                <asp:BoundField DataField="PlannedCost" HeaderText="PlannedCost" SortExpression="PlannedCost" />
                <asp:BoundField DataField="ActualRes" HeaderText="ActualRes" SortExpression="ActualRes" />
                <asp:BoundField DataField="Absent" HeaderText="Absent" SortExpression="Absent" />
                <asp:BoundField DataField="Achieved" HeaderText="Achieved" SortExpression="Achieved" />
                <asp:BoundField DataField="ActualRevenue" HeaderText="ActualRevenue" SortExpression="ActualRevenue" />
                <asp:BoundField DataField="ActualCost" HeaderText="ActualCost" SortExpression="ActualCost" />
                <asp:BoundField DataField="ActualCostW" HeaderText="ActualCostW" SortExpression="ActualCostW" />
                <asp:BoundField DataField="PlannedRevenueCM" HeaderText="PlannedRevenueCM" SortExpression="PlannedRevenueCM" />
                <asp:BoundField DataField="Location2" HeaderText="Location2" SortExpression="Location2" />
            </Columns>
        </asp:GridView>

        <br />
        <br />
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" XValueMember="Country" YValueMembers="BTR"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT * FROM [fmst] WHERE ([RYear] = @RYear)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="RYear" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT * FROM [fmst] WHERE ([Country] = @Country)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlYear" Name="Country" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [name] FROM [Country]"></asp:SqlDataSource>
</asp:Content>
