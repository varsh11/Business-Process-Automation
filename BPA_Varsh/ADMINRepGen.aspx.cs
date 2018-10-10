using BPA_Varsh.DataSet;
using BPA_Varsh.Reports.ADMIN;
using BPA_Varsh.Reports.EMP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class ADMINRepGen : System.Web.UI.Page
    {
        string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(IsPostBack)
            {
                string ddl1 = ddlR1.SelectedValue.ToString();
                string ddl2 = ddlR2.SelectedValue.ToString();
                string ddl3 = ddlR3.SelectedValue.ToString();
                if(String.Compare(ddl1,"D1")==0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = false;
                    ddlR2.Visible = true;
                    ddlR3.Visible = false;
                }
                if(String.Compare(ddl1,"D2")==0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = false;
                    ddlR2.Visible = false;
                    ddlR3.Visible = true;
                }
                if (String.Compare(ddl2, "A1") == 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = true;
                    CloseReportsBTN.Visible = true;
                    try
                    {
                        SqlConnection con = new SqlConnection(connstr);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT RYear, SUM (ActualRevenue) as Profit FROM fmst GROUP BY RYear;", con);
                        ADS1 ds = new ADS1();
                        sda.Fill(ds, "BILLTEST");
                        ADMIN_A1 rpt = new ADMIN_A1();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    catch(Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                if (String.Compare(ddl2, "A2") == 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = true;
                    CloseReportsBTN.Visible = true;
                    try
                    {
                        SqlConnection con = new SqlConnection(connstr);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT PrjCode, ActualRevenue as Profit FROM fmst;", con);
                        ADS2 ds = new ADS2();
                        sda.Fill(ds, "BILLTEST");
                        ADMIN_A2 rpt = new ADMIN_A2();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                if (String.Compare(ddl2, "A3") == 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = true;
                    CloseReportsBTN.Visible = true;
                    try
                    {
                        SqlConnection con = new SqlConnection(connstr);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT PrjManager as PrjMngr, SUM (ActualRevenue) as Profit FROM fmst GROUP BY PrjManager;", con);
                        ADS3 ds = new ADS3();
                        sda.Fill(ds, "BILLTEST");
                        ADMIN_A3 rpt = new ADMIN_A3();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                if (String.Compare(ddl2, "A4") == 0)
                {
                    Image1.ImageUrl = "~/images/PbyLoc.PNG";
                    imgPanel.Visible = true;
                }
                if (String.Compare(ddl2, "A5") == 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = true;
                    CloseReportsBTN.Visible = true;
                    try
                    {
                        SqlConnection con = new SqlConnection(connstr);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT PartnerName as PName, SUM (ActualRevenue) as Profit FROM fmst GROUP BY PartnerName;", con);
                        ADS5 ds = new ADS5();
                        sda.Fill(ds, "BILLTEST");
                        ADMIN_A5 rpt = new ADMIN_A5();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                if (String.Compare(ddl2, "A6") == 0)
                {
                    Panel1.Visible = false;
                    Image1.ImageUrl = "~/images/PbyDomain.PNG";
                    imgPanel.Visible = true;
                }
                if (String.Compare(ddl3, "A7") == 0)
                {
                    Panel1.Visible = false;
                    Image1.ImageUrl = "~/images/EbyDeptID.PNG";
                    imgPanel.Visible = true;
                }
                if (String.Compare(ddl3, "A8") == 0)
                {
                    Panel1.Visible = false;
                    Image1.ImageUrl = "~/images/EbyTypeWrk.PNG";
                    imgPanel.Visible = true;
                }
                if (String.Compare(ddl3, "A9") == 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = false;
                    ddlR2.Visible = false;
                    ddlPrjCode.Visible = true;
                }
                if (String.Compare(ddlPrjCode.SelectedValue.ToString(), "FIRST") != 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = true;
                    CloseReportsBTN.Visible = true;
                    try
                    {
                        SqlConnection con = new SqlConnection(connstr);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT PrjCode, ActualRevenue as Profit FROM fmst WHERE PrjCode = @PrjCode", con);
                        sda.SelectCommand.Parameters.AddWithValue("@PrjCode", ddlPrjCode.SelectedValue.ToString());
                        ADS2 ds = new ADS2();
                        sda.Fill(ds, "BILLTEST");
                        ADMIN_A9 rpt = new ADMIN_A9();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
                if (String.Compare(ddl3, "A10") == 0)
                {
                    Panel1.Visible = false;
                    imgPanel.Visible = false;
                    tb1.Visible = true;
                    Button1.Visible = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ddl1 = ddlR1.SelectedIndex.ToString();
                string ddl2 = ddlR2.SelectedValue.ToString();
                string ddl3 = ddlR3.SelectedValue.ToString();
                Panel1.Visible = true;
                Image1.Visible = false;
                SqlConnection con = new SqlConnection(connstr);
                con.Open();
                if (String.Compare(ddl3, "A10") == 0)
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID,SUM(QualityWrk) as TWrkHrs FROM mstDEntry WHERE EmpID = @EmpID GROUP BY EmpID", con);
                    sda.SelectCommand.Parameters.AddWithValue("@EmpID", tb1.Text.Trim().ToString());
                    EDS2 ds = new EDS2();
                    sda.Fill(ds, "BILLTEST");
                    EMP_QWork rpt = new EMP_QWork();
                    rpt.SetDataSource(ds);
                    rpt.VerifyDatabase();
                    CRV.ReportSource = rpt;
                    CRV.RefreshReport();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void lbAllPrjDetails_Click(object sender, EventArgs e)
        {
            Image1.Visible = false;
            Panel1.Visible = true;
            crsE.Report.FileName = "~/Reports/PrjDetails.rpt";
            CRV.ReportSource = crsE;
            CRV.RefreshReport();
        }

        protected void CloseReportsBTN_Click(object sender, EventArgs e)
        {
            imgPanel.Visible = false;
            ddlR1.ClearSelection();
            ddlR2.ClearSelection();
            ddlR3.ClearSelection();
            ddlPrjCode.ClearSelection();
            ddlPrjCode.Visible = false;
            Panel1.Visible = false;
            tb1.Text = "";
            tb1.Visible = false;
            Button1.Visible = false;
        }

        protected void LogOutBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectUser.aspx?f=out");
        }
    }
}