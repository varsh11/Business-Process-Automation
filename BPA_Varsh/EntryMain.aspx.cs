using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class EntryMain : System.Web.UI.Page
    {
        string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if(!IsPostBack)
            {
                var currentYear = DateTime.Today.Year;
                var count = 1;
                for (int i = 7; i >= 0; i--)
                {
                    DropDownList1.Items.Insert(count, new ListItem("FY " + (currentYear - (i + 1)).ToString() + " - " + (currentYear - i).ToString()));
                    count++;
                }
                for (int i = 10; i >= 0; i--)
                {
                    ddlYear.Items.Add((currentYear - i).ToString());
                }
                for (int i = currentYear; i >= currentYear - 20; i--)
                {
                    ddlYear1.Items.Add(i.ToString());
                }
                for (int i = 1; i <= 31; i++)
                {
                    if(i<10)
                    {
                        ddlDay1.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        ddlDay1.Items.Add(i.ToString());
                    }
                }
            }
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT PrjSegment FROM mstProjects WHERE PrjID = @PrjID", conn);
                cmd.Parameters.AddWithValue("@PrjID",ddlPrjCode.SelectedValue.ToString());
                string tPrjSegment = (string)cmd.ExecuteScalar();
                lblPrjSegment.Text=tPrjSegment;
                conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
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
            int flag=0;
            string mSelected = ddlMonth1.SelectedValue.ToString();
            if((String.Compare(mSelected, "02") | String.Compare(mSelected, "04") | String.Compare(mSelected, "06") | String.Compare(mSelected, "09") | String.Compare(mSelected, "11")) == 0)
            {
                int d = Int32.Parse(ddlDay1.SelectedValue.ToString());
                if(d>30)
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
        string alertsts;
        protected int checkb4Submit()
        {
            int flg = 0;
            if(String.Compare(ddlPrjCode.SelectedValue.ToString(),ddlMPrjCode1.SelectedValue.ToString())==0)
            {
                flg=1;
                alertsts = "Mapped Code 1 cannot be same as Project Code!";
            }
            if(String.Compare(ddlPrjCode.SelectedValue.ToString(),ddlMPrjCode2.SelectedValue.ToString())==0)
            {
                flg=1;
                alertsts = "Mapped Code 2 cannot be same as Project Code!";
            }
            if(checkDateStatus()!=0)
            {
                flg = 1;
                alertsts = "Invalid Date!";
            }
            return flg;
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = false;
            if(Page.IsValid)
            {
                if(checkb4Submit()==0)
                {
                    try
                    {
                        System.Threading.Thread.Sleep(4000);
                        string dateS = ddlDay1.SelectedValue.ToString() + "/" + ddlMonth1.SelectedValue.ToString() + "/" + ddlYear1.SelectedValue.ToString();
                        SqlConnection conn = new SqlConnection(connstr);
                        conn.Open();
                        string insertQuery = "insert into fmst(RYear,Month,Yr,RDate,Domain,Location1,Consideration,PrjCode,MPrjCode1,MPrjCode2,PrjCodeSegment,AccName,AccOwner,Study,Segment,Country,StudyType,ClientType,ClientCountry,PartnerName,PartnerCountry,PrjManager,BTR,CCPI,PCPI,PlannedRes,Target,PlannedRevenue,PlannedCost,ActualRes,Absent,Achieved,ActualRevenue,ActualCost,ActualCostW,PlannedRevenueCM,Location2)values (@RYear,@Month,@Yr,@RDate,@Domain,@Location1,@Consideration,@PrjCode,@MPrjCode1,@MPrjCode2,@PrjCodeSegment,@AccName,@AccOwner,@Study,@Segment,@Country,@StudyType,@ClientType,@ClientCountry,@PartnerName,@PartnerCountry,@PrjManager,@BTR,@CCPI,@PCPI,@PlannedRes,@Target,@PlannedRevenue,@PlannedCost,@ActualRes,@Absent,@Achieved,@ActualRevenue,@ActualCost,@ActualCostW,@PlannedRevenueCM,@Location2)";
                        SqlCommand cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@RYear", DropDownList1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Month", ddlMonth.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Yr", ddlYear.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@RDate", dateS);
                        cmd.Parameters.AddWithValue("@Domain", ddlDomain.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Location1", ddlLocation.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Consideration", TBConsideration.Text.ToString());
                        cmd.Parameters.AddWithValue("@PrjCode", ddlPrjCode.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MPrjCode1", ddlMPrjCode1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MPrjCode2", ddlMPrjCode2.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PrjCodeSegment", lblPrjSegment.Text.ToString());
                        cmd.Parameters.AddWithValue("@AccName", "TEST");
                        cmd.Parameters.AddWithValue("@AccOwner", "TEST");
                        cmd.Parameters.AddWithValue("@Study", TBStudy.Text.ToString());
                        cmd.Parameters.AddWithValue("@Segment", TBSegment.Text.ToString());
                        cmd.Parameters.AddWithValue("@Country", ddlCountry1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@StudyType", TBStudyType.Text.ToString());
                        cmd.Parameters.AddWithValue("@ClientType", ddlClientType.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@ClientCountry", ddlCountry2.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PartnerName", TBPartnerName.Text.ToString());
                        cmd.Parameters.AddWithValue("@PartnerCountry", ddlPartnerCountry.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PrjManager", ddlPrjMngr.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@BTR", TBbtr.Text);
                        cmd.Parameters.AddWithValue("@CCPI", TBccpi.Text);
                        cmd.Parameters.AddWithValue("@PCPI", TBpcpi.Text);
                        cmd.Parameters.AddWithValue("@PlannedRes", TBplannedRes.Text.ToString());
                        cmd.Parameters.AddWithValue("@Target", TBConsideration0.Text.ToString());
                        cmd.Parameters.AddWithValue("@PlannedRevenue", TBConsideration1.Text);
                        cmd.Parameters.AddWithValue("@PlannedCost", TBConsideration2.Text);
                        cmd.Parameters.AddWithValue("@ActualRes", TBConsideration3.Text.ToString());
                        cmd.Parameters.AddWithValue("@Absent", TBConsideration4.Text.ToString());
                        cmd.Parameters.AddWithValue("@Achieved", TBConsideration5.Text.ToString());
                        cmd.Parameters.AddWithValue("@ActualRevenue", TBConsideration6.Text);
                        cmd.Parameters.AddWithValue("@ActualCost", TBConsideration7.Text);
                        cmd.Parameters.AddWithValue("@ActualCostW", TBConsideration8.Text);
                        cmd.Parameters.AddWithValue("@PlannedRevenueCM", TBConsideration9.Text.ToString());
                        cmd.Parameters.AddWithValue("@Location2", ddlLoc2.SelectedValue.ToString());

                        cmd.ExecuteNonQuery();
                        alertMsg("Entry Successful!");
                        insertLog("New entry sucessfully created.");

                        conn.Close();
                        ClearFields(Form.Controls);
                        lblPrjSegment.Text = "Select Project Code First.";

                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.ToString());
                        insertLog("Error: " + ex.ToString());
                    }
                }
                else
                {
                    alertMsg(alertsts);
                }
        }
        }
        
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClearFields(Form.Controls);
            lblPrjSegment.Text = "Select Project Code First.";
        }
        protected void addDomainLinkBtn_Click(object sender, EventArgs e)
        {
            TBaddDomain.Visible = true;
            BaddDomain.Visible = true;
        }
        protected void addLocationLinkBtn_Click(object sender, EventArgs e)
        {
            TBaddLocation.Visible = true;
            BaddLocation.Visible = true;
        }
        protected void addClientLinkBtn_Click(object sender, EventArgs e)
        {
            TBaddClientType.Visible = true;
            BaddClientType.Visible = true;
        }
        protected void addLoc2LinkBtn_Click(object sender, EventArgs e)
        {
            TBaddLoc2.Visible = true;
            BaddLoc2.Visible = true;
        }
        protected void addDomainBtn_Click(Object sender, EventArgs e)
        {
            try
            {
                int maxId;
                int count = 0;
                SqlConnection dataConnection = new SqlConnection(connstr);
                SqlCommand maxCmd = new SqlCommand("select max(Id) from mstDomain", dataConnection);
                dataConnection.Open();
                maxId = getint(maxCmd);
                maxId++;
                SqlCommand selectMatch = new SqlCommand("SELECT count(Domain) FROM mstDomain WHERE Domain = '" + TBaddDomain.Text.ToString() + "'", dataConnection);
                count = getint(selectMatch);
                if(TBaddDomain.Text.ToString().Trim() == "")
                {
                    alertMsg("Insert some value!");
                }
                else if (count == 0)
                {
                    SqlCommand insCmd = new SqlCommand("insert into mstDomain(Id,Domain)values (@Id,@Domain)", dataConnection);
                    insCmd.Parameters.AddWithValue("@Id", maxId);
                    insCmd.Parameters.AddWithValue("@Domain", TBaddDomain.Text.ToString());
                    insCmd.ExecuteNonQuery();
                    ddlDomain.Items.Insert(maxId, TBaddDomain.Text.ToString());
                    ddlDomain.SelectedIndex = maxId;
                }
                else
                {
                    alertMsg("Option available in the list. Select from there!");
                }
                TBaddDomain.Visible = false;
                TBaddDomain.Text = "";
                BaddDomain.Visible = false;
                dataConnection.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
        }
        protected void addLocationBtn_Click(Object sender, EventArgs e)
        {
            try
            {
                int maxId;
                int count=0;
                SqlConnection dataConnection = new SqlConnection(connstr);
                SqlCommand maxCmd = new SqlCommand("select max(Id) from mstLocation", dataConnection);
                dataConnection.Open();
                maxId = getint(maxCmd);
                maxId++;
                SqlCommand selectMatch = new SqlCommand("SELECT count(Location) FROM mstLocation WHERE Location = '" + TBaddLocation.Text.ToString() + "'", dataConnection);
                count = getint(selectMatch);
                if (TBaddLocation.Text.ToString().Trim() == "")
                {
                    alertMsg("Insert some value!");
                }
                else if(count == 0)
                {
                    SqlCommand insCmd = new SqlCommand("insert into mstLocation(Id,Location)values (@Id,@Location)", dataConnection);
                    insCmd.Parameters.AddWithValue("@Id", maxId);
                    insCmd.Parameters.AddWithValue("@Location", TBaddLocation.Text.ToString());
                    insCmd.ExecuteNonQuery();
                    ddlLocation.Items.Insert(maxId, TBaddLocation.Text.ToString());
                    ddlLocation.SelectedIndex = maxId;
                }
                else 
                {
                    alertMsg("Option available in the list. Select from there!");
                }

                TBaddLocation.Visible = false;
                TBaddLocation.Text = "";
                BaddLocation.Visible = false;
                dataConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
        }
        protected void addClientBtn_Click(Object sender, EventArgs e)
        {
            try
            {
                int maxId;
                int count = 0;
                SqlConnection dataConnection = new SqlConnection(connstr);
                SqlCommand maxCmd = new SqlCommand("select max(Id) from mstClientType", dataConnection);
                dataConnection.Open();
                maxId = getint(maxCmd);
                maxId++;
                SqlCommand selectMatch = new SqlCommand("SELECT count(CType) FROM mstClientType WHERE CType = '" + TBaddClientType.Text.ToString() + "'", dataConnection);
                count = getint(selectMatch);
                if (TBaddClientType.Text.ToString().Trim() == "")
                {
                    alertMsg("Insert some value!");
                }
                else if (count == 0)
                {
                    SqlCommand insCmd = new SqlCommand("insert into mstClientType(Id,CType)values (@Id,@CType)", dataConnection);
                    insCmd.Parameters.AddWithValue("@Id", maxId);
                    insCmd.Parameters.AddWithValue("@CType", TBaddClientType.Text.ToString());
                    insCmd.ExecuteNonQuery();
                    ddlClientType.Items.Insert(maxId, TBaddClientType.Text.ToString());
                    ddlClientType.SelectedIndex = maxId;
                }
                else
                {
                    alertMsg("Option available in the list. Select from there!");
                }
                TBaddClientType.Visible = false;
                TBaddClientType.Text = "";
                BaddClientType.Visible = false;
                dataConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
                insertLog("Error: " + ex.ToString());
            }
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

        public NewProjectDetails NewProjectDetails
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}