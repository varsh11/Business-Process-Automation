using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Web.UI.WebControls;  

namespace BPA_Varsh
{
    public partial class ReportMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var currentYear = DateTime.Today.Year;
                var count = 1;
                for (int i = 7; i >= 0; i--)
                {
                    DropDownList1.Items.Insert(count, new ListItem("FY " + (currentYear - (i + 1)).ToString() + " - " + (currentYear - i).ToString()));
                    count++;
                }
            }
            if(IsPostBack)
            {
                string sValue = ddlMonth.SelectedValue;
                string sQuery;
                if(String.Compare(sValue,"RYear")==0)
                {

                }
                else if(String.Compare(sValue,"Country")==0)
                {

                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }
     }
}