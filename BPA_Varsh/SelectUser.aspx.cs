using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class SelectUser : System.Web.UI.Page
    {
        string typeUser = "Test";

        public ADMINRepGen ADMINRepGen
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public MNGRRepGen MNGRRepGen
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DEVRepGen DEVRepGen
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
            if (System.Web.HttpContext.Current.Request.QueryString["f"] != null)
                typeUser = System.Web.HttpContext.Current.Request.QueryString["f"];
            if(String.Compare(typeUser,"out")==0)
            {
                alertMsg("Succesfully Logged Out!");
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
        protected void ibAdminLogin_Click(object sender, ImageClickEventArgs e)
        {
            System.Web.HttpContext.Current.Response.Redirect("~/LogIn.aspx?Name=Admin");
        }

        protected void ibPrjMngrLogin_Click(object sender, ImageClickEventArgs e)
        {
            System.Web.HttpContext.Current.Response.Redirect("~/LogIn.aspx?Name=PrjMngr");
        }

        protected void ibDeveloperLogin_Click(object sender, ImageClickEventArgs e)
        {
            System.Web.HttpContext.Current.Response.Redirect("~/LogIn.aspx?Name=Dev");
        }
    }
}