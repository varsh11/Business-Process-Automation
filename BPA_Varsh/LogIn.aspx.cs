using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class LogIn : System.Web.UI.Page
    {
        string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";
        string typeUser = "Test";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Name"] != null)
                typeUser = Request.QueryString["Name"];
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
        protected void lbFrgtPass_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dataConnection = new SqlConnection(connstr);
                dataConnection.Open();
                string EmpIDTemp = tbID.Text.Trim().ToString();
                if(String.Compare(EmpIDTemp,"")==0)
                {
                    alertMsg("Please enter Employee ID first.");
                }
                else
                {
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM mstLogin WHERE EmpID = @EmpID", dataConnection);
                    check_User_Name.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                    int UserExist = (int)check_User_Name.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        SqlCommand getpassQRY = new SqlCommand("SELECT Password FROM mstLogin WHERE EmpID = @EmpID;", dataConnection);
                        getpassQRY.Parameters.AddWithValue("@EmpID", EmpIDTemp);
                        string pass = (string)getpassQRY.ExecuteScalar();
                        SqlCommand getmailQRY = new SqlCommand("SELECT Email FROM mstEmp WHERE EmpID = @EmpID;", dataConnection);
                        getmailQRY.Parameters.AddWithValue("@EmpID", EmpIDTemp);
                        string TOmail = (string)getmailQRY.ExecuteScalar();
                        dataConnection.Close();
                        string mailBodyhtml =
                            "<p>Dear <b>" + EmpIDTemp + "</b>,<br /><br />Your password is <b>" + pass + "</b><br /><br /><br /><b><font color=\"red\">Do not share this password.</font></b><br /><br />Thanks & Regards,<br />Azure Systems.<br /><br /><b>Disclaimer: </b>Privileged & confidential information is contained in this message (including all attachments). If you are not an intended recipient of this message, please destroy this message immediately and kindly notify the sender by reply e-mail. Any unauthorized use or dissemination of this message in any manner whatsoever, in whole or in part, is strictly prohibited. This e-mail, including all attachments hereto, is for discussion purposes only and shall not be deemed or construed otherwise unless expressly stated. Any views or opinions presented in this email are solely those of the author and do not necessarily represent that of Azure Knowledge Corp. This communication, including any attachments,may not be free of viruses, interceptions or interference, and may not be compatible with your systems. You should carry out your own virus checks before opening any attachment to this e-mail. The sender of this e-mail and Azure Knowledge Corp. shall not be liable for any damage that you may sustain as a result of viruses, incompleteness of this message, a delay in receipt of this message or computer problems experienced. This message has been scanned for viruses and dangerous content by Azure Systems Email Server, and is believed to be clean.</p>";
                        MailMessage msg = new MailMessage("az.emp.0002120@gmail.com", TOmail, "Password for Azure Systems", mailBodyhtml);
                        msg.IsBodyHtml = true;
                        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.Credentials = new NetworkCredential("az.emp.0002120@gmail.com", "ShruVars11");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(msg);
                        insertLog("Forget Password: Mail Sent.");
                        alertMsg("Mail sent, Please check your inbox.");
                    }
                    else
                    {
                        alertMsg("Please check your Credentials!");
                    }
                } 
            }
            catch (Exception ex)
            {
                insertLog("Error: " + ex.ToString());
                Response.Write(ex);
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if(typeUser=="Admin")
                {
                    SqlConnection dataConnection = new SqlConnection(connstr);
                    dataConnection.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM mstLogin WHERE EmpID = @EmpID", dataConnection);
                    check_User_Name.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                    int UserExist = (int)check_User_Name.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        SqlCommand getCTypeQRY = new SqlCommand("SELECT EmpType FROM mstEmp WHERE EmpID = @EmpID;", dataConnection);
                        getCTypeQRY.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                        string cT = (string)getCTypeQRY.ExecuteScalar();
                        SqlCommand getpassQRY = new SqlCommand("SELECT Password FROM mstLogin WHERE EmpID = @EmpID;", dataConnection);
                        getpassQRY.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                        string pass = (string)getpassQRY.ExecuteScalar();
                        dataConnection.Close();
                        if (String.Compare(cT, "C1") == 0)
                        {
                            if(String.Compare(pass,tbPass.Text.Trim().ToString())==0)
                            {
                                Response.Redirect("~/ADMINRepGen.aspx");
                            }
                            else
                            {
                                alertMsg("Password Incorrect!");
                                ClearFields(Form.Controls);
                            }
                        }
                        else
                        {
                            alertMsg("You are not an ADMIN !");
                            ClearFields(Form.Controls);
                            insertLog("***ALERT***: " + tbID.Text.Trim().ToString() + " Tried to enter as ADMIN.");
                        }
                    }
                    else
                    {
                        alertMsg("Please check your Credentials!");
                    }
                }
                if(typeUser=="PrjMngr")
                {
                    SqlConnection dataConnection = new SqlConnection(connstr);
                    dataConnection.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM mstLogin WHERE EmpID = @EmpID", dataConnection);
                    check_User_Name.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                    int UserExist = (int)check_User_Name.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        SqlCommand getCTypeQRY = new SqlCommand("SELECT EmpType FROM mstEmp WHERE EmpID = @EmpID;", dataConnection);
                        getCTypeQRY.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                        string cT = (string)getCTypeQRY.ExecuteScalar();
                        SqlCommand getpassQRY = new SqlCommand("SELECT Password FROM mstLogin WHERE EmpID = @EmpID;", dataConnection);
                        getpassQRY.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                        string pass = (string)getpassQRY.ExecuteScalar();
                        dataConnection.Close();
                        if (String.Compare(cT, "C1") == 0 || String.Compare(cT,"C2")==0)
                        {
                            if (String.Compare(pass, tbPass.Text.Trim().ToString()) == 0) 
                            {
                                Response.Redirect("~/MNGRRepGen.aspx");
                            }
                            else
                            {
                                alertMsg("Password Incorrect!");
                                ClearFields(Form.Controls);
                            }
                        }
                        else
                        {
                            alertMsg("You are not a PROJECT MANAGER !");
                            ClearFields(Form.Controls);
                            insertLog("***ALERT***: " + tbID.Text.Trim().ToString() + " Tried to enter as PROJECT MANAGER.");
                        }
                    }
                    else
                    {
                        alertMsg("Please check your Credentials!");
                    }
                }
                if (typeUser == "Dev")
                {
                    SqlConnection dataConnection = new SqlConnection(connstr);
                    dataConnection.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM mstLogin WHERE EmpID = @EmpID", dataConnection);
                    check_User_Name.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                    int UserExist = (int)check_User_Name.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        SqlCommand getCTypeQRY = new SqlCommand("SELECT EmpType FROM mstEmp WHERE EmpID = @EmpID;", dataConnection);
                        getCTypeQRY.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                        string cT = (string)getCTypeQRY.ExecuteScalar();
                        SqlCommand getpassQRY = new SqlCommand("SELECT Password FROM mstLogin WHERE EmpID = @EmpID;", dataConnection);
                        getpassQRY.Parameters.AddWithValue("@EmpID", tbID.Text.Trim().ToString());
                        string pass = (string)getpassQRY.ExecuteScalar();
                        dataConnection.Close();
                        if (String.Compare(cT, "C1")==0 || String.Compare(cT,"C2")==0 || String.Compare(cT, "C3") == 0)
                        {
                            if (String.Compare(pass, tbPass.Text.Trim().ToString()) == 0)
                            {
                                Application["Username"] = tbID.Text;
                                Response.Redirect("~/DEVRepGen.aspx");
                            }
                            else
                            {
                                alertMsg("Password Incorrect!");
                                ClearFields(Form.Controls);
                            }
                        }
                        else
                        {
                            alertMsg("You are not a DEVELOPER !");
                            ClearFields(Form.Controls);
                            insertLog("***ALERT***: " + tbID.Text.Trim().ToString() + " Tried to enter as DEVELOPER.");
                        }
                    }
                    else
                    {
                        alertMsg("Please check your Credentials!");
                    }
                }
                
            }
            catch (Exception ex)
            {
                insertLog("Error: " + ex.ToString());
                Response.Write(ex);
            }
        }
    }
}