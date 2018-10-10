using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = this.GetData(0);
                PopulateMenu(dt, 0, null);
            }
        }

        private DataTable GetData(int parentMenuId)
        {
            string query = "SELECT [MenuId], [Title], [Description], [Url] FROM [Menus] WHERE ParentMenuId = @ParentMenuId";
            string connstr = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=TestHome;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connstr))
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@ParentMenuId", parentMenuId);
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

        private void PopulateMenu(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
            foreach (DataRow row in dt.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    Value = row["MenuId"].ToString(),
                    Text = row["Title"].ToString(),
                    NavigateUrl = row["Url"].ToString(),
                    Selected = row["Url"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
                };
                if (parentMenuId == 0)
                {
                    Menu1.Items.Add(menuItem);
                    DataTable dtChild = this.GetData(int.Parse(menuItem.Value));
                    PopulateMenu(dtChild, int.Parse(menuItem.Value), menuItem);
                }
                else
                {
                    parentMenuItem.ChildItems.Add(menuItem);
                }
            }
        }
    }
}