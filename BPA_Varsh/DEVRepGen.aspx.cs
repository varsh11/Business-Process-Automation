using BPA_Varsh.DataSet;
using BPA_Varsh.Reports;
using BPA_Varsh.Reports.EMP;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class DEVRepGen : System.Web.UI.Page
    {
        string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";
        string TempEmpId = "Testing";

        protected void Page_Load(object sender, EventArgs e)
        {
            string flg = ddlReportType.SelectedValue.ToString();
            if(Application["Username"]!=null)
            {
                TempEmpId = Application["Username"].ToString();
            }
            if (IsPostBack)
            {
                if (String.Compare(flg, "e1") == 0)
                {
                    Panel1.Visible = true;
                    crsE.Report.FileName = "~/Reports/PrjDetails.rpt";
                    CRV.ReportSource = crsE;
                    CRV.RefreshReport();
                }
                if (String.Compare(flg, "e1") == 0 || String.Compare(flg, "e2") == 0 || String.Compare(flg, "e3") == 0 || String.Compare(flg, "e4") == 0 || String.Compare(flg, "e5") == 0 || String.Compare(flg, "e6") == 0)
                {
                    CloseReportsBTN.Visible = true;
                }
                try
                {
                    Panel1.Visible = true;
                    SqlConnection con = new SqlConnection(connstr);
                    con.Open();
                    if (String.Compare(flg, "e2") == 0)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID,DeptID,Salary,EmpType FROM mstEmp WHERE EmpID = @EmpID", con);
                        sda.SelectCommand.Parameters.AddWithValue("@EmpID", TempEmpId.ToString());
                        DS1 ds = new DS1();
                        sda.Fill(ds, "BILLTEST");
                        OwnDetails rpt = new OwnDetails();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    if (String.Compare(flg, "e3") == 0)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID,SUM(HrsW) as TWrkHrs FROM mstDEntry WHERE EmpID = @EmpID GROUP BY EmpID", con);
                        sda.SelectCommand.Parameters.AddWithValue("@EmpID", TempEmpId);
                        EDS2 ds = new EDS2();
                        sda.Fill(ds, "BILLTEST");
                        EMP_TWHrs rpt = new EMP_TWHrs();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    if (String.Compare(flg, "e4") == 0)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID,SUM(QualityWrk) as TWrkHrs FROM mstDEntry WHERE EmpID = @EmpID GROUP BY EmpID", con);
                        sda.SelectCommand.Parameters.AddWithValue("@EmpID", TempEmpId);
                        EDS2 ds = new EDS2();
                        sda.Fill(ds, "BILLTEST");
                        EMP_QWork rpt = new EMP_QWork();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    if (String.Compare(flg, "e5") == 0)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID FROM mstDEntry WHERE EmpID = @EmpID", con);
                        sda.SelectCommand.Parameters.AddWithValue("@EmpID", TempEmpId);
                        EDS3 ds = new EDS3();
                        sda.Fill(ds, "BILLTEST");
                        EMP_MActive rpt = new EMP_MActive();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    if (String.Compare(flg, "e6") == 0)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT EmpID FROM mstDEntry WHERE EmpID = @EmpID", con);
                        sda.SelectCommand.Parameters.AddWithValue("@EmpID", TempEmpId);
                        EDS3 ds = new EDS3();
                        sda.Fill(ds, "BILLTEST");
                        EMP_NActive rpt = new EMP_NActive();
                        rpt.SetDataSource(ds);
                        rpt.VerifyDatabase();
                        CRV.ReportSource = rpt;
                        CRV.RefreshReport();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }

        protected void CloseReportsBTN_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void LogOutBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectUser.aspx?f=out");
        }
    }
}