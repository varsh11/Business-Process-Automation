using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using Spire.Xls;

namespace BPA_Varsh
{
    public partial class Excel2DB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string savePath = tbFilePath.Text.Trim().ToString();
            string sheetName = tbWrkSheetName.Text.Trim().ToString();
            string dbName = tbDBName.Text.Trim().ToString();
            if (String.Compare(savePath, "") == 0 || String.Compare(sheetName, "") == 0 || String.Compare(dbName, "") == 0)
            {
                alertMsg("Feed in Data first!");
            }
            else
            {
                try
                {
                    if (File.Exists(savePath))
                    {
                        string strConnection = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";
                        string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + savePath + ";Extended Properties=Excel 12.0;Persist Security Info=False;";
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        OleDbCommand cmd = new OleDbCommand("Select * from [" + sheetName + "$]", excelConnection);
                        excelConnection.Open();
                        OleDbDataReader dReader;
                        dReader = cmd.ExecuteReader();
                        SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
                        sqlBulk.DestinationTableName = dbName;
                        sqlBulk.WriteToServer(dReader);
                        excelConnection.Close();
                        alertMsg("Stored Successfully!");
                        ClearFields(Form.Controls);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    ClearFields(Form.Controls);
                }
            }
        }
    }
}