using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class DailyEntry : System.Web.UI.Page
    {
        string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";

        public NewProjectDetails NewProjectDetails1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            string cTime = DateTime.Now.ToString("HH:mm:ss");
            tbTStamp.Text = cTime;
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                var currentYear = DateTime.Today.Year;
                var count = 1;
                for (int i = currentYear; i >= currentYear - 20; i--)
                {
                    ddlYear1.Items.Add(i.ToString());
                }
                for (int i = 1; i <= 31; i++)
                {
                    if (i < 10)
                    {
                        ddlDay1.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        ddlDay1.Items.Add(i.ToString());
                    }
                }
            }
        }
        public static void ClearFields(ControlCollection pageControls)
        {
            foreach (Control contl in pageControls)
            {
                string strCntName = (contl.GetType()).Name;

                switch (strCntName)
                {
                    case "TextBox":
                        TextBox tbSource = (TextBox)contl;
                        tbSource.Text = "";
                        break;
                    case "RadioButtonList":
                        RadioButtonList rblSource = (RadioButtonList)contl;
                        rblSource.SelectedIndex = -1;
                        break;
                    case "DropDownList":
                        DropDownList ddlSource = (DropDownList)contl;
                        ddlSource.SelectedIndex = -1;
                        break;
                    case "ListBox":
                        ListBox lbsource = (ListBox)contl;
                        lbsource.SelectedIndex = -1;
                        break;
                    case "Calendar":
                        Calendar cdsource = (Calendar)contl;
                        cdsource.SelectedDates.Clear();
                        break;
                }
                ClearFields(contl.Controls);
            }
        }
        protected void insertLog(string exSTR)
        {
            FileInfo fi = new FileInfo("C:\\Users\\Varsh Patel\\Documents\\Visual Studio 2013\\Projects\\BPA_Varsh\\BPA_Varsh\\logs.txt");

            using (StreamWriter sw = fi.AppendText())
            {
                string cTime = DateTime.Now.ToString("HH:mm:ss");
                string cDate = DateTime.Today.ToString("dd-MM-yyyy");
                sw.WriteLine("[" + cDate + "] [" + cTime + "] " + exSTR);
            }
        }
        protected void alertMsg(string msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        protected int checkDateStatus()
        {
            int flag = 0;
            string mSelected = ddlMonth1.SelectedValue.ToString();
            if ((String.Compare(mSelected, "02") | String.Compare(mSelected, "04") | String.Compare(mSelected, "06") | String.Compare(mSelected, "09") | String.Compare(mSelected, "11")) == 0)
            {
                int d = Int32.Parse(ddlDay1.SelectedValue.ToString());
                if (d > 30)
                {
                    flag = 1;
                }
            }
            return flag;
        }
        protected int getint(SqlCommand tcmd)
        {
            int temp;
            var dr = tcmd.ExecuteReader();
            dr.Read();
            temp = dr.GetInt32(0);
            dr.Close();
            return temp;
        }
        protected void lbtnUTime_Click(object sender, EventArgs e)
        {
            string cTime = DateTime.Now.ToString("HH:mm:ss");
            tbTStamp.Text = cTime;
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = false;
            if (Page.IsValid)
            {
                if (checkDateStatus() == 0)
                {
                    try
                    {
                        System.Threading.Thread.Sleep(4000);
                        string tEmpID = "AZ_EMP_000" + tbEmpID.Text.ToString();
                        string dateS = ddlDay1.SelectedValue.ToString() + "/" + ddlMonth1.SelectedValue.ToString() + "/" + ddlYear1.SelectedValue.ToString();
                        SqlConnection conn = new SqlConnection(connstr);
                        conn.Open();
                        string insertQuery = "insert into mstDEntry(DeptID,EmpID,PrjID,TWrk,QualityWrk,HrsW,HrsOffice,Date,Day,TStamp)values (@DeptID,@EmpID,@PrjID,@TWrk,@QualityWrk,@HrsW,@HrsOffice,@Date,@Day,@TStamp)";
                        SqlCommand cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@DeptID", lblDeptID.Text.ToString());
                        cmd.Parameters.AddWithValue("@EmpID", tEmpID.ToString());
                        cmd.Parameters.AddWithValue("@PrjID", ddlPrjID.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@TWrk", ddlTWrk.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@QualityWrk", tbQWrk.Text.ToString());
                        cmd.Parameters.AddWithValue("@HrsW", tbHrsW.Text.ToString());
                        cmd.Parameters.AddWithValue("@HrsOffice", tbHrsO.Text.ToString());
                        cmd.Parameters.AddWithValue("@Date", dateS);
                        cmd.Parameters.AddWithValue("@Day", ddlDay.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@TStamp", tbTStamp.Text.ToString());
                        cmd.ExecuteNonQuery();
                        alertMsg("Entry Successful!");
                        insertLog("New entry sucessfully created.");

                        conn.Close();
                        ClearFields(Form.Controls);
                        lblDeptID.Visible = false;
                        lblDeptID.Text = "";

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.ToString());
                        insertLog("Error: " + ex.ToString());
                    }
                }
                else
                {
                    alertMsg("Invalid Date!");
                }
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClearFields(Form.Controls);

            lblDeptID.Visible = false;
            lblDeptID.Text = "";
        }

        protected void getDeptIDlnkbtn_Click(object sender, EventArgs e)
        {
            string tEmpID = "AZ_EMP_000" + tbEmpID.Text.ToString();
            try 
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DeptID FROM mstEmp WHERE EmpID = @tEmpID", conn);
                cmd.Parameters.AddWithValue("@tEmpID", tEmpID.ToString());
                lblDeptID.Visible = true;
                lblDeptID.Text = (string)cmd.ExecuteScalar();
                conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
        }

        protected void lbtnNewProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewProjectDetails.aspx");
        }
    }
}