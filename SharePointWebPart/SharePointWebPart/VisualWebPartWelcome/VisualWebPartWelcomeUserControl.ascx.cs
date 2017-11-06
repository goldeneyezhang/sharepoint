using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SharePointWebPart.VisualWebPartWelcome
{
    public partial class VisualWebPartWelcomeUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = string.Format("welcome! {0}.", SPContext.Current.Web.CurrentUser.Name);
            GetField();
            GetListItem();

        }
        /// <summary>
        /// 
        /// </summary>
        private void GetField()
        {
            string newText = string.Empty;
            var context = SPContext.Current;
            var list = context.Web.Lists["MyChartList"];
            var fields = list.Fields;
            foreach(SPField field in fields)
            {
                newText += field.Title + ":" + field.TypeDisplayName + "\r\n";
            }
            TextBox1.Text = newText;
        }
        private void GetListItem()
        {
            var context = SPContext.Current;
            string newText = string.Empty;
            var list = context.Web.Lists["MyChartList"];
            foreach(SPListItem listitem in list.Items)
            {
                newText += listitem["Title"].ToString()+ listitem["Count"].ToString()+"\r\n";
            }
            TextBox2.Text = newText;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var context = SPContext.Current;
            var list = context.Web.Lists["MyChartList"];
            var newitem = list.AddItem();
            newitem["Title"] = "Books";
            newitem["Count"] = 10;
            newitem["MyGroup"] = "GroupsB";
            list.Update();
        }
    }
}
