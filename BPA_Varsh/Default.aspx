<%@ Page Title="Business Process Automation (BPA)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BPA_Varsh._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/SliderScript.js" language="javascript" type="text/javascript"></script>
    <link rel="Stylesheet" href="css/Slider.css" type="text/css" />
    <div class="slidercontainer">
        <div class="showSlide">
            <img src="images/Banner/Banner1.png" />
        </div>
        <div class="showSlide">
            <img src="images/Banner/Banner2.png" />
        </div>
        <div class="showSlide">
            <img src="images/Banner/Banner3.png" />
        </div>
        <div class="showSlide">
            <img src="images/Banner/Banner4.png" />
        </div>
        <div class="showSlide">
            <img src="images/Banner/Banner5.png" />
        </div>
        <div class="showSlide">
            <img src="images/Banner/Banner6.png" />
        </div>
        <!-- Navigation arrows -->
        <a class="left" onclick="nextSlide(-1)"><</a>
        <a class="right" onclick="nextSlide(1)">></a>
    </div>

    <br />
    <br />
    <br />
    <br />

    <div class="glass" style="align-content:center; align-items:center;align-self:center">
        <div align="center">
            <asp:Button CssClass="button" ID="Button3" runat="server" Text="Enter Daily Entry" OnClick="dailyEntryBtn_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button CssClass="button" ID="newEntryBtn" runat="server" Text="Create New Entry" OnClick="newEntryBtn_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button CssClass="button" ID="Button2" runat="server" Text="Generate Reports" OnClick="genReportBtn_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="Go To SMS Portal" OnClick="genReportBtn_Click" />
        </div>
    </div>

</asp:Content>
