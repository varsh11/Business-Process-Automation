using BPA_Varsh.DataSet;
using BPA_Varsh.Reports;
using BPA_Varsh.Reports.ADMIN;
using BPA_Varsh.Reports.EMP;
using BPA_Varsh.Reports.PM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class MNGRRepGen : System.Web.UI.Page
    {string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            string test1="test";
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
                if (String.Compare(ddl2, "P8") == 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = false;
                    tb1.Visible = true;
                    Button1.Visible = true;
                }
                if (String.Compare(ddl2, "P9") == 0)
                {
                    imgPanel.Visible = false;
                    Panel1.Visible = false;
                    ddlR2.Visible = false;
                    ddlPrjCode.Visible = true;
                    test1 = "forP9";
                }
                if ((String.Compare(ddlPrjCode.SelectedValue.ToString(), "FIRST") != 0 ) && (String.Compare(test1,"forP9")==0))
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
                        PM_P9 rpt = new PM_P9();
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
                    test1 = "forA9";
                }
                if ((String.Compare(ddlPrjCode.SelectedValue.ToString(), "FIRST") != 0) && (String.Compare(test1, "forA9") == 0))
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
                if(String.Compare(ddl2,"P8")==0)
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID,SUM(HrsW) as TWrkHrs FROM mstDEntry WHERE EmpID = @EmpID GROUP BY EmpID", con);
                    sda.SelectCommand.Parameters.AddWithValue("@EmpID", tb1.Text.Trim().ToString());
                    EDS2 ds = new EDS2();
                    sda.Fill(ds, "BILLTEST");
                    EMP_TWHrs rpt = new EMP_TWHrs();
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
            tbEmpDet.Text = "";
            tbEmpDet.Visible = false;
            Button2.Visible = false;
        }

        protected void LogOutBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectUser.aspx?f=out");
        }

        protected void lbEmpDetails_Click(object sender, EventArgs e)
        {
            tbEmpDet.Visible = true;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            imgPanel.Visible = false;
            Panel1.Visible = true;
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID,DeptID,Salary,EmpType FROM mstEmp WHERE EmpID = @EmpID", con);
            sda.SelectCommand.Parameters.AddWithValue("@EmpID", tbEmpDet.Text.Trim().ToString());
            DS1 ds = new DS1();
            sda.Fill(ds, "BILLTEST");
            OwnDetails rpt = new OwnDetails();
            rpt.SetDataSource(ds);
            rpt.VerifyDatabase();
            CRV.ReportSource = rpt;
            CRV.RefreshReport();
            con.Close();
        }

        protected void EmpOfWeek_Click(object sender, EventArgs e)
        {
            achPanelWeek.Visible = true;
        }

        protected void EmpOfMonth_Click(object sender, EventArgs e)
        {
            achPanelMonth.Visible = true;
        }
    }
}