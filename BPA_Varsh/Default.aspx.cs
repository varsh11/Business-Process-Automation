using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPA_Varsh
{
    public partial class _Default : Page
    {

        public ReportMain ReportMain
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Excel2DB Excel2DB
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DailyEntry DailyEntry
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public EntryMain EntryMain
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public SelectUser SelectUser
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
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:displaySlides(1);", true);

        }
        protected void newEntryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EntryMain.aspx");
        }
        protected void genReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectUser.aspx");
        }
        protected void dailyEntryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DailyEntry.aspx");
        }
    }
}