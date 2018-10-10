<%@ Page Title="New Entry" Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="EntryMain.aspx.cs" Inherits="BPA_Varsh.EntryMain" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
            <asp:Table ID="Table1" runat="server" CellPadding="6">
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label1" runat="server" Text="Reconcillation Year: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black" CssClass="dropdown" Width="130">
                            <asp:ListItem Text="--Select Year--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <%--for validation if required--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Must Select a Value" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label2" runat="server" Text="Month"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlMonth" runat="server" ForeColor="Black" CssClass="dropdown" Width="100">
                            <asp:ListItem Text="--Month--" Value=""></asp:ListItem>
                            <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                            <asp:ListItem Text="May" Value="May"></asp:ListItem>
                            <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                        </asp:DropDownList>
                        <a></a>
                        <asp:DropDownList ID="ddlYear" runat="server" ForeColor="Black" CssClass="dropdown" Width="90">
                            <asp:ListItem Text="--Year--" Value=""></asp:ListItem>
                        </asp:DropDownList>
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
                        <asp:Label ID="Label4" runat="server" Text="Domain: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlDomain" runat="server" DataSourceID="SqlDataSource2" DataTextField="Domain" DataValueField="Domain" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150">
                            <asp:ListItem Text="--Select Domain--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="addDomainLinkBtn" runat="server" OnClick="addDomainLinkBtn_Click">Add Domain</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TBaddDomain" runat="server" Visible="false"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BaddDomain" runat="server" Text="Add" OnClick="addDomainBtn_Click" Visible="False" />
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label5" runat="server" Text="Location: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlLocation" runat="server" DataSourceID="SqlDataSource3" DataTextField="Location" DataValueField="Location" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150">
                            <asp:ListItem Text="--Select location--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="addLocationLinkBtn" runat="server" OnClick="addLocationLinkBtn_Click">Add Location</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TBaddLocation" runat="server" Visible="false"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BaddLocation" runat="server" Text="Add" OnClick="addLocationBtn_Click" Visible="False" />
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label6" runat="server" Text="Consideration: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label7" runat="server" Text="Project Code: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPrjCode" runat="server" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150px" DataSourceID="SqlDataSource6" DataTextField="PrjID" DataValueField="PrjID" AutoPostBack="True">
                            <asp:ListItem Text="---Select Project Code---" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label35" runat="server" Text="Mapped Project Code 1: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlMPrjCode1" runat="server" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150px" DataSourceID="SqlDataSource6" DataTextField="PrjID" DataValueField="PrjID" AutoPostBack="False">
                            <asp:ListItem Text="---Mapping Project Code1---" Value=""></asp:ListItem>
                            <asp:ListItem Text="Not Mapping to other Projects" Value="No Mapping"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label36" runat="server" Text="Mapped Project Code 2: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlMPrjCode2" runat="server" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150px" DataSourceID="SqlDataSource6" DataTextField="PrjID" DataValueField="PrjID" AutoPostBack="False">
                            <asp:ListItem Text="---Mapping Project Code2---" Value=""></asp:ListItem>
                            <asp:ListItem Text="Not Mapping to other Projects" Value="No Mapping"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label8" runat="server" Text="Project Code#Segment"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblPrjSegment" runat="server" Text="Select Project Code First."></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label9" runat="server" Text="Account Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--Later--%>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label10" runat="server" Text="Account Owner"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--Later--%>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>

                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label11" runat="server" Text="Study: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBStudy" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label12" runat="server" Text="Segment: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBSegment" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label13" runat="server" Text="Country"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlCountry1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150">
                            <asp:ListItem Text="--Select Country--" Value="" />
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label14" runat="server" Text="Study Type: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBStudyType" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label15" runat="server" Text="Client Type: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlClientType" runat="server" DataSourceID="SqlDataSource4" DataTextField="CType" DataValueField="CType" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150">
                            <asp:ListItem Text="--Select Type--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="addClientLinkBtn" runat="server" OnClick="addClientLinkBtn_Click">Add Client Type</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TBaddClientType" runat="server" Visible="false"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BaddClientType" runat="server" Text="Add" OnClick="addClientBtn_Click" Visible="False" />
                        <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label16" runat="server" Text="Origin Country Name of Client: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlCountry2" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150">
                            <asp:ListItem Text="--Select Country--" Value="" />
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label17" runat="server" Text="Project Executed By(Partner Name): "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBPartnerName" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label18" runat="server" Text="Origin Country Name of Partner: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPartnerCountry" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150">
                            <asp:ListItem Text="--Select Country--" Value="" />
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label19" runat="server" Text="Project Manager: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlPrjMngr" runat="server" CssClass="dropdown" Width="150" AppendDataBoundItems="true" DataSourceID="SqlDataSource7" DataTextField="FName" DataValueField="EmpID"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label20" runat="server" Text="Board Target Revenue: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBbtr" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label21" runat="server" Text="Client CPI in USD: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBccpi" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label22" runat="server" Text="Partner CPI in USD: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBpcpi" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label23" runat="server" Text="Planned Resource: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBplannedRes" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label24" runat="server" Text="Target: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration0" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label25" runat="server" Text="Planned Revenue: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration1" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label26" runat="server" Text="Planned Cost: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration2" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label27" runat="server" Text="Actual Resource: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration3" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label28" runat="server" Text="Absent: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration4" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label29" runat="server" Text="Achieved: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration5" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label30" runat="server" Text="Actual Revenue: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration6" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label31" runat="server" Text="Actual cost: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration7" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label32" runat="server" Text="Actual cost(W): "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration8" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label33" runat="server" Text="Planned Revenue - Current Month: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TBConsideration9" runat="server" ForeColor="Black"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                    <%--for validation if required--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="tbsty">
                        <asp:Label ID="Label34" runat="server" Text="Location: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlLoc2" runat="server" DataSourceID="SqlDataSource5" DataTextField="Location" DataValueField="Location" AppendDataBoundItems="true" ForeColor="Black" CssClass="dropdown" Width="150">
                            <asp:ListItem Text="--Select Location--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="addLoc2LinkBtn" runat="server" OnClick="addLoc2LinkBtn_Click">Add Location</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TBaddLoc2" runat="server" Visible="false"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BaddLoc2" runat="server" Text="Add" OnClick="addLoc2Btn_Click" Visible="False" />
                        <%--for validation if required--%>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [name] FROM [Country]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [Domain] FROM [mstDomain]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [Location] FROM [mstLocation]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [CType] FROM [mstClientType]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Test1ConnectionString %>" SelectCommand="SELECT [Location] FROM [Location1]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT [PrjID], [PrjSegment] FROM [mstProjects]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString='<%$ ConnectionStrings:Test1ConnectionString %>' SelectCommand="SELECT [FName], [EmpID] FROM [mstEmp] WHERE (([EmpType] = @EmpType) OR ([EmpType] = @EmpType2))">
            <SelectParameters>
                <asp:Parameter DefaultValue="C1" Name="EmpType"></asp:Parameter>
                <asp:Parameter DefaultValue="C2" Name="EmpType2"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
