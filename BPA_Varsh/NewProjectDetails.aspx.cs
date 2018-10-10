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
    public partial class NewProjectDetails : System.Web.UI.Page
    {
        string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                var currentYear = DateTime.Today.Year;
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
                for (int i = currentYear; i >= currentYear - 20; i--)
                {
                    ddlYear2.Items.Add(i.ToString());
                }
                for (int i = 1; i <= 31; i++)
                {
                    if (i < 10)
                    {
                        ddlDay2.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        ddlDay2.Items.Add(i.ToString());
                    }
                }
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
        protected int getint(SqlCommand tcmd)
        {
            int temp;
            var dr = tcmd.ExecuteReader();
            dr.Read();
            temp = dr.GetInt32(0);
            dr.Close();
            return temp;
        }
        protected void addLoc2LinkBtn_Click(object sender, EventArgs e)
        {
            TBaddLoc2.Visible = true;
            BaddLoc2.Visible = true;
        }
        protected void addLoc2Btn_Click(Object sender, EventArgs e)
        {
            try
            {
                int maxId;
                int count = 0;
                SqlConnection dataConnection = new SqlConnection(connstr);
                SqlCommand maxCmd = new SqlCommand("select max(Id) from Location1", dataConnection);
                dataConnection.Open();
                maxId = getint(maxCmd);
                maxId++;
                SqlCommand selectMatch = new SqlCommand("SELECT count(Location) FROM Location1 WHERE Location = '" + TBaddLoc2.Text.ToString() + "'", dataConnection);
                count = getint(selectMatch);
                if (TBaddLoc2.Text.ToString().Trim() == "")
                {
                    alertMsg("Insert some value!");
                }
                else if (count == 0)
                {
                    SqlCommand insCmd = new SqlCommand("insert into Location1(Id,Location)values (@Id,@Location)", dataConnection);
                    insCmd.Parameters.AddWithValue("@Id", maxId);
                    insCmd.Parameters.AddWithValue("@Location", TBaddLoc2.Text.ToString());
                    insCmd.ExecuteNonQuery();
                    ddlLoc2.Items.Insert(maxId, TBaddLoc2.Text.ToString());
                    ddlLoc2.SelectedIndex = maxId;
                }
                else
                {
                    alertMsg("Option available in the list. Select from there!");
                }
                TBaddLoc2.Visible = false;
                TBaddLoc2.Text = "";
                BaddLoc2.Visible = false;
                dataConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
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
                        string tPrjID = "AZ001_" + tbPrjID1.Text.ToString() + "_" + tbPrjID2.Text.ToString();
                        SqlConnection conn = new SqlConnection(connstr);
                        conn.Open();
                        string chkqry = "SELECT count(PrjID) FROM mstProjects where PrjID = @PrjID";
                        SqlCommand chkcmd = new SqlCommand(chkqry, conn);
                        chkcmd.Parameters.AddWithValue("@PrjID", tPrjID);
                        int prst = getint(chkcmd);
                        if (prst == 0)
                        {
                            System.Threading.Thread.Sleep(4000);
                            string dateS = ddlDay1.SelectedValue.ToString() + "/" + ddlMonth1.SelectedValue.ToString() + "/" + ddlYear1.SelectedValue.ToString();
                            string dateE = ddlDay2.SelectedValue.ToString() + "/" + ddlMonth2.SelectedValue.ToString() + "/" + ddlYear2.SelectedValue.ToString();
                            string insertQuery = "insert into mstProjects(PrjID,PrjName,PrjSegment,PrjStrength,PrjMngr,SDate,EDate,PName,PCountry,PrjCountry,Location2)values (@PrjID,@PrjName,@PrjSegment,@PrjStrength,@PrjMngr,@SDate,@EDate,@PName,@PCountry,@PrjCountry,@Location2)";
                            SqlCommand cmd = new SqlCommand(insertQuery, conn);
                            cmd.Parameters.AddWithValue("@PrjID", tPrjID);
                            cmd.Parameters.AddWithValue("@PrjName", tbPrjName.Text.ToString());
                            cmd.Parameters.AddWithValue("@PrjSegment",tbPrjSegment.Text.ToString());
                            cmd.Parameters.AddWithValue("@PrjStrength", tbPrjStrength.Text.ToString());
                            cmd.Parameters.AddWithValue("@PrjMngr", ddlPrjMngr.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@SDate", dateS);
                            cmd.Parameters.AddWithValue("@EDate", dateE);
                            cmd.Parameters.AddWithValue("@PName", tbPName.Text.ToString());
                            cmd.Parameters.AddWithValue("@PCountry", ddlPCountry.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@PrjCountry", ddlPrjCountry.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@Location2", ddlLoc2.SelectedValue.ToString());
                            cmd.ExecuteNonQuery();
                            alertMsg("Entry Successful!");
                            insertLog("New entry sucessfully created.");    
                        }
                        else 
                        {
                            alertMsg("Project Already Present.");
                        }
                        conn.Close();
                        ClearFields(Form.Controls);
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
        }
    }
}