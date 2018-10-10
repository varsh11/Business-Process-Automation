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
    public partial class EditPrjDetails : System.Web.UI.Page
    {
        string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            int dllcount = DropDownList1.SelectedIndex;
            if(dllcount==0)
            {
                EditPrjlb.Visible = false;
            }
            else
            {
                EditPrjlb.Visible = true;
            }


            if(cbPrjStrength.Checked)
            {
                tbPrjStrength.Visible = true;
                btnPrjStrength.Visible = true;
            }
            if(cbPrjMngr.Checked)
            {
                ddlPrjMngr.Visible = true;
                btnPrjMngr.Visible = true;
            }
            if(cbPrjCountry.Checked)
            {
                ddlPrjCountry.Visible = true;
                btnPrjCountry.Visible = true;
            }
            if(cbPName.Checked)
            {
                tbPName.Visible = true;
                btnPName.Visible = true;
            }
            if(cbPCountry.Checked)
            {
                ddlPCountry.Visible = true;
                btnPcountry.Visible = true;
            }
            if(cbLocation2.Checked)
            {
                ddlLocation2.Visible = true;
                btnLocation2.Visible = true;
            }
            if(cbEDate.Checked)
            {
                tbEDate.Visible = true;
                btnEDate.Visible = true;
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
        protected int getint(SqlCommand tcmd)
        {
            int temp;
            var dr = tcmd.ExecuteReader();
            dr.Read();
            temp = dr.GetInt32(0);
            dr.Close();
            return temp;
        }

        protected void EditPrjlb_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Visible = true;
        }
        protected void btnPrjStrength_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            try
                    {
                        SqlConnection conn = new SqlConnection(connstr);
                        conn.Open();
                        string updateQuery = "UPDATE mstProjects SET PrjStrength=@PrjStrength WHERE PrjID='" + DropDownList1.SelectedValue.ToString() + "'";
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@PrjStrength", tbPrjStrength.Text.ToString());
                        cmd.ExecuteNonQuery();
                        alertMsg("Update Successful!");
                        insertLog("Entry sucessfully updated.");
                        conn.Close();
                        ClearFields(Form.Controls);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.ToString());
                        insertLog("Error: " + ex.ToString());
                    }
            cbPrjStrength.Checked = false;
            tbPrjStrength.Visible = false;
            btnPrjStrength.Visible = false;
        }

        protected void btnPrjMngr_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string updateQuery = "UPDATE mstProjects SET PrjMngr=@PrjMngr WHERE PrjID='" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@PrjMngr", ddlPrjMngr.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                alertMsg("Update Successful!");
                insertLog("Entry sucessfully updated.");
                conn.Close();
                ClearFields(Form.Controls);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
            cbPrjMngr.Checked = false;
            ddlPrjMngr.Visible = false;
            btnPrjMngr.Visible = false;
        }

        protected void btnPrjCountry_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string updateQuery = "UPDATE mstProjects SET PrjCountry=@PrjCountry WHERE PrjID='" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@PrjCountry", ddlPrjCountry.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                alertMsg("Update Successful!");
                insertLog("Entry sucessfully updated.");
                conn.Close();
                ClearFields(Form.Controls);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
            cbPrjCountry.Checked = false;
            ddlPrjCountry.Visible = false;
            btnPrjCountry.Visible = false;
        }

        protected void btnEDate_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string updateQuery = "UPDATE mstProjects SET EDate=@EDate WHERE PrjID='" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@EDate", tbEDate.Text.ToString());
                cmd.ExecuteNonQuery();
                alertMsg("Update Successful!");
                insertLog("Entry sucessfully updated.");
                conn.Close();
                ClearFields(Form.Controls);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
            cbEDate.Checked = false;
            tbEDate.Visible = false;
            btnEDate.Visible = false;
        }

        protected void btnPName_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string updateQuery = "UPDATE mstProjects SET PName=@PName WHERE PrjID='" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@PName", tbPName.Text.ToString());
                cmd.ExecuteNonQuery();
                alertMsg("Update Successful!");
                insertLog("Entry sucessfully updated.");
                conn.Close();
                ClearFields(Form.Controls);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
            cbPName.Checked = false;
            tbPName.Visible = false;
            btnPName.Visible = false;
        }

        protected void btnPcountry_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string updateQuery = "UPDATE mstProjects SET PCountry=@PCountry WHERE PrjID='" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@PCountry", ddlPCountry.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                alertMsg("Update Successful!");
                insertLog("Entry sucessfully updated.");
                conn.Close();
                ClearFields(Form.Controls);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
            cbPCountry.Checked = false;
            ddlPCountry.Visible = false;
            btnPcountry.Visible = false;
        }

        protected void btnLocation2_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string updateQuery = "UPDATE mstProjects SET Location2=@Location2 WHERE PrjID='" + DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Location2", ddlLocation2.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                alertMsg("Update Successful!");
                insertLog("Entry sucessfully updated.");
                conn.Close();
                ClearFields(Form.Controls);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
            cbLocation2.Checked = false;
            ddlLocation2.Visible = false;
            btnLocation2.Visible = false;
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Visible = false;
        }
    }
}